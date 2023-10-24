using gestao.classes.controlls;
using gestao.classes.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestao
{
    public partial class ListEmployees : Form
    {
        public mainMenu _parent;
        List<Employee> employees;
        string title;
        public ListEmployees(mainMenu _parent, List<Employee> employees, string title)
        {
            InitializeComponent();
            this._parent = _parent;
            this.employees = employees;
            this.loadData(this.employees);
            this.title = title;
            this.label_pageTitle.Text = title;
        }


        public void loadData(List<Employee> employees)
        {
            tableLayoutPanel.Controls.Clear();
            int i = 0;
            foreach (var employee in employees)
            {
                Label labelid = new Label();
                labelid.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
                labelid.ForeColor = Color.White;
                labelid.Location = new Point(5, 3);
                labelid.Margin = new Padding(2, 0, 2, 0);
                labelid.Name = "label8";
                labelid.Size = new Size(197, 60);
                labelid.TabIndex = 46;
                labelid.Text = employee.Id.ToString();
                labelid.TextAlign = ContentAlignment.MiddleCenter;


                tableLayoutPanel.Controls.Add(labelid, 0, i);



                Label labelName = new Label();
                labelName.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
                labelName.ForeColor = Color.White;
                labelName.Text = employee.Name;
                labelName.Size = new Size(389, 60);
                labelName.TextAlign = ContentAlignment.MiddleLeft;
                tableLayoutPanel.Controls.Add(labelName, 1, i);


                Label labelDepart = new Label();
                labelDepart.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
                labelDepart.ForeColor = Color.White;
                labelDepart.Location = new Point(619, 3);
                labelDepart.Name = "label10";
                labelDepart.Size = new Size(378, 60);
                labelDepart.TabIndex = 48;
                labelDepart.TextAlign = ContentAlignment.MiddleCenter;

                if (employee.GetType() == new Former().GetType())
                {
                    labelDepart.Text = "Trainer";
                }
                if (employee.GetType() == new Secretary().GetType())
                {
                    labelDepart.Text = "Secretary";
                }
                if (employee.GetType() == new Director().GetType())
                {
                    labelDepart.Text = "Director";
                }
                if (employee.GetType() == new Coordinator().GetType())
                {
                    labelDepart.Text = "Coordinator";
                }
                tableLayoutPanel.Controls.Add(labelDepart, 2, i);


                Label labelCR = new Label();
                labelCR.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
                labelCR.ForeColor = Color.White;
                labelCR.Location = new Point(1010, 3);
                labelCR.Name = "label12";
                labelCR.Size = new Size(240, 60);
                labelCR.TabIndex = 49;
                labelCR.Text = "13 - 02 - 2024";
                labelCR.TextAlign = ContentAlignment.MiddleCenter;
                labelCR.Text = employee.CriminaRecord.ToString("dd/MM/yyyy");


                tableLayoutPanel.Controls.Add(labelCR, 3, i);


                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addEmployee));


                Button editBtn = new Button();


                editBtn.BackColor = Color.FromArgb(94, 94, 94);
                editBtn.BackgroundImageLayout = ImageLayout.Zoom;
                editBtn.FlatAppearance.BorderSize = 0;
                editBtn.FlatStyle = FlatStyle.Flat;
                editBtn.Location = new Point(3, -3);
                editBtn.Margin = new Padding(3, 2, 3, 2);
                editBtn.Name = "button7";
                editBtn.Size = new Size(65, 65);
                editBtn.TabIndex = 46;
                editBtn.UseVisualStyleBackColor = false;
                editBtn.TextImageRelation = TextImageRelation.Overlay;
                editBtn.BackgroundImage = Image.FromFile(@"../../../Resources/editUser.png");

                editBtn.Click += (sender, args) =>
                {

                    addEmployee addEmployeeForm = new addEmployee(this, "EDIT EMPLOYEE", employee);
                    addEmployeeForm.Show();

                    this.Hide();
                };
                //BrigdeBtn.Click += btn_former_check;

                Button showBtn = new Button();
                showBtn.BackColor = Color.FromArgb(94, 94, 94);
                showBtn.BackgroundImageLayout = ImageLayout.Zoom;
                showBtn.FlatAppearance.BorderSize = 0;
                showBtn.FlatStyle = FlatStyle.Flat;
                showBtn.BackgroundImage = Image.FromFile(@"../../../Resources/showUser.png");
                showBtn.Location = new Point(110, -5);
                showBtn.Margin = new Padding(3, 2, 3, 2);
                showBtn.Size = new Size(65, 65);
                showBtn.TabIndex = 47;
                showBtn.UseVisualStyleBackColor = false;

                showBtn.TextImageRelation = TextImageRelation.Overlay;
                showBtn.Click += (sender, args) =>
                {

                    addEmployee addEmployeeForm = new addEmployee(this, "SHOW EMPLOYEE", employee);
                    addEmployeeForm.Show();

                    this.Hide();
                };



                Panel Painel = new Panel();
                Painel.Location = new Point(1259, 6);
                Painel.Name = "panel2";
                Painel.Size = new Size(285, 57);
                Painel.TabIndex = 0;

                Painel.Controls.AddRange(new Control[] { editBtn, showBtn });

                if (employee.GetType() == new Former().GetType())
                {
                    Button calcBtn = new Button();
                    calcBtn.BackColor = Color.FromArgb(94, 94, 94);
                    calcBtn.BackgroundImageLayout = ImageLayout.Zoom;
                    calcBtn.FlatAppearance.BorderSize = 0;
                    calcBtn.FlatStyle = FlatStyle.Flat;
                    calcBtn.BackgroundImage = Image.FromFile(@"../../../Resources/calculator.png");
                    calcBtn.Location = new Point(217, -5);
                    calcBtn.Margin = new Padding(3, 2, 3, 2);
                    calcBtn.Name = "button9";
                    calcBtn.Size = new Size(65, 65);
                    calcBtn.TabIndex = 48;
                    calcBtn.UseVisualStyleBackColor = false;

                    calcBtn.TextImageRelation = TextImageRelation.Overlay;
                    calcBtn.Click += (sender, args) =>
                    {

                        Calculator addEmployeeForm = new Calculator(this, employee);
                        addEmployeeForm.Show();

                        this.Hide();
                    };

                    Painel.Controls.Add(calcBtn);
                }
                //BrigdeBtn.Click += btn_former_check;s


                tableLayoutPanel.Controls.Add(Painel, 4, i);
                i++;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void btn_addEmployee_Click(object sender, EventArgs e)
        {

            addEmployee addEmployeeForm = new addEmployee(this, "ADD EMPLOYEE");
            addEmployeeForm.Show();
            this.Hide();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

            _parent.Show();

            this._parent.loadWarings();
            this.Close();
        }

        private void closesw(object sender, FormClosedEventArgs e)
        {
            this._parent.Show();
        }
    }
}
