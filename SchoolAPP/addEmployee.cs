
using gestao.classes;
using gestao.classes.controlls;
using gestao.classes.interfaces;
using gestao.classes.internalStruct;
using gestao.classes.Models;
using gestao.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.DataFormats;

namespace gestao
{
    public partial class addEmployee : Form
    {
        private Dictionary<String, Control> customFields;
        public ListEmployees _parent;

        private Employee employee;
        public addEmployee(ListEmployees parentPage, string title, Employee employee = null)
        {
            InitializeComponent();
            _parent = parentPage;
            this.employee = employee;
            this.label_pageTitle.Text = title;


            if (label_pageTitle.Text == "SHOW EMPLOYEE")
            {
                btn_broom.Visible = false;
                btn_check.Visible = false;
            }
            if (employee != null)
            {

                comboBox_department.Enabled = false;

                textBoxName.Text = employee.Name;

                textBoxAddress.Text = employee.Address;

                textBoxCriminalRecordDate.Text = employee.CriminaRecord.ToString();
                textBoxCriminalRecordDate.MinDate = DateTime.Parse(employee.CriminaRecord.ToString());

                textBoxContractEnd.Text = employee.EndContract.ToString();
                textBoxContractEnd.MinDate = DateTime.Parse(employee.EndContract.ToString());

                textBoxContact.Text = employee.Contact;



                if (employee.GetType() == new Former().GetType())
                {
                    comboBox_department.Text = "Trainer";
                }
                if (employee.GetType() == new Secretary().GetType())
                {
                    comboBox_department.Text = "Secretary";
                }
                if (employee.GetType() == new Director().GetType())
                {
                    comboBox_department.Text = "Director";
                }
                if (employee.GetType() == new Coordinator().GetType())
                {
                    comboBox_department.Text = "Coordinator";
                }

                comboBox_department_SelectedIndexChanged(null, null);
            } else
            {


                this.textBoxContractEnd.MinDate = DateTime.Parse(Company.getCurrentDate());
                this.textBoxCriminalRecordDate.MinDate = DateTime.Parse(Company.getCurrentDate());
            }
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            Request request = new Request(this);
            Response response;

            request.Fields.Add("Name", textBoxName.Text);
            request.Fields.Add("Address", textBoxAddress.Text);
            request.Fields.Add("Contact", textBoxContact.Text);
            request.Fields.Add("ContractEnd", textBoxContractEnd.Value.ToString());
            request.Fields.Add("CriminalRecordDate", textBoxCriminalRecordDate.Value.ToString());
            Control value;
            IControll controll = null;

            response = new Response(500);

            response.data = Employee.staticInputValidate(request);
            if (response.data != "")
            {

                MessageBox.Show(response.data, "Error");
                return;
            }
            switch (comboBox_department.Text)
            {
                case "Director":
                    controll = new DirectorControll();
                    this.customFields.TryGetValue("salaryBonus", out value);
                    request.Fields.Add("salaryBonus", value.Text);

                    this.customFields.TryGetValue("carSelect", out value);
                    request.Fields.Add("carSelect", value.Text);

                    this.customFields.TryGetValue("timeExemption", out value);
                    request.Fields.Add("timeExemption", value.Text);



                    break;
                case "Coordinator":

                    controll = new CoordinatorControll();
                    Control selectFormerControl;
                    ListBox selectFormer;
                    this.customFields.TryGetValue("selectFormer", out selectFormerControl);
                    selectFormer = (ListBox)selectFormerControl;
                    string formersIds = "";
                    int i = 1;

                    if (selectFormer.Items.Count == 0)
                    {
                        MessageBox.Show("Please, choose a trainer!", "Error");
                        return;
                    }

                    foreach (int index in selectFormer.SelectedIndices)
                    {
                        Former former = (Former)selectFormer.Items[index];
                        formersIds += former.Id.ToString();

                        if (i != selectFormer.SelectedIndices.Count)
                        {
                            formersIds += ";";
                        }
                        i++;

                    }
                    request.Fields.Add("formers", formersIds);
                    break;
                case "Trainer":

                    controll = new FormerControll();

                    this.customFields.TryGetValue("areaTaught", out value);
                    request.Fields.Add("areaTaught", value.Text);

                    this.customFields.TryGetValue("availability", out value);
                    request.Fields.Add("availability", value.Text);

                    this.customFields.TryGetValue("hourValue", out value);
                    request.Fields.Add("hourValue", value.Text);

                    break;
                case "Secretary":

                    controll = new SecretaryControll();

                    this.customFields.TryGetValue("director", out value);
                    ComboBox value2 = (ComboBox)value;


                    if (value2.SelectedIndex == -1)
                    {
                        MessageBox.Show("Please, choose the director!\n", "Error");
                        return;

                    }

                    Director director = (Director)value2.Items[value2.SelectedIndex];
                    request.Fields.Add("director", director.Id.ToString());

                    this.customFields.TryGetValue("area", out value);
                    request.Fields.Add("area", value.Text);


                    break;
                default:
                    response.data = "Please, choose a department!";
                    break;
            }


            if (controll != null && response.data == "")
            {
                if (this.employee == null)
                    response = controll.create(request);
                else
                    response = controll.update(request, this.employee);
            }
            if (response.code == 400)
            {
                this._parent.loadData(Company.GetCompany());
                this._parent.Show();

                this.Close();

                if (this.employee == null)
                    MessageBox.Show($"{comboBox_department.Text} Add", "Sucess");
                else
                    MessageBox.Show($"{comboBox_department.Text} Edit", "Sucess");

                return;
            }
            MessageBox.Show(response.data, "Error");
        }

