using gestao.classes.controlls;
using gestao.classes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace gestao
{
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();

            Company.setCurrentDate(DateTime.Now);


            label_todayDate.Text = Company.getCurrentDate();
            this.loadWarings();
        }

        private void btn_addEmployee_Click(object sender, EventArgs e)
        {
            ListEmployees listEmployees = new EmployeeControll().index(this);
            listEmployees.Show();
            this.Hide();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void label_pageTitle_Click(object sender, EventArgs e)
        {

        }


        private void btn_foward_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Parse(Company.getCurrentDate());
            Company.setCurrentDate(date.AddDays(1D));

            label_todayDate.Text = Company.getCurrentDate();
            this.loadWarings();

        }

        private void btn_back_Click(object sender, EventArgs e)
        {

            DateTime date = DateTime.Parse(Company.getCurrentDate());
            Company.setCurrentDate(date.AddDays(-1D));

            label_todayDate.Text = Company.getCurrentDate();

            this.loadWarings();
        }

        private void btn_warning_Click(object sender, EventArgs e)
        {

            ListEmployees warningDateEnd = new EmployeeControll().warningDate(this);
            warningDateEnd.Show();
            this.Hide();
        }

        private void btn_expiredList_Click(object sender, EventArgs e)
        {

            ListEmployees expiredEmployeeList = new EmployeeControll().expiredDate(this);
            expiredEmployeeList.Show();
            this.Hide();
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.InitialDirectory = @"c:/";

            saveFileDialog.RestoreDirectory = true;

            saveFileDialog.FileName = "*.csv";

            saveFileDialog.DefaultExt = "csv";
            string data = "";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {


                foreach (Secretary secretary in SecretaryControll.index())
                {
                    data += secretary.convterCsv();
                }


                foreach (Coordinator coordinator in CoordinatorControll.index())
                {

                    data += coordinator.convterCsv();
                }

                foreach (Former former in FormerControll.index())
                {

                    data += former.convterCsv();
                }

                foreach (Director director in DirectorControll.index())
                {

                    data += director.convterCsv();
                }

                File.WriteAllText(saveFileDialog.FileName, data);

                MessageBox.Show("Save file");
            }
        }
        public void loadWarings()
        {
            circularLabel_expiredList.Text = Company.GetCompany().Where(i => i.FindExpired()).Count().ToString();


            circularLabel_warningList.Text = Company.GetCompany().Where(i => i.FindWarning()).Count().ToString();
        }

        private void btn_calculator_Click(object sender, EventArgs e)
        {
            Calculator calculator = new Calculator(this);
            calculator.Show();
            this.Hide();
        }

        private void btn_calendar_Click(object sender, EventArgs e)
        {
            allocateTrainer allocateTrainer = new allocateTrainer(this);

            allocateTrainer.Show();

            this.Hide();
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
