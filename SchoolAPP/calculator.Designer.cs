namespace gestao
{
    partial class Calculator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator));
            label_calc_startDate = new Label();
            label_calc_endDate = new Label();
            label_days = new Label();
            label_answer_startDate = new DateTimePicker();
            label_answer_endDate = new DateTimePicker();
            label_answer_days = new Label();
            label_answer_salary = new Label();
            label_salary = new Label();
            pictureBox_logo = new PictureBox();
            label_pageTitle = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).BeginInit();
            SuspendLayout();
            // 
            // label_calc_startDate
            // 
            label_calc_startDate.Font = new Font("Microsoft Sans Serif", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            label_calc_startDate.ForeColor = Color.White;
            label_calc_startDate.Location = new Point(257, 220);
            label_calc_startDate.Margin = new Padding(2, 0, 2, 0);
            label_calc_startDate.Name = "label_calc_startDate";
            label_calc_startDate.Size = new Size(250, 57);
            label_calc_startDate.TabIndex = 9;
            label_calc_startDate.Text = "Start Date";
            label_calc_startDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_calc_endDate
            // 
            label_calc_endDate.Font = new Font("Microsoft Sans Serif", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            label_calc_endDate.ForeColor = Color.White;
            label_calc_endDate.Location = new Point(956, 220);
            label_calc_endDate.Margin = new Padding(2, 0, 2, 0);
            label_calc_endDate.Name = "label_calc_endDate";
            label_calc_endDate.Size = new Size(250, 57);
            label_calc_endDate.TabIndex = 10;
            label_calc_endDate.Text = "End Date";
            label_calc_endDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_days
            // 
            label_days.Font = new Font("Microsoft Sans Serif", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            label_days.ForeColor = Color.White;
            label_days.Location = new Point(257, 379);
            label_days.Margin = new Padding(2, 0, 2, 0);
            label_days.Name = "label_days";
            label_days.Size = new Size(250, 57);
            label_days.TabIndex = 11;
            label_days.Text = "Nº Days";
            label_days.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_answer_startDate
            // 
            label_answer_startDate.BackColor = Color.FromArgb(224, 224, 224);
            label_answer_startDate.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            label_answer_startDate.Location = new Point(512, 220);
            label_answer_startDate.Name = "label_answer_startDate";
            label_answer_startDate.Size = new Size(300, 57);
            label_answer_startDate.TabIndex = 12;
            // 
            // label_answer_endDate
            // 
            label_answer_endDate.BackColor = Color.FromArgb(224, 224, 224);
            label_answer_endDate.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            label_answer_endDate.Location = new Point(1211, 220);
            label_answer_endDate.Name = "label_answer_endDate";
            label_answer_endDate.Size = new Size(300, 57);
            label_answer_endDate.TabIndex = 13;
            // 
            // label_answer_days
            // 
            label_answer_days.BackColor = Color.FromArgb(224, 224, 224);
            label_answer_days.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            label_answer_days.Location = new Point(512, 379);
            label_answer_days.Name = "label_answer_days";
            label_answer_days.Size = new Size(300, 57);
            label_answer_days.TabIndex = 14;
            // 
            // label_answer_salary
            // 
            label_answer_salary.BackColor = Color.FromArgb(224, 224, 224);
            label_answer_salary.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            label_answer_salary.Location = new Point(906, 608);
            label_answer_salary.Name = "label_answer_salary";
            label_answer_salary.Size = new Size(300, 57);
            label_answer_salary.TabIndex = 15;
            label_answer_salary.Click += label_answer_salary_Click;
            // 
            // label_salary
            // 
            label_salary.Font = new Font("Microsoft Sans Serif", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            label_salary.ForeColor = Color.White;
            label_salary.Location = new Point(597, 608);
            label_salary.Margin = new Padding(2, 0, 2, 0);
            label_salary.Name = "label_salary";
            label_salary.Size = new Size(300, 57);
            label_salary.TabIndex = 16;
            label_salary.Text = "Salary";
            label_salary.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox_logo
            // 
            pictureBox_logo.Image = (Image)resources.GetObject("pictureBox_logo.Image");
            pictureBox_logo.Location = new Point(30, 30);
            pictureBox_logo.Margin = new Padding(3, 2, 3, 2);
            pictureBox_logo.Name = "pictureBox_logo";
            pictureBox_logo.Size = new Size(125, 125);
            pictureBox_logo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo.TabIndex = 21;
            pictureBox_logo.TabStop = false;
            // 
            // label_pageTitle
            // 
            label_pageTitle.AutoSize = true;
            label_pageTitle.Font = new Font("Microsoft Sans Serif", 16.125F, FontStyle.Bold, GraphicsUnit.Point);
            label_pageTitle.ForeColor = Color.MediumTurquoise;
            label_pageTitle.Location = new Point(160, 65);
            label_pageTitle.Margin = new Padding(4, 0, 4, 0);
            label_pageTitle.Name = "label_pageTitle";
            label_pageTitle.Size = new Size(321, 51);
            label_pageTitle.TabIndex = 22;
            label_pageTitle.Text = "CALCULATOR";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(94, 94, 94);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(1781, 842);
            button1.Margin = new Padding(4, 2, 4, 2);
            button1.Name = "button1";
            button1.Size = new Size(100, 100);
            button1.TabIndex = 62;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(94, 94, 94);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(1676, 842);
            button2.Margin = new Padding(4, 2, 4, 2);
            button2.Name = "button2";
            button2.Size = new Size(100, 100);
            button2.TabIndex = 61;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(94, 94, 94);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(1569, 842);
            button3.Margin = new Padding(4, 2, 4, 2);
            button3.Name = "button3";
            button3.Size = new Size(100, 100);
            button3.TabIndex = 60;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // Calculator
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(94, 94, 94);
            ClientSize = new Size(1894, 953);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(label_pageTitle);
            Controls.Add(pictureBox_logo);
            Controls.Add(label_salary);
            Controls.Add(label_answer_salary);
            Controls.Add(label_answer_days);
            Controls.Add(label_answer_endDate);
            Controls.Add(label_answer_startDate);
            Controls.Add(label_days);
            Controls.Add(label_calc_endDate);
            Controls.Add(label_calc_startDate);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "Calculator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculator";
            FormClosed += closesw;
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label_calc_startDate;
        private Label label_calc_endDate;
        private Label label_days;
        private DateTimePicker label_answer_startDate;
        private DateTimePicker label_answer_endDate;
        private Label label_answer_days;
        private Label label_answer_salary;
        private Label label_salary;
        private PictureBox pictureBox_logo;
        private Label label_pageTitle;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}