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

namespace gestao
{
    public partial class Calculator : Form
    {
        private Form _parent;
        private Employee employee;
        public Calculator(Form _parant, Employee employee = null)
        {
            InitializeComponent();

            label_answer_startDate.MinDate = DateTime.Parse(Company.getCurrentDate());

            label_answer_endDate.MinDate = DateTime.Parse(Company.getCurrentDate());
            label_answer_startDate.Text = Company.getCurrentDate();

            label_answer_endDate.Text = Company.getCurrentDate();
            this._parent = _parant;
            this.employee = employee;

            if (this.employee != null)
            {

                label_answer_endDate.MaxDate = this.employee.EndContract;
            }
        }

        private void label_answer_salary_Click(object sender, EventArgs e)
        {

        }

        private void btn_check_Click(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this._parent.Show();

            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int diffDate = (label_answer_endDate.Value.Date - label_answer_startDate.Value.Date).Days + 1;

            this.label_answer_days.Text = diffDate.ToString();

            decimal formerCust = 0;
            if (this.employee != null)
            {
                Former former = (Former)this.employee;
                formerCust += (former.HourValue * 6 * diffDate);
            }
            else
            {
                foreach (Former former in new Former().get(label_answer_endDate.Text))
                {
                    formerCust += former.HourValue * 6 * diffDate;
                }

            }
            label_answer_salary.Text = formerCust.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this._parent.Show();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            label_answer_startDate.Text = Company.getCurrentDate();

            label_answer_endDate.Text = Company.getCurrentDate();

            this.label_answer_days.Text = "";
            label_answer_salary.Text = "";
        }
        private void closesw(object sender, FormClosedEventArgs e)
        {
            this._parent.Show();
        }
    }
}
