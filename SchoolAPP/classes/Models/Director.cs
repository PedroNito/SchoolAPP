using gestao.classes.internalStruct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace gestao.classes.Models
{
    class Director : Employee
    {
        public bool car { get; set; }
        public bool timeExemption { get; set; }
        public decimal salaryBonus { get; set; }
        public Director()
        {

        }
        public void xmlConvert(XmlWriter xml)
        {
            xml.WriteStartElement("Director");
            base.xmlConvert(xml);
            xml.WriteElementString("Car", this.car.ToString());
            xml.WriteElementString("TimeExemption", this.timeExemption.ToString());
            xml.WriteElementString("SalaryBonus", this.salaryBonus.ToString());
            xml.WriteEndElement();
        }
        public string convterCsv()
        {
            string elementXml = "";

            elementXml += base.convterCsv();
            elementXml += this.car + ";";
            elementXml += this.timeExemption + ";";
            elementXml += this.salaryBonus + ";";

            return elementXml + "\n";
        }

        public Director(bool car, bool timeExemption, decimal salaryBonus, string Name, string Household, string Contact, DateTime EndContract, DateTime CriminaRecord) :
            base(Name, Household, Contact, EndContract, CriminaRecord)
        {
            this.car = car;
            this.timeExemption = timeExemption;
            this.salaryBonus = salaryBonus;
        }

        internal string InputValidate(Request request)
        {
            System.String value;

            string errorMessage = staticInputValidate(request);
            if (errorMessage != "")
            {
                return errorMessage;
            }

            request.Fields.TryGetValue("carSelect", out value);
            if (string.IsNullOrEmpty(value))
            {
                return "Please, select a car option!\n";
            }

            request.Fields.TryGetValue("salaryBonus", out value);
            if (string.IsNullOrEmpty(value))
            {
                return "Please, insert your salary bonus!\n";
            }
            else
            {
                decimal d = new Decimal();

                if (!Decimal.TryParse(value, out d))
                {
                    return "Salary bonus should contain only numeric digits!\n";
                }
            }

            request.Fields.TryGetValue("timeExemption", out value);

            if (string.IsNullOrEmpty(value))
            {
                return "Please, choose your time exemption option!\n";
            }

            return "";
        }

    }
}
