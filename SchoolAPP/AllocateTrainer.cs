using gestao.classes.controlls;
using gestao.classes.internalStruct;
using gestao.classes.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace gestao
{
    public partial class allocateTrainer : Form
    {
        private Form _parent;

        private Dictionary<String, Control> customFields = new Dictionary<string, Control>();
        public allocateTrainer(Form _parent)
        {
            InitializeComponent();
            this._parent = _parent;

            this.loadTable();
        }


        public void loadTable()
        {
            DateTime hours = DateTime.Parse("8:00 AM");
            for (int i = 0; i < 10; i++)
            {
                Label labelHour = new Label();
                labelHour.Font = new Font("Segoe UI", 10.125F, FontStyle.Regular, GraphicsUnit.Point);
                labelHour.ForeColor = Color.White;
                labelHour.Location = new Point(6, 116);
                labelHour.Name = "label7";
                labelHour.Size = new Size(220, 50);
                labelHour.TabIndex = 6;
                labelHour.TextAlign = ContentAlignment.MiddleCenter;
                labelHour.Text = hours.ToString("hh tt") + " - " + hours.AddHours(1).ToString("hh tt");

                tableLayoutPanel.Controls.Add(labelHour, 0, i + 1);

                hours = hours.AddHours(1);
            }

            DateTime now = DateTime.Parse(Company.getCurrentDate());
            int daysUntilNextWeek = (((int)DayOfWeek.Monday - (int)now.DayOfWeek + 7) % 7);
            DateTime nextWeek = now.AddDays(daysUntilNextWeek);
            for (int i = 0; i < 5; i++)
            {
                Label labelDayofWeek = new Label();
                labelDayofWeek.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
                labelDayofWeek.ForeColor = Color.Cyan;
                labelDayofWeek.Location = new Point(6, 3);
                labelDayofWeek.Name = "label_id";
                labelDayofWeek.Size = new Size(220, 50);
                labelDayofWeek.TabIndex = 0;
                labelDayofWeek.TextAlign = ContentAlignment.MiddleCenter;
                labelDayofWeek.Text = (nextWeek.DayOfWeek + "(" + nextWeek.ToString("yyyy-MM-dd") + ")").ToUpper();
                tableLayoutPanel.Controls.Add(labelDayofWeek, i + 1, 0);
                nextWeek = nextWeek.AddDays(1);
            }


            hours = DateTime.Parse("8:00 AM");
            for (int i = 0; i < 10; i++)
            {

                nextWeek = now.AddDays(daysUntilNextWeek);
                for (int j = 0; j < 5; j++)
                {
                    System.Windows.Forms.ComboBox comboxTrainers = new System.Windows.Forms.ComboBox();

                    comboxTrainers.Font = new Font("Segoe UI", 10.875F, FontStyle.Regular, GraphicsUnit.Point);
                    comboxTrainers.FormattingEnabled = true;
                    comboxTrainers.Location = new Point(235, 61);
                    comboxTrainers.Name = nextWeek.ToString("MM/dd/yyyy") + " " + hours.ToString("HH:mm");
                    comboxTrainers.Size = new Size(250, 33);
                    comboxTrainers.TabIndex = i + j;
                    comboxTrainers.DropDownStyle = ComboBoxStyle.DropDownList;
                    comboxTrainers.ValueMember = "Id";

                    comboxTrainers.DisplayMember = "Name";

                    AvailabilityTrainers availability = new AvailabilityTrainers().get().Find(element => 0 == DateTime.Compare(element.date, DateTime.ParseExact(comboxTrainers.Name, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)));
                    if (availability != null)
                    {
                        comboxTrainers.Items.Add(availability.former);

                        comboxTrainers.Items.AddRange(new Former().get(nextWeek.ToString("yyyy-MM-dd")).FindAll(i => i != availability.former).ToArray());
                        comboxTrainers.SelectedIndex = 0;
                    }
                    else
                    {

                        comboxTrainers.Items.AddRange(new Former().get(nextWeek.ToString("yyyy-MM-dd")).ToArray());
                    }

                    tableLayoutPanel.Controls.Add(comboxTrainers, j + 1, i + 1);
                    this.customFields.Add(comboxTrainers.Name, comboxTrainers);
                    nextWeek = nextWeek.AddDays(1);
                }
                hours = hours.AddHours(1);
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            _parent.Show();
            this.Close();
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            Request request = new Request(this);
            foreach (var item in this.customFields)
            {
                System.Windows.Forms.ComboBox comboBox = (System.Windows.Forms.ComboBox)item.Value;
                if (comboBox.SelectedIndex != -1)
                {

                    Former former = (Former)comboBox.Items[comboBox.SelectedIndex];
                    request.Fields.Add(item.Key, former.Id.ToString());
                }
            }

            AvailabilityTrainersControll availabilityTrainersControll = new AvailabilityTrainersControll();

            availabilityTrainersControll.store(request);


        }

        private void allocateTrainer_Load(object sender, EventArgs e)
        {

        }

        private void closesw(object sender, FormClosedEventArgs e)
        {
            this._parent.Show();
        }
    }
}
