﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StudyWithWinform
{
    public class ChessBoardManager
    {
        #region Properties
        private Panel chessBoard;
        private List<Player> player;
        private int currentPlayer;
        private TextBox playerName;
        private PictureBox playerMark;
        private List<List<Button>> matrix;
        private event EventHandler playerMarked;
        private event EventHandler endedGame;

        public Panel ChessBoard { get { return chessBoard; } set { chessBoard = value; } }
        public List<Player> Player { get => player; set => player = value; }
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
        public TextBox PlayerName { get => playerName; set => playerName = value; }
        public PictureBox PlayerMark { get => playerMark; set => playerMark = value; }
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }
        public event EventHandler PlayerMarker { add { playerMarked += value; } remove { playerMarked -= value; } }
        public event EventHandler EndedGame { add { endedGame += value; } remove { endedGame -= value; } }
        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard, TextBox playerName, PictureBox playerMark)
        {
            this.ChessBoard = chessBoard;
            this.PlayerName = playerName;
            this.playerMark = playerMark;

            this.Player = new List<Player>()
            {
                new Player("ThanhHT", Image.FromFile(Application.StartupPath + "\\data\\o.png")),
                new Player("ThaoNT", Image.FromFile(Application.StartupPath + "\\data\\x.png"))
            };
            CurrentPlayer = 0;
            ChangePlayer();
        }
        #endregion

        #region Methods
        public void DrawChessBoard()
        {
            ChessBoard.Enabled = true;
            Matrix = new List<List<Button>>();
            Button oldButton = new Button() { Width = 0, Location = new Point(0, 0) };
            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                Matrix.Add(new List<Button>());

                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button()
                    {
                        Width = Cons.CHESS_WIDTH,
                        Height = Cons.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()
                    };
                    btn.Click += btn_Click;
                    ChessBoard.Controls.Add(btn);
                    Matrix[i].Add(btn);
                    oldButton = btn;

                }
                oldButton.Location = new Point(0, oldButton.Location.Y + Cons.CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
        }

        void btn_Click(object? sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null)
            {
                return;
            }
            Mark(btn);
            ChangePlayer();

            if ( playerMarked != null)
            {
                playerMarked(this, new EventArgs());
            }

            if (isEndGame(btn))
            {
                EndGame();
            }


        }

        public void EndGame()
        {
            if (endedGame != null)
            {
                endedGame(this, new EventArgs());
            }
        }

        private bool isEndGame(Button btn)
        {

            return isEndHorizontal(btn) || isEndPrimary(btn) || isEndVertical(btn) || isEndSub(btn);
        }

        private Point GetChessPoint(Button btn)
        {
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);

            Point point = new Point(horizontal, vertical);

            return point;
        }

        private bool isEndHorizontal(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countLeft = 0;
            for (int i = point.X; i >= 0; i--)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else
                    break;
            }
            int countRight = 0;
            for (int i = point.X + 1; i < Cons.CHESS_BOARD_WIDTH; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else
                    break;
            }
            return countLeft + countRight == 5;
        }

        private bool isEndVertical(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = point.Y; i >= 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }
            int countBottom = 0;
            for (int i = point.Y + 1; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }
            return countTop + countBottom == 5;
        }

        private bool isEndPrimary(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;
                if (Matrix[point.Y - i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }
            int countBottom = 0;
            for (int i = 1; i <= Cons.CHESS_BOARD_WIDTH - point.X; i++)
            {
                if(point.Y + i >= Cons.CHESS_BOARD_HEIGHT || point.X + i >= Cons.CHESS_BOARD_WIDTH)
                    break;
                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }
            return countTop + countBottom == 5;
        }



        private bool isEndSub(Button btn)
        {
            Point point = GetChessPoint(btn);

            int countTop = 0;
            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i > Cons.CHESS_BOARD_WIDTH || point.Y - i < 0)
                    break;
                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;
            }
            int countBottom = 0;
            for (int i = 1; i <= Cons.CHESS_BOARD_WIDTH - point.X; i++)
            {
                if (point.Y + i >= Cons.CHESS_BOARD_HEIGHT || point.X - i < 0)
                    break;
                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;
            }
            return countTop + countBottom == 5;
        }

        private void Mark(Button btn)
        {
            btn.BackgroundImage = Player[currentPlayer].Mark;
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
        }

        private void ChangePlayer()
        {
            PlayerName.Text = Player[CurrentPlayer].Name;
            PlayerMark.Image = Player[CurrentPlayer].Mark;
        }
        #endregion


    }
}
