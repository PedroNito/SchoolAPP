using gestao.classes.Models;

namespace gestao
{
    partial class addEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addEmployee));
            label_pageTitle = new Label();
            btn_back = new Button();
            btn_broom = new Button();
            btn_check = new Button();
            label_name = new Label();
            label_address = new Label();
            label_contact = new Label();
            label_department = new Label();
            label_criminalRecordEnd = new Label();
            label_contractEnd = new Label();
            textBoxCriminalRecordDate = new DateTimePicker();
            textBoxContractEnd = new DateTimePicker();
            textBoxAddress = new TextBox();
            textBoxName = new TextBox();
            textBoxContact = new TextBox();
            comboBox_department = new ComboBox();
            painelCustomFields = new Panel();
            pictureBox_logo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).BeginInit();
            SuspendLayout();
            // 
            // label_pageTitle
            // 
            label_pageTitle.AutoSize = true;
            label_pageTitle.Font = new Font("Microsoft Sans Serif", 16.125F, FontStyle.Bold, GraphicsUnit.Point);
            label_pageTitle.ForeColor = Color.MediumTurquoise;
            label_pageTitle.Location = new Point(160, 65);
            label_pageTitle.Name = "label_pageTitle";
            label_pageTitle.Size = new Size(374, 51);
            label_pageTitle.TabIndex = 1;
            label_pageTitle.Text = "ADD EMPLOYEE";
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.FromArgb(94, 94, 94);
            btn_back.FlatAppearance.BorderSize = 0;
            btn_back.FlatStyle = FlatStyle.Flat;
            btn_back.Image = (Image)resources.GetObject("btn_back.Image");
            btn_back.Location = new Point(1569, 842);
            btn_back.Margin = new Padding(3, 2, 3, 2);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(85, 85);
            btn_back.TabIndex = 2;
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;
            // 
            // btn_broom
            // 
            btn_broom.BackColor = Color.FromArgb(94, 94, 94);
            btn_broom.FlatAppearance.BorderSize = 0;
            btn_broom.FlatStyle = FlatStyle.Flat;
            btn_broom.Image = (Image)resources.GetObject("btn_broom.Image");
            btn_broom.Location = new Point(1676, 842);
            btn_broom.Margin = new Padding(3, 2, 3, 2);
            btn_broom.Name = "btn_broom";
            btn_broom.Size = new Size(85, 85);
            btn_broom.TabIndex = 3;
            btn_broom.UseVisualStyleBackColor = false;
            btn_broom.Click += btn_broom_Click;
            // 
            // btn_check
            // 
            btn_check.BackColor = Color.FromArgb(94, 94, 94);
            btn_check.FlatAppearance.BorderSize = 0;
            btn_check.FlatStyle = FlatStyle.Flat;
            btn_check.Image = (Image)resources.GetObject("btn_check.Image");
            btn_check.Location = new Point(1781, 842);
            btn_check.Margin = new Padding(3, 2, 3, 2);
            btn_check.Name = "btn_check";
            btn_check.Size = new Size(85, 85);
            btn_check.TabIndex = 4;
            btn_check.UseVisualStyleBackColor = false;
            btn_check.Click += btn_check_Click;
            // 
            // label_name
            // 
            label_name.Font = new Font("Microsoft Sans Serif", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            label_name.ForeColor = Color.White;
            label_name.Location = new Point(200, 145);
            label_name.Name = "label_name";
            label_name.Size = new Size(284, 57);
            label_name.TabIndex = 5;
            label_name.Text = "Name";
            label_name.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_address
            // 
            label_address.Font = new Font("Microsoft Sans Serif", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            label_address.ForeColor = Color.White;
            label_address.Location = new Point(200, 212);
            label_address.Name = "label_address";
            label_address.Size = new Size(284, 57);
            label_address.TabIndex = 6;
            label_address.Text = "Address";
            label_address.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_contact
            // 
            label_contact.Font = new Font("Microsoft Sans Serif", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            label_contact.ForeColor = Color.White;
            label_contact.Location = new Point(199, 280);
            label_contact.Name = "label_contact";
            label_contact.Size = new Size(284, 57);
            label_contact.TabIndex = 7;
            label_contact.Text = "Contact";
            label_contact.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_department
            // 
            label_department.Font = new Font("Microsoft Sans Serif", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            label_department.ForeColor = Color.White;
            label_department.Location = new Point(200, 350);
            label_department.Name = "label_department";
            label_department.Size = new Size(284, 57);
            label_department.TabIndex = 8;
            label_department.Text = "Department";
            label_department.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_criminalRecordEnd
            // 
            label_criminalRecordEnd.Font = new Font("Microsoft Sans Serif", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            label_criminalRecordEnd.ForeColor = Color.White;
            label_criminalRecordEnd.Location = new Point(198, 748);
            label_criminalRecordEnd.Name = "label_criminalRecordEnd";
            label_criminalRecordEnd.Size = new Size(285, 57);
            label_criminalRecordEnd.TabIndex = 9;
            label_criminalRecordEnd.Text = "Criminal Record End";
            label_criminalRecordEnd.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label_contractEnd
            // 
            label_contractEnd.Font = new Font("Microsoft Sans Serif", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            label_contractEnd.ForeColor = Color.White;
            label_contractEnd.Location = new Point(198, 679);
            label_contractEnd.Name = "label_contractEnd";
            label_contractEnd.Size = new Size(285, 57);
            label_contractEnd.TabIndex = 10;
            label_contractEnd.Text = "Contract End";
            label_contractEnd.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxCriminalRecordDate
            // 
            textBoxCriminalRecordDate.BackColor = Color.Gainsboro;
            textBoxCriminalRecordDate.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxCriminalRecordDate.Location = new Point(489, 750);
            textBoxCriminalRecordDate.Margin = new Padding(3, 0, 3, 0);
            textBoxCriminalRecordDate.Name = "textBoxCriminalRecordDate";
            textBoxCriminalRecordDate.RightToLeft = RightToLeft.No;
            textBoxCriminalRecordDate.Size = new Size(400, 32);
            textBoxCriminalRecordDate.TabIndex = 11;
            // 
            // textBoxContractEnd
            // 
            textBoxContractEnd.BackColor = Color.Gainsboro;
            textBoxContractEnd.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxContractEnd.Location = new Point(489, 681);
            textBoxContractEnd.Margin = new Padding(3, 0, 3, 0);
            textBoxContractEnd.Name = "textBoxContractEnd";
            textBoxContractEnd.Size = new Size(400, 32);
            textBoxContractEnd.TabIndex = 12;
            // 
            // textBoxAddress
            // 
            textBoxAddress.BackColor = Color.Gainsboro;
            textBoxAddress.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxAddress.Location = new Point(490, 214);
            textBoxAddress.Margin = new Padding(3, 0, 3, 0);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(1114, 57);
            textBoxAddress.TabIndex = 13;
            textBoxAddress.TextChanged += textBoxAddress_TextChanged;
            // 
            // textBoxName
            // 
            textBoxName.BackColor = Color.Gainsboro;
            textBoxName.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxName.Location = new Point(490, 145);
            textBoxName.Margin = new Padding(3, 0, 3, 0);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(1114, 57);
            textBoxName.TabIndex = 14;
            // 
            // textBoxContact
            // 
            textBoxContact.BackColor = Color.Gainsboro;
            textBoxContact.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxContact.Location = new Point(489, 282);
            textBoxContact.Margin = new Padding(3, 0, 3, 0);
            textBoxContact.Name = "textBoxContact";
            textBoxContact.Size = new Size(1114, 57);
            textBoxContact.TabIndex = 15;
            // 
            // comboBox_department
            // 
            comboBox_department.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_department.Font = new Font("Segoe UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            comboBox_department.FormattingEnabled = true;
            comboBox_department.ImeMode = ImeMode.Off;
            comboBox_department.Items.AddRange(new object[] { "Choose your Department", "Director", "Coordinator", "Trainer", "Secretary" });
            comboBox_department.Location = new Point(490, 350);
            comboBox_department.Margin = new Padding(3, 2, 3, 2);
            comboBox_department.Name = "comboBox_department";
            comboBox_department.Size = new Size(1114, 58);
            comboBox_department.TabIndex = 16;
            comboBox_department.SelectedIndexChanged += comboBox_department_SelectedIndexChanged;
            // 
            // painelCustomFields
            // 
            painelCustomFields.Location = new Point(198, 431);
            painelCustomFields.Margin = new Padding(6);
            painelCustomFields.Name = "painelCustomFields";
            painelCustomFields.Size = new Size(1405, 233);
            painelCustomFields.TabIndex = 17;
            painelCustomFields.Paint += painelCustomFields_Paint;
            // 
            // pictureBox_logo
            // 
            pictureBox_logo.Image = (Image)resources.GetObject("pictureBox_logo.Image");
            pictureBox_logo.Location = new Point(30, 30);
            pictureBox_logo.Margin = new Padding(3, 2, 3, 2);
            pictureBox_logo.Name = "pictureBox_logo";
            pictureBox_logo.Size = new Size(125, 125);
            pictureBox_logo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_logo.TabIndex = 18;
            pictureBox_logo.TabStop = false;
            // 
            // addEmployee
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(94, 94, 94);
            ClientSize = new Size(1894, 953);
            Controls.Add(textBoxName);
            Controls.Add(pictureBox_logo);
            Controls.Add(painelCustomFields);
            Controls.Add(comboBox_department);
            Controls.Add(textBoxContact);
            Controls.Add(textBoxAddress);
            Controls.Add(textBoxContractEnd);
            Controls.Add(textBoxCriminalRecordDate);
            Controls.Add(label_contractEnd);
            Controls.Add(label_criminalRecordEnd);
            Controls.Add(label_department);
            Controls.Add(label_contact);
            Controls.Add(label_address);
            Controls.Add(label_name);
            Controls.Add(btn_check);
            Controls.Add(btn_broom);
            Controls.Add(btn_back);
            Controls.Add(label_pageTitle);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2, 1, 2, 1);
            Name = "addEmployee";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Add Employee";
            FormClosed += closesw;
            ((System.ComponentModel.ISupportInitialize)pictureBox_logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label_pageTitle;
        private Button btn_back;
        private Button btn_broom;
        private Button btn_check;
        private Label label_name;
        private Label label_address;
        private Label label_contact;
        private Label label_department;
        private Label label_criminalRecordEnd;
        private Label label_contractEnd;
        private DateTimePicker textBoxCriminalRecordDate;
        private DateTimePicker textBoxContractEnd;
        private TextBox textBoxAddress;
        private TextBox textBoxName;
        private TextBox textBoxContact;
        private ComboBox comboBox_department;
        private Panel painelCustomFields;
        private PictureBox pictureBox_logo;
    }
}