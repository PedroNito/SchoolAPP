namespace gestao
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            label_loginTitle = new Label();
            label_answer_username = new Label();
            label_answer_password = new Label();
            label_password = new Label();
            label_username = new Label();
            btn_shutdown = new Button();
            pictureBox_logo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).BeginInit();
            SuspendLayout();
            // 
            // label_loginTitle
            // 
            label_loginTitle.AutoSize = true;
            label_loginTitle.Font = new Font("Microsoft Sans Serif", 28.125F, FontStyle.Bold, GraphicsUnit.Point);
            label_loginTitle.ForeColor = Color.MediumTurquoise;
            label_loginTitle.Location = new Point(670, 483);
            label_loginTitle.Name = "label_loginTitle";
            label_loginTitle.Size = new Size(602, 85);
            label_loginTitle.TabIndex = 2;
            label_loginTitle.Text = "LIFE CHANGER";
            label_loginTitle.Click += label1_Click;
            // 
            // label_answer_username
            // 
            label_answer_username.BackColor = Color.Gainsboro;
            label_answer_username.Location = new Point(837, 636);
            label_answer_username.Name = "label_answer_username";
            label_answer_username.Size = new Size(450, 55);
            label_answer_username.TabIndex = 18;
            // 
            // label_answer_password
            // 
            label_answer_password.BackColor = Color.Gainsboro;
            label_answer_password.Location = new Point(837, 712);
            label_answer_password.Name = "label_answer_password";
            label_answer_password.Size = new Size(450, 55);
            label_answer_password.TabIndex = 17;
            // 
            // label_password
            // 
            label_password.Font = new Font("Gill Sans MT Condensed", 19.875F, FontStyle.Regular, GraphicsUnit.Point);
            label_password.ForeColor = Color.White;
            label_password.Location = new Point(631, 712);
            label_password.Name = "label_password";
            label_password.Size = new Size(200, 55);
            label_password.TabIndex = 16;
            label_password.Text = "Password";
            label_password.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_username
            // 
            label_username.Font = new Font("Gill Sans MT Condensed", 19.875F, FontStyle.Regular, GraphicsUnit.Point);
            label_username.ForeColor = Color.White;
            label_username.Location = new Point(631, 636);
            label_username.Name = "label_username";
            label_username.Size = new Size(200, 55);
            label_username.TabIndex = 15;
            label_username.Text = "Username";
            label_username.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn_shutdown
            // 
            btn_shutdown.BackColor = Color.FromArgb(94, 94, 94);
            btn_shutdown.FlatAppearance.BorderSize = 0;
            btn_shutdown.FlatStyle = FlatStyle.Flat;
            btn_shutdown.Image = (Image)resources.GetObject("btn_shutdown.Image");
            btn_shutdown.Location = new Point(1740, 805);
            btn_shutdown.Name = "btn_shutdown";
            btn_shutdown.Size = new Size(125, 125);
            btn_shutdown.TabIndex = 19;
            btn_shutdown.UseVisualStyleBackColor = false;
            // 
            // pictureBox_logo
            // 
            pictureBox_logo.Image = (Image)resources.GetObject("pictureBox_logo.Image");
            pictureBox_logo.Location = new Point(674, 12);
            pictureBox_logo.Name = "pictureBox_logo";
            pictureBox_logo.Size = new Size(613, 384);
            pictureBox_logo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo.TabIndex = 1;
            pictureBox_logo.TabStop = false;
            // 
            // Login
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(94, 94, 94);
            ClientSize = new Size(1894, 953);
            Controls.Add(btn_shutdown);
            Controls.Add(label_answer_username);
            Controls.Add(label_answer_password);
            Controls.Add(label_password);
            Controls.Add(label_username);
            Controls.Add(label_loginTitle);
            Controls.Add(pictureBox_logo);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label_loginTitle;
        private Label label_answer_username;
        private Label label_answer_password;
        private Label label_password;
        private Label label_username;
        private Button btn_shutdown;
        private PictureBox pictureBox_logo;
    }
}