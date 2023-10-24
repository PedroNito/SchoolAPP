using gestao.classes.internalStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace gestao.classes.Models
{
    class Secretary : Employee
    {
        private Director director;

        private string area;
        public string Area
        {
            get
            {
                return area;
            }
            set
            {
                area = value;
            }
        }
        public Director Director
        {
            get
            {
                return director;
            }
            set
            {
                if (value != null)
                {
                    director = value;
                }
            }
        }

        public void xmlConvert(XmlWriter xml)
        {
            xml.WriteStartElement("Secretary");
            base.xmlConvert(xml);

            xml.WriteElementString("Area", this.Area);

            xml.WriteElementString("DirectorId", this.director.Id.ToString());
            xml.WriteEndElement();
        }
        public string convterCsv()
        {
            string elementXml = "";

            elementXml += base.convterCsv();
            elementXml += this.Area + ";";
            elementXml += this.Director.convterCsv() + ";";

            return elementXml + "\n";
        }

        internal string InputValidate(Request request)
        {
            System.String value;

            string errorMessage = staticInputValidate(request);
            if (errorMessage != "")
            {
                return errorMessage;
            }

            request.Fields.TryGetValue("area", out value);
            if (string.IsNullOrEmpty(value))
            {
                return "Please, insert your area!\n";
            }
            else
            {
                foreach (char c in value)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        return "Area should contain only letters!\n";
                    }
                }
            }

            return "";
        }
    }
}
