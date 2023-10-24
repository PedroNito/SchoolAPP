namespace gestao
{
    partial class mainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainMenu));
            pictureBox_logo = new PictureBox();
            label_pageTitle = new Label();
            btn_foward = new Button();
            btn_back = new Button();
            label_todayDate = new Label();
            btn_addEmployee = new Button();
            btn_download = new Button();
            btn_calendar = new Button();
            btn_calculator = new Button();
            btn_warning = new Button();
            btn_exit = new Button();
            btn_expiredList = new Button();
            circularLabel_warningList = new classes.customElements.CircularLabel();
            circularLabel_expiredList = new classes.customElements.CircularLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).BeginInit();
            SuspendLayout();
            // 
            // pictureBox_logo
            // 
            pictureBox_logo.Image = (Image)resources.GetObject("pictureBox_logo.Image");
            pictureBox_logo.Location = new Point(30, 30);
            pictureBox_logo.Margin = new Padding(3, 2, 3, 2);
            pictureBox_logo.Name = "pictureBox_logo";
            pictureBox_logo.Size = new Size(125, 125);
            pictureBox_logo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo.TabIndex = 1;
            pictureBox_logo.TabStop = false;
            // 
            // label_pageTitle
            // 
            label_pageTitle.AutoSize = true;
            label_pageTitle.Font = new Font("Microsoft Sans Serif", 16.125F, FontStyle.Bold, GraphicsUnit.Point);
            label_pageTitle.ForeColor = Color.MediumTurquoise;
            label_pageTitle.Location = new Point(160, 65);
            label_pageTitle.Name = "label_pageTitle";
            label_pageTitle.Size = new Size(277, 51);
            label_pageTitle.TabIndex = 4;
            label_pageTitle.Text = "MAIN MENU";
            label_pageTitle.Click += label_pageTitle_Click;
            // 
            // btn_foward
            // 
            btn_foward.BackColor = Color.FromArgb(94, 94, 94);
            btn_foward.FlatAppearance.BorderSize = 0;
            btn_foward.FlatStyle = FlatStyle.Flat;
            btn_foward.Image = (Image)resources.GetObject("btn_foward.Image");
            btn_foward.Location = new Point(1086, 825);
            btn_foward.Margin = new Padding(5, 6, 5, 6);
            btn_foward.Name = "btn_foward";
            btn_foward.Size = new Size(85, 85);
            btn_foward.TabIndex = 6;
            btn_foward.UseVisualStyleBackColor = false;
            btn_foward.Click += btn_foward_Click;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.FromArgb(94, 94, 94);
            btn_back.FlatAppearance.BorderSize = 0;
            btn_back.FlatStyle = FlatStyle.Flat;
            btn_back.Image = (Image)resources.GetObject("btn_back.Image");
            btn_back.Location = new Point(731, 825);
            btn_back.Margin = new Padding(5, 6, 5, 6);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(85, 85);
            btn_back.TabIndex = 7;
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;
            // 
            // label_todayDate
            // 
            label_todayDate.Font = new Font("Segoe UI", 13.875F, FontStyle.Bold, GraphicsUnit.Point);
            label_todayDate.ForeColor = Color.White;
            label_todayDate.Location = new Point(826, 825);
            label_todayDate.Margin = new Padding(5, 0, 5, 0);
            label_todayDate.Name = "label_todayDate";
            label_todayDate.Size = new Size(250, 85);
            label_todayDate.TabIndex = 8;
            label_todayDate.Text = "12-12-2023";
            label_todayDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_addEmployee
            // 
            btn_addEmployee.BackColor = Color.FromArgb(94, 94, 94);
            btn_addEmployee.BackgroundImageLayout = ImageLayout.Zoom;
            btn_addEmployee.FlatAppearance.BorderSize = 0;
            btn_addEmployee.FlatStyle = FlatStyle.Flat;
            btn_addEmployee.Image = (Image)resources.GetObject("btn_addEmployee.Image");
            btn_addEmployee.Location = new Point(293, 194);
            btn_addEmployee.Margin = new Padding(3, 2, 3, 2);
            btn_addEmployee.Name = "btn_addEmployee";
            btn_addEmployee.Size = new Size(200, 200);
            btn_addEmployee.TabIndex = 9;
            btn_addEmployee.UseVisualStyleBackColor = false;
            btn_addEmployee.Click += btn_addEmployee_Click;
            // 
            // btn_download
            // 
            btn_download.BackColor = Color.FromArgb(94, 94, 94);
            btn_download.BackgroundImageLayout = ImageLayout.Zoom;
            btn_download.FlatAppearance.BorderSize = 0;
            btn_download.FlatStyle = FlatStyle.Flat;
            btn_download.Image = (Image)resources.GetObject("btn_download.Image");
            btn_download.Location = new Point(848, 194);
            btn_download.Margin = new Padding(3, 2, 3, 2);
            btn_download.Name = "btn_download";
            btn_download.Size = new Size(200, 200);
            btn_download.TabIndex = 12;
            btn_download.UseVisualStyleBackColor = false;
            btn_download.Click += btn_download_Click;
            // 
            // btn_calendar
            // 
            btn_calendar.BackColor = Color.FromArgb(94, 94, 94);
            btn_calendar.BackgroundImageLayout = ImageLayout.Zoom;
            btn_calendar.FlatAppearance.BorderSize = 0;
            btn_calendar.FlatStyle = FlatStyle.Flat;
            btn_calendar.Image = (Image)resources.GetObject("btn_calendar.Image");
            btn_calendar.Location = new Point(1363, 194);
            btn_calendar.Margin = new Padding(3, 2, 3, 2);
            btn_calendar.Name = "btn_calendar";
            btn_calendar.Size = new Size(200, 200);
            btn_calendar.TabIndex = 16;
            btn_calendar.UseVisualStyleBackColor = false;
            btn_calendar.Click += btn_calendar_Click;
            // 
            // btn_calculator
            // 
            btn_calculator.BackColor = Color.FromArgb(94, 94, 94);
            btn_calculator.BackgroundImageLayout = ImageLayout.Zoom;
            btn_calculator.FlatAppearance.BorderSize = 0;
            btn_calculator.FlatStyle = FlatStyle.Flat;
            btn_calculator.Image = (Image)resources.GetObject("btn_calculator.Image");
            btn_calculator.Location = new Point(1363, 475);
            btn_calculator.Margin = new Padding(3, 2, 3, 2);
            btn_calculator.Name = "btn_calculator";
            btn_calculator.Size = new Size(200, 200);
            btn_calculator.TabIndex = 15;
            btn_calculator.UseVisualStyleBackColor = false;
            btn_calculator.Click += btn_calculator_Click;
            // 
            // btn_warning
            // 
            btn_warning.BackColor = Color.FromArgb(94, 94, 94);
            btn_warning.BackgroundImageLayout = ImageLayout.Zoom;
            btn_warning.FlatAppearance.BorderSize = 0;
            btn_warning.FlatStyle = FlatStyle.Flat;
            btn_warning.Image = (Image)resources.GetObject("btn_warning.Image");
            btn_warning.Location = new Point(293, 475);
            btn_warning.Margin = new Padding(3, 2, 3, 2);
            btn_warning.Name = "btn_warning";
            btn_warning.Size = new Size(200, 200);
            btn_warning.TabIndex = 13;
            btn_warning.UseVisualStyleBackColor = false;
            btn_warning.Click += btn_warning_Click;
            // 
            // btn_exit
            // 
            btn_exit.BackColor = Color.FromArgb(94, 94, 94);
            btn_exit.BackgroundImageLayout = ImageLayout.Zoom;
            btn_exit.FlatAppearance.BorderSize = 0;
            btn_exit.FlatStyle = FlatStyle.Flat;
            btn_exit.Image = (Image)resources.GetObject("btn_exit.Image");
            btn_exit.Location = new Point(1743, 805);
            btn_exit.Margin = new Padding(3, 2, 3, 2);
            btn_exit.Name = "btn_exit";
            btn_exit.Size = new Size(125, 125);
            btn_exit.TabIndex = 17;
            btn_exit.UseVisualStyleBackColor = false;
            btn_exit.Click += btn_exit_Click;
            // 
            // btn_expiredList
            // 
            btn_expiredList.BackColor = Color.FromArgb(94, 94, 94);
            btn_expiredList.BackgroundImageLayout = ImageLayout.Zoom;
            btn_expiredList.FlatAppearance.BorderSize = 0;
            btn_expiredList.FlatStyle = FlatStyle.Flat;
            btn_expiredList.Image = (Image)resources.GetObject("btn_expiredList.Image");
            btn_expiredList.Location = new Point(848, 475);
            btn_expiredList.Margin = new Padding(3, 2, 3, 2);
            btn_expiredList.Name = "btn_expiredList";
            btn_expiredList.Size = new Size(200, 200);
            btn_expiredList.TabIndex = 14;
            btn_expiredList.UseVisualStyleBackColor = false;
            btn_expiredList.Click += btn_expiredList_Click;
            // 
            // circularLabel_warningList
            // 
            circularLabel_warningList.AutoSize = true;
            circularLabel_warningList.BackColor = Color.Red;
            circularLabel_warningList.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            circularLabel_warningList.ForeColor = Color.White;
            circularLabel_warningList.Location = new Point(440, 444);
            circularLabel_warningList.MinimumSize = new Size(77, 75);
            circularLabel_warningList.Name = "circularLabel_warningList";
            circularLabel_warningList.Size = new Size(121, 75);
            circularLabel_warningList.TabIndex = 19;
            circularLabel_warningList.Text = "1000";
            circularLabel_warningList.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // circularLabel_expiredList
            // 
            circularLabel_expiredList.AutoSize = true;
            circularLabel_expiredList.BackColor = Color.Red;
            circularLabel_expiredList.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            circularLabel_expiredList.ForeColor = Color.White;
            circularLabel_expiredList.Location = new Point(999, 444);
            circularLabel_expiredList.MinimumSize = new Size(77, 75);
            circularLabel_expiredList.Name = "circularLabel_expiredList";
            circularLabel_expiredList.Size = new Size(121, 75);
            circularLabel_expiredList.TabIndex = 20;
            circularLabel_expiredList.Text = "1000";
            circularLabel_expiredList.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mainMenu
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoScroll = true;
            BackColor = Color.FromArgb(94, 94, 94);
            ClientSize = new Size(1894, 953);
            Controls.Add(circularLabel_expiredList);
            Controls.Add(circularLabel_warningList);
            Controls.Add(btn_exit);
            Controls.Add(btn_calendar);
            Controls.Add(btn_calculator);
            Controls.Add(btn_expiredList);
            Controls.Add(btn_warning);
            Controls.Add(btn_download);
            Controls.Add(btn_addEmployee);
            Controls.Add(label_todayDate);
            Controls.Add(btn_back);
            Controls.Add(btn_foward);
            Controls.Add(label_pageTitle);
            Controls.Add(pictureBox_logo);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "mainMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main Menu";
            Load += mainMenu_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox_logo;
        private Label label_pageTitle;
        private Button btn_foward;
        private Button btn_back;
        private Label label_todayDate;
        private Button btn_addEmployee;
        private Button btn_download;
        private Button btn_calendar;
        private Button btn_calculator;
        private Button btn_warning;
        private Button btn_exit;
        private Button btn_expiredList;
        private classes.customElements.CircularLabel circularLabel_warningList;
        private classes.customElements.CircularLabel circularLabel_expiredList;
    }
}