        private void btn_broom_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            textBoxAddress.Text = "";
            textBoxContact.Text = "";
            textBoxCriminalRecordDate.Text = "";
            textBoxCriminalRecordDate.Text = "";
            comboBox_department.SelectedIndex = 0;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            _parent.Show();
            this.Close();
        }

        private void comboBox_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.customFields = new Dictionary<string, Control>();
            painelCustomFields.Controls.Clear();
            switch (comboBox_department.Text)
            {
                case "Director":
                    TextBox salaryBonus = new TextBox();
                    salaryBonus.Location = new Point(943, 28);
                    salaryBonus.Name = "comboBox_answer_salaryBonus";
                    salaryBonus.Size = new Size(250, 58);
                    salaryBonus.TabIndex = 20;
                    salaryBonus.Font = new Font("Segoe UI", 14);

                    if (employee != null)
                    {
                        var director = (Director)this.employee;
                        salaryBonus.Text = director.salaryBonus.ToString();
                    }

                    Label salaryBonusLable = new Label();
                    salaryBonusLable.Font = new Font("Microsoft Sans Serif", 16);
                    salaryBonusLable.ForeColor = Color.White;
                    salaryBonusLable.Location = new Point(652, 28);
                    salaryBonusLable.Margin = new Padding(2, 0, 2, 0);
                    salaryBonusLable.Name = "lable_salaryBonus";
                    salaryBonusLable.Size = new Size(285, 57);
                    salaryBonusLable.TabIndex = 19;
                    salaryBonusLable.Text = "Salary Bonus";
                    salaryBonusLable.TextAlign = ContentAlignment.MiddleLeft;

                    ComboBox carSelect = new ComboBox();
                    carSelect.Location = new Point(290, 28);
                    carSelect.Name = "textBoxdirector";
                    carSelect.Size = new Size(250, 58);
                    carSelect.TabIndex = 20;
                    carSelect.Font = new Font("Segoe UI", 14);
                    carSelect.Items.Add("Yes");
                    carSelect.Items.Add("No");
                    carSelect.DropDownStyle = ComboBoxStyle.DropDownList;
                    Label carSelectLable = new Label();
                    carSelectLable.Font = new Font("Microsoft Sans Serif", 16);
                    carSelectLable.ForeColor = Color.White;
                    carSelectLable.Location = new Point(0, 28);
                    carSelectLable.Margin = new Padding(2, 0, 2, 0);
                    carSelectLable.Name = "testelable";
                    carSelectLable.Size = new Size(285, 58);
                    carSelectLable.TabIndex = 19;
                    carSelectLable.Text = "Car Company";
                    carSelectLable.TextAlign = ContentAlignment.MiddleLeft;

                    ComboBox timeExemption = new ComboBox();
                    timeExemption.Location = new Point(291, 122);
                    timeExemption.Name = "textBoxdirector";
                    timeExemption.Size = new Size(250, 58);
                    timeExemption.TabIndex = 20;
                    timeExemption.DropDownStyle = ComboBoxStyle.DropDownList;

                    timeExemption.Items.Add("Yes");
                    timeExemption.Items.Add("No");
                    timeExemption.Font = new Font("Segoe UI", 14);
                    Label timeExemptionLable = new Label();
                    timeExemptionLable.Font = new Font("Microsoft Sans Serif", 16);
                    timeExemptionLable.ForeColor = Color.White;
                    timeExemptionLable.Location = new Point(0, 122);
                    timeExemptionLable.Margin = new Padding(2, 0, 2, 0);
                    timeExemptionLable.Name = "testelable";
                    timeExemptionLable.Size = new Size(285, 58);
                    timeExemptionLable.TabIndex = 19;
                    timeExemptionLable.Text = "Time Exemption";
                    timeExemptionLable.TextAlign = ContentAlignment.MiddleLeft;


                    if (label_pageTitle.Text == "SHOW EMPLOYEE")
                    {
                        textBoxName.Enabled = false; 
                        textBoxAddress.Enabled = false; 
                        textBoxContractEnd.Enabled = false; 
                        textBoxCriminalRecordDate.Enabled = false;
                        textBoxContact.Enabled = false;
                        salaryBonus.Enabled = false;
                        carSelect.Enabled = false;
                        timeExemption.Enabled = false;

                    }
                    painelCustomFields.Controls.AddRange(new Control[] {
                        salaryBonus,
                        salaryBonusLable,
                        carSelectLable,
                        carSelect,
                        timeExemption,
                        timeExemptionLable
                    });

                    if (this.employee != null)
                    {
                        Director director = (Director)this.employee;

                        salaryBonus.Text = director.salaryBonus.ToString();
                        timeExemption.Text = director.timeExemption ? "Yes" : "No";
                        carSelect.Text = director.car ? "Yes" : "No";
                    }
                    this.customFields.Add("salaryBonus", salaryBonus);
                    this.customFields.Add("carSelect", carSelect);
                    this.customFields.Add("timeExemption", timeExemption);
                    break;
                case "Coordinator":

                    ListBox Former = new ListBox();
                    Former.Location = new Point(292, 28);
                    Former.Name = "ListBoxdirector";
                    Former.Size = new Size(350, 165);
                    Former.TabIndex = 20;
                    Former.Font = new Font("Segoe UI", 13);
                    Former.DataSource = new Former().get();

                    Former.DisplayMember = "Name";
                    Former.ValueMember = "Id";
                    Former.MultiColumn = false;
                    Former.ScrollAlwaysVisible = true;
                    Former.SelectionMode = SelectionMode.MultiExtended;

                    this.customFields.Add("showFormer", Former);

                    Button BrigdeBtn = new Button();
                    BrigdeBtn.BackColor = Color.FromArgb(94, 94, 94);
                    BrigdeBtn.FlatAppearance.BorderSize = 0;
                    BrigdeBtn.FlatStyle = FlatStyle.Flat;
                    BrigdeBtn.Location = new Point(705, 65);
                    BrigdeBtn.Name = "formerCheck";
                    BrigdeBtn.Size = new Size(85, 85);
                    BrigdeBtn.TabIndex = 21;
                    BrigdeBtn.UseVisualStyleBackColor = false;
                    BrigdeBtn.BackgroundImage = System.Drawing.Image.FromFile(@"../../../Resources/formerCheck.png");
                    BrigdeBtn.BackgroundImageLayout = ImageLayout.Zoom;
                    BrigdeBtn.Click += btn_former_check;

                    ListBox Former1 = new ListBox();
                    Former1.Location = new Point(845, 28);
                    Former1.Name = "ListChecked";
                    Former1.Size = new Size(350, 165);
                    Former1.TabIndex = 22;
                    Former1.Font = new Font("Segoe UI", 14);
                    Former1.MultiColumn = false;
                    Former1.ScrollAlwaysVisible = true;
                    Former1.SelectionMode = SelectionMode.MultiExtended;

                    this.customFields.Add("selectFormer", Former1);

                    Label FormerLable = new Label();
                    FormerLable.Font = new Font("Microsoft Sans Serif", 16);
                    FormerLable.ForeColor = Color.White;
                    FormerLable.Location = new Point(0, 28);
                    FormerLable.Margin = new Padding(2, 0, 2, 0);
                    FormerLable.Name = "lable_former";
                    FormerLable.Size = new Size(285, 58);
                    FormerLable.TabIndex = 19;
                    FormerLable.Text = "Trainer";
                    FormerLable.TextAlign = ContentAlignment.MiddleLeft;



                    if (this.employee != null)
                    {
                        Coordinator coordinator = (Coordinator)this.employee;

                        Former1.DisplayMember = "Name";
                        Former1.ValueMember = "Id";
                        Former1.DataSource = coordinator.getTrainers();

                    }

                    if (label_pageTitle.Text == "SHOW EMPLOYEE")
                    {
                        textBoxName.Enabled = false;
                        textBoxAddress.Enabled = false;
                        textBoxContractEnd.Enabled = false;
                        textBoxCriminalRecordDate.Enabled = false;
                        textBoxContact.Enabled = false;
                        Former.Enabled = false;
                        Former1.Enabled = false;
                        BrigdeBtn.Enabled = false;

                    }
                    painelCustomFields.Controls.AddRange(new Control[] {
                        Former,
                        BrigdeBtn,
                        Former1,
                        FormerLable
                    });

                    break;
                case "Trainer":

                    TextBox hourValue = new TextBox();
                    hourValue.Location = new Point(292, 122);
                    hourValue.Name = "textBoxdirector";
                    hourValue.Size = new Size(250, 58);
                    hourValue.TabIndex = 20;
                    hourValue.Font = new Font("Segoe UI", 14);
                    Label hourValueLable = new Label();
                    hourValueLable.Font = new Font("Microsoft Sans Serif", 16);
                    hourValueLable.ForeColor = Color.White;
                    hourValueLable.Location = new Point(0, 122);
                    hourValueLable.Margin = new Padding(2, 0, 2, 0);
                    hourValueLable.Name = "testelable";
                    hourValueLable.Size = new Size(285, 58);
                    hourValueLable.TabIndex = 19;
                    hourValueLable.Text = "Value Hour";
                    hourValueLable.TextAlign = ContentAlignment.MiddleLeft;

                    TextBox areaTaught = new TextBox();
                    areaTaught.Location = new Point(292, 28);
                    areaTaught.Name = "textBoxdirector";
                    areaTaught.Size = new Size(250, 58);
                    areaTaught.TabIndex = 20;
                    areaTaught.Font = new Font("Segoe UI", 14);
                    Label areaTaughtLable = new Label();
                    areaTaughtLable.Font = new Font("Microsoft Sans Serif", 16);
                    areaTaughtLable.ForeColor = Color.White;
                    areaTaughtLable.Location = new Point(0, 28);
                    areaTaughtLable.Margin = new Padding(2, 0, 2, 0);
                    areaTaughtLable.Name = "testelable";
                    areaTaughtLable.Size = new Size(285, 58);
                    areaTaughtLable.TabIndex = 19;
                    areaTaughtLable.Text = "Area Taught";
                    areaTaughtLable.TextAlign = ContentAlignment.MiddleLeft;

                    ComboBox availability = new ComboBox();
                    availability.Location = new Point(934, 28);
                    availability.Name = "textBoxdirector";
                    availability.Size = new Size(250, 58);
                    availability.TabIndex = 20;
                    availability.Font = new Font("Segoe UI", 14);
                    availability.Items.Add("Day time");
                    availability.Items.Add("Night time");
                    availability.Items.Add("Both");
                    availability.DropDownStyle = ComboBoxStyle.DropDownList;
                    Label availabilityLable = new Label();
                    availabilityLable.Font = new Font("", 16);
                    availabilityLable.ForeColor = Color.White;
                    availabilityLable.Location = new Point(652, 28);
                    availabilityLable.Margin = new Padding(2, 0, 2, 0);
                    availabilityLable.Name = "testelable";
                    availabilityLable.Size = new Size(285, 58);
                    availabilityLable.TabIndex = 19;
                    availabilityLable.Text = "Availabity";
                    availabilityLable.TextAlign = ContentAlignment.MiddleLeft;

                    if (label_pageTitle.Text == "SHOW EMPLOYEE")
                    {
                        textBoxName.Enabled = false;
                        textBoxAddress.Enabled = false;
                        textBoxContractEnd.Enabled = false;
                        textBoxCriminalRecordDate.Enabled = false;
                        textBoxContact.Enabled = false;
                        hourValue.Enabled = false;
                        areaTaught.Enabled = false;
                        availability.Enabled = false;

                    }
                    painelCustomFields.Controls.AddRange(new Control[] {
                        hourValue,
                        hourValueLable,
                        areaTaught,
                        areaTaughtLable,
                        availability,
                        availabilityLable
                    });

                    if (this.employee != null)
                    {
                        Former former = (Former)this.employee;

                        hourValue.Text = former.HourValue.ToString();
                        areaTaught.Text = former.AreaTaught;
                        availability.Text = former.Availability;
                    }
                    this.customFields.Add("hourValue", hourValue);
                    this.customFields.Add("areaTaught", areaTaught);
                    this.customFields.Add("availability", availability);
                    break;
                case "Secretary":

                    ComboBox directorCombox = new ComboBox();
                    directorCombox.Location = new Point(292, 28);
                    directorCombox.Name = "textBox_director";
                    directorCombox.Size = new Size(250, 58);
                    directorCombox.TabIndex = 20;
                    directorCombox.Font = new Font("Segoe UI", 14);

                    directorCombox.DisplayMember = "Name";
                    directorCombox.ValueMember = "Id";
                    directorCombox.Items.AddRange(new Director().get().ToArray());
                    directorCombox.DropDownStyle = ComboBoxStyle.DropDownList;


                    Label directorLable = new Label();
                    directorLable.Font = new Font("Microsoft Sans Serif", 16);
                    directorLable.ForeColor = Color.White;
                    directorLable.Location = new Point(0, 28);
                    directorLable.Margin = new Padding(2, 0, 2, 0);
                    directorLable.Name = "lable_director";
                    directorLable.Size = new Size(285, 58);
                    directorLable.TabIndex = 19;
                    directorLable.Text = "Director";
                    directorLable.TextAlign = ContentAlignment.MiddleLeft;

                    TextBox area = new TextBox();
                    area.Location = new Point(934, 28);
                    area.Name = "textBox_area";
                    area.Size = new Size(250, 58);
                    area.TabIndex = 20;
                    area.Font = new Font("Segoe UI", 14);
                    Label areaLable = new Label();
                    areaLable.Font = new Font("", 16);
                    areaLable.ForeColor = Color.White;
                    areaLable.Location = new Point(652, 28);
                    areaLable.Margin = new Padding(2, 0, 2, 0);
                    areaLable.Name = "lable_area";
                    areaLable.Size = new Size(285, 58);
                    areaLable.TabIndex = 19;
                    areaLable.Text = "Area";
                    areaLable.TextAlign = ContentAlignment.MiddleLeft;

                    if (this.employee != null)
                    {
                        Secretary secretary = (Secretary)this.employee;

                        directorCombox.Text = secretary.Director.Name;
                        area.Text = secretary.Area;
                    }

                    if (label_pageTitle.Text == "SHOW EMPLOYEE")
                    {
                        textBoxName.Enabled = false;
                        textBoxAddress.Enabled = false;
                        textBoxContractEnd.Enabled = false;
                        textBoxCriminalRecordDate.Enabled = false;
                        textBoxContact.Enabled = false;
                        directorCombox.Enabled = false;
                        area.Enabled = false;

                    }

                    painelCustomFields.Controls.AddRange(new Control[] {
                    directorCombox,
                    directorLable,
                    area,
                    areaLable,
                    });

                    this.customFields.Add("area", area);
                    this.customFields.Add("director", directorCombox);
                    break;
            }
        }

        private void btn_former_check(object? sender, EventArgs e)
        {
            Control selectFormerControl, showFormerControl;
            ListBox selectFormer, showFormer;
            this.customFields.TryGetValue("selectFormer", out selectFormerControl);
            selectFormer = (ListBox)selectFormerControl;
            this.customFields.TryGetValue("showFormer", out showFormerControl);
            showFormer = (ListBox)showFormerControl;
            List<Former> items = new List<Former>();
            foreach (int index in showFormer.SelectedIndices)
            {
                items.Add((Former)showFormer.Items[index]);
            }
            selectFormer.DataSource = items;

            selectFormer.DisplayMember = "Name";
            selectFormer.ValueMember = "Id";

        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox_director_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addEmployee_Load(object sender, EventArgs e)
        {

        }

        private void comboBox_area_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label_director_Click(object sender, EventArgs e)
        {
        }

        private void label_teachingArea_Click(object sender, EventArgs e)
        {
        }

        private void label_carCompany_Click(object sender, EventArgs e)
        {
        }

        private void comboBox_carCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox_teachingArea_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label_area_Click(object sender, EventArgs e)
        {
        }

        private void label_monthBonus_Click_1(object sender, EventArgs e)
        {
        }

        private void comboBox_monthBonus_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void painelCustomFields_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_answer_username_Click(object sender, EventArgs e)
        {

        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_monthBonus_Click_2(object sender, EventArgs e)
        {

        }

        private void comboBox_carCompany_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void comboBox_monthBonus_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void btn_former_check_Click(object sender, EventArgs e)
        {

        }


        private void closesw(object sender, FormClosedEventArgs e)
        {
            this._parent.Show();
        }
    }
}
