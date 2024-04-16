namespace StudyWithWinform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlChessBoard = new Panel();
            panel1 = new Panel();
            pbAvatar = new PictureBox();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            btnConnect = new Button();
            pbControl = new PictureBox();
            prcbCoolDown = new ProgressBar();
            txtIPServer = new TextBox();
            txtUserName = new TextBox();
            tmCoolDown = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAvatar).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbControl).BeginInit();
            SuspendLayout();
            // 
            // pnlChessBoard
            // 
            pnlChessBoard.BackColor = SystemColors.Control;
            pnlChessBoard.Location = new Point(5, 4);
            pnlChessBoard.Name = "pnlChessBoard";
            pnlChessBoard.Size = new Size(589, 589);
            pnlChessBoard.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel1.Controls.Add(pbAvatar);
            panel1.Location = new Point(606, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(309, 309);
            panel1.TabIndex = 1;
            // 
            // pbAvatar
            // 
            pbAvatar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pbAvatar.BackColor = SystemColors.Control;
            pbAvatar.Image = Properties.Resources.Avatar;
            pbAvatar.Location = new Point(3, 3);
            pbAvatar.Name = "pbAvatar";
            pbAvatar.Size = new Size(303, 303);
            pbAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbAvatar.TabIndex = 0;
            pbAvatar.TabStop = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(btnConnect);
            panel2.Controls.Add(pbControl);
            panel2.Controls.Add(prcbCoolDown);
            panel2.Controls.Add(txtIPServer);
            panel2.Controls.Add(txtUserName);
            panel2.Location = new Point(606, 329);
            panel2.Name = "panel2";
            panel2.Size = new Size(309, 264);
            panel2.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Wide Latin", 15F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label2.Location = new Point(11, 61);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 5;
            label2.Text = "Turn of:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Rockwell Extra Bold", 20F, FontStyle.Italic);
            label1.ForeColor = Color.Chocolate;
            label1.Location = new Point(11, 13);
            label1.Name = "label1";
            label1.Size = new Size(281, 32);
            label1.TabIndex = 3;
            label1.Text = "5 in a line to WIN";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(12, 221);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Play";
            btnConnect.UseVisualStyleBackColor = true;
            // 
            // pbControl
            // 
            pbControl.Location = new Point(198, 61);
            pbControl.Name = "pbControl";
            pbControl.Size = new Size(94, 94);
            pbControl.SizeMode = PictureBoxSizeMode.StretchImage;
            pbControl.TabIndex = 3;
            pbControl.TabStop = false;
            // 
            // prcbCoolDown
            // 
            prcbCoolDown.Location = new Point(11, 131);
            prcbCoolDown.Name = "prcbCoolDown";
            prcbCoolDown.Size = new Size(181, 24);
            prcbCoolDown.TabIndex = 2;
            // 
            // txtIPServer
            // 
            txtIPServer.Location = new Point(12, 192);
            txtIPServer.Name = "txtIPServer";
            txtIPServer.Size = new Size(181, 23);
            txtIPServer.TabIndex = 1;
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Script MT Bold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtUserName.Location = new Point(11, 91);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(181, 32);
            txtUserName.TabIndex = 0;
            // 
            // tmCoolDown
            // 
            tmCoolDown.Tick += tmCoolDown_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 598);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pnlChessBoard);
            Name = "Form1";
            Text = "CaRo";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbAvatar).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbControl).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlChessBoard;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pbAvatar;
        private TextBox txtIPServer;
        private TextBox txtUserName;
        private Button btnConnect;
        private PictureBox pbControl;
        private ProgressBar prcbCoolDown;
        private Label label1;
        private Label label2;
        private System.Windows.Forms.Timer tmCoolDown;
    }
}
