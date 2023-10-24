using gestao.classes.internalStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace gestao.classes.Models
{
    class Former : Employee
    {
        public string availabilityStruct;

        private string areaTaught;

        private string availability;

        private decimal hourValue;

        public string AreaTaught
        {
            get
            {
                return areaTaught;
            }
            set
            {
                areaTaught = value;
            }
        }
        public string Availability
        {
            get
            {
                return availability;
            }
            set
            {
                availability = value;
            }
        }
        public decimal HourValue
        {
            get
            {
                return hourValue;
            }
            set
            {
                hourValue = value;
            }
        }
        public void xmlConvert(XmlWriter xml)
        {

            xml.WriteStartElement("Trainer");
            base.xmlConvert(xml);
            xml.WriteElementString("HourValue", this.HourValue.ToString());
            xml.WriteElementString("Availability", this.Availability);
            xml.WriteElementString("AreaTaught", this.AreaTaught);
            xml.WriteEndElement();
        }

        public string convterCsv()
        {
            string elementXml = "";

            elementXml += base.convterCsv();
            elementXml += this.HourValue + ";";
            elementXml += this.Availability + ";";
            elementXml += this.AreaTaught + ";";

            return elementXml + "\n";
        }
        public decimal SalaryCalculator()
        {
            return 0;
        }

        public string InputValidate(Request request)
        {
            System.String value;

            string errorMessage =  staticInputValidate(request);
            if ( errorMessage != "") 
            {
                return errorMessage; 
            }
      
            request.Fields.TryGetValue("areaTaught", out value);
            if (string.IsNullOrEmpty(value))
            {
                return "Please, insert your area taught!\n";
            }
            else
            {
                foreach (char c in value)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        return "Area taught should contain only letters!\n";
                    }
                }
            }

            request.Fields.TryGetValue("availability", out value);

            if (string.IsNullOrEmpty(value))
            {
                return "Please, choose your availability option!\n";
            }

            request.Fields.TryGetValue("hourValue", out value);
            if (string.IsNullOrEmpty(value))
            {
                return "Please, insert your value hour!\n";
            }
            else
            {
               decimal d = new Decimal();
             
                if (!Decimal.TryParse(value, out d))
                {
                   return "Value hour should contain only numeric digits!\n";
                }    
            }

            return "";
        }
    }
}

