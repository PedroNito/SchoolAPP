using gestao.classes.internalStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace gestao.classes.Models
{
    class Coordinator : Employee
    {
        private List<Former> trainers;

        public void addTrainers(Former former)
        {
            if (this.trainers == null)
            {
                this.trainers = new List<Former>();
            }
            this.trainers.Add(former);
        }

        public void deleteTrainers()
        {
            this.trainers.Clear();
        }

        public void xmlConvert(XmlWriter xml)
        {

            xml.WriteStartElement("Coordinator");
            base.xmlConvert(xml);
            xml.WriteStartElement("Trainers");
            foreach (Former former in this.trainers)
            {
                former.xmlConvert(xml);
            }
            xml.WriteEndElement();
            xml.WriteEndElement();
        }

        public string convterCsv()
        {
            string elementXml = "";

            elementXml += base.convterCsv();

            foreach (Former former in this.trainers)
            {
                elementXml += former.Id + ';';
            }

            return elementXml + "\n";
        }

        public List<Former> getTrainers()
        {

            return this.trainers;
        }

        internal string InputValidate(Request request)
        {
            return "";
        }
    }
}
