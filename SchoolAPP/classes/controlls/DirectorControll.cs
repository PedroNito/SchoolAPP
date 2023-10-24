using gestao.classes.interfaces;
using gestao.classes.internalStruct;
using gestao.classes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.DataFormats;

namespace gestao.classes.controlls
{

    internal class DirectorControll : IControll
    {

        public static List<Employee> index()
        {
            return new Director().get();
        }
        public Response update(Request request, Employee employee)
        {
            Director director = (Director)employee;

            string erroMsg = director.InputValidate(request);
            if (erroMsg != "")
            {
                Response response = new Response(500);
                response.data = erroMsg;
                return response;
            }

            System.String value;
            request.Fields.TryGetValue("Name", out value);
            director.Name = value;


            request.Fields.TryGetValue("Address", out value);
            director.Address = value;


            request.Fields.TryGetValue("Contact", out value);
            director.Contact = value;

            DateTime ContractEnd = new DateTime();
            request.Fields.TryGetValue("ContractEnd", out value);
            DateTime.TryParse(value, out ContractEnd);
            director.EndContract = ContractEnd;


            DateTime CriminalRecordDate = new DateTime();
            request.Fields.TryGetValue("CriminalRecordDate", out value);
            DateTime.TryParse(value, out CriminalRecordDate);
            director.CriminaRecord = CriminalRecordDate;


            request.Fields.TryGetValue("carSelect", out value);
            director.car = value == "Yes";

            request.Fields.TryGetValue("timeExemption", out value);
            director.timeExemption = value == "Yes";

            request.Fields.TryGetValue("salaryBonus", out value);
            director.salaryBonus = Decimal.Parse(value);

            director.update();

            exportXml();

            return new Response(400);
        }
        public static void exportXml()
        {
            List<Employee> Directors = new Director().get();


            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = true;

            using (XmlWriter writer = XmlWriter.Create("data/directors.xml", settings))
            {
                writer.WriteStartElement("root");
                foreach (Director Director in Directors)
                {
                    Director.xmlConvert(writer);
                }
                writer.Flush();
                writer.Close();
            }
        }

        public static void importXml() {
            XmlDocument doc = new XmlDocument();
            doc.Load(Directory.GetCurrentDirectory() + @"\data/directors.xml");
            if (!doc.DocumentElement.HasAttributes)
                foreach (XmlNode node in doc.DocumentElement)
                {
                    Director director = new Director();
                    director.Name = node["Name"].InnerText;
                    director.Address = node["Address"].InnerText;
                    director.Contact = node["Contact"].InnerText;
                    director.EndContract = DateTime.Parse(node["EndContract"].InnerText);
                    director.CriminaRecord = DateTime.Parse(node["CriminaRecord"].InnerText);
                    director.car = node["Car"].InnerText == "Yes";
                    director.timeExemption = node["TimeExemption"].InnerText == "Yes";
                    director.salaryBonus = Decimal.Parse(node["SalaryBonus"].InnerText);
                    director.insert();
                }
        }
        public Response create(Request request)
        {
            Director director = new Director();
            
            string erroMsg = director.InputValidate(request);
            if (erroMsg != "")
            {
                Response response = new Response(500);
                response.data = erroMsg;
                return response;
            }


            System.String value;
            request.Fields.TryGetValue("Name", out value);
            director.Name = value;


            request.Fields.TryGetValue("Address", out value);
            director.Address = value;


            request.Fields.TryGetValue("Contact", out value);
            director.Contact = value;

            DateTime date = new DateTime();
            request.Fields.TryGetValue("ContractEnd", out value);
            if (!DateTime.TryParse(value, out date))
            {
                date = DateTime.Now;
            }
            director.EndContract = date;


            request.Fields.TryGetValue("CriminalRecordDate", out value);
            DateTime.TryParse(value, out date);

            if (!DateTime.TryParse(value, out date))
            {
                date = DateTime.Now;
            }
            director.CriminaRecord = date;


            request.Fields.TryGetValue("carSelect", out value);
            director.car = value == "Yes";

            request.Fields.TryGetValue("timeExemption", out value);
            director.timeExemption = value == "Yes";

            request.Fields.TryGetValue("salaryBonus", out value);
            director.salaryBonus = Decimal.Parse(value);

    
            director.insert();
            exportXml();
            return new Response(400);
        }

        public List<Employee> expiredDate()
        {

            return new Director().get().FindAll((element) =>
            {
                bool v = 0 > DateTime.Compare(DateTime.Parse(Company.getCurrentDate()), element.CriminaRecord) || 0 > DateTime.Compare(DateTime.Parse(Company.getCurrentDate()), element.EndContract);

                return v;
            });

        }
        public List<Employee> warningDate()
        {
            return new Director().get().FindAll((element) =>
            {
                bool v = 0 == DateTime.Compare(DateTime.Parse(Company.getCurrentDate()), element.CriminaRecord) || 0 == DateTime.Compare(DateTime.Parse(Company.getCurrentDate()), element.EndContract);

                return v;
            });
        }
    }
}
