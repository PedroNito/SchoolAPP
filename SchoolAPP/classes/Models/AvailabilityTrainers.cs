using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace gestao.classes.Models
{
    class AvailabilityTrainers
    {
        public DateTime date;
        public Former former;

        public List<AvailabilityTrainers> get()
        {
            return Company.GetAvailabilityTrainers();
        }

        public void update()
        {
            int index = Company
                .GetAvailabilityTrainers()
                .FindIndex(element => element.date == this.date);

            Company.GetAvailabilityTrainers()[index] = this;
        }
        public void xmlConvert(XmlWriter xml)
        {

            xml.WriteStartElement("AvailabilityTrainer");
            this.former.xmlConvert(xml);
            xml.WriteElementString("Date", this.date.ToString("MM/dd/yyyy HH:mm"));
            xml.WriteEndElement();
        }
        public void insert()
        {
            Company.addAvailabilityTrainers(this);
        }
    }
}
