namespace StudyWithWinform
{
    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager ChessBoard;
        #endregion
        public Form1()
        {
            InitializeComponent();
            ChessBoard = new ChessBoardManager(pnlChessBoard, txtUserName, pbControl);
            ChessBoard.EndedGame += ChessBoard_EndedGame;
            ChessBoard.PlayerMarker += ChessBoard_PlayerMarker;


            prcbCoolDown.Step = Cons.COOL_DOWN_STEP;
            prcbCoolDown.Maximum = Cons.COOL_DOWN_TIME;
            prcbCoolDown.Value = 0;

            tmCoolDown.Interval = Cons.COOL_DOWN_INTERVAL;

            ChessBoard.DrawChessBoard();
        }

        private void ChessBoard_PlayerMarker(object? sender, EventArgs e)
        {
            tmCoolDown.Start();
            prcbCoolDown.Value = 0;
        }

        private void ChessBoard_EndedGame(object? sender, EventArgs e)
        {
            EndGame();
        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            prcbCoolDown.PerformStep();

            if(prcbCoolDown.Value >= prcbCoolDown.Maximum)
            {
                
                EndGame();
            }
        }

        private void EndGame()
        {
            pnlChessBoard.Enabled = false;
            tmCoolDown.Stop();
            MessageBox.Show("End Game");
        }
    }
}
