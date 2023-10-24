using gestao.classes.interfaces;
using gestao.classes.internalStruct;
using gestao.classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace gestao.classes.controlls
{
    internal class FormerControll : IControll
    {

        public static List<Employee> index()
        {
            return new Former().get();
        }
      
        public Response update(Request request, Employee employee)
        {
            Former former = (Former)employee;

            System.String value;

            string erroMsg = former.InputValidate(request);
            if (erroMsg != "")
            {
                Response response = new Response(500);
                response.data = erroMsg;
                return response;
            }

            request.Fields.TryGetValue("Name", out value);
            former.Name = value;

            request.Fields.TryGetValue("Address", out value);
            former.Address = value;

            request.Fields.TryGetValue("Contact", out value);
            former.Contact = value;

            DateTime ContractEnd = new DateTime();
            request.Fields.TryGetValue("ContractEnd", out value);
            DateTime.TryParse(value, out ContractEnd);
            former.EndContract = ContractEnd;


            DateTime CriminalRecordDate = new DateTime();
            request.Fields.TryGetValue("CriminalRecordDate", out value);
            DateTime.TryParse(value, out CriminalRecordDate);
            former.CriminaRecord = CriminalRecordDate;



            request.Fields.TryGetValue("availability", out value);
            former.Availability = value.ToString();

            request.Fields.TryGetValue("areaTaught", out value);
            former.AreaTaught = value.ToString();

            request.Fields.TryGetValue("hourValue", out value);
            former.HourValue = Decimal.Parse(value);


            former.update();
            exportXml();
            return new Response(400);
        }
        public static void exportXml()
        {
            List<Employee> trainers = new Former().get();


            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = true;
            using (XmlWriter writer = XmlWriter.Create("data/trainers.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                foreach (Former trainer in trainers)
                {
                    trainer.xmlConvert(writer);
                }
                writer.Flush();
                writer.Close();
            }
        }

        public static void importXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Directory.GetCurrentDirectory() + @"\data/trainers.xml");

            if (!doc.DocumentElement.HasAttributes)
                foreach (XmlNode node in doc.DocumentElement)
                {
                    Former trainer = new Former();
                    trainer.Name = node["Name"].InnerText;
                    trainer.Address = node["Address"].InnerText;
                    trainer.Contact = node["Contact"].InnerText;
                    trainer.EndContract = DateTime.Parse(node["EndContract"].InnerText);
                    trainer.CriminaRecord = DateTime.Parse(node["CriminaRecord"].InnerText);

                    trainer.Availability = node["Availability"].InnerText;
                    trainer.AreaTaught = node["AreaTaught"].InnerText;
                    trainer.HourValue = Decimal.Parse(node["HourValue"].InnerText);

                    trainer.insert();
                }
        }
        public Response create(Request request)
        {
            Former former = new Former();

            string erroMsg = former.InputValidate(request);
            if (erroMsg != "")
            {
                Response response = new Response(500);
                response.data = erroMsg;
                return response;
            }

            System.String value;
            request.Fields.TryGetValue("Name", out value);
            former.Name = value;

            request.Fields.TryGetValue("Address", out value);
            former.Address = value;

            request.Fields.TryGetValue("Contact", out value);
            former.Contact = value;

            DateTime date = new DateTime();
            request.Fields.TryGetValue("ContractEnd", out value);
            if(!DateTime.TryParse(value, out date))
            {
                date = DateTime.Now;
            }
            former.EndContract = date;

            request.Fields.TryGetValue("CriminalRecordDate", out value);
            DateTime.TryParse(value, out date);

            if (!DateTime.TryParse(value, out date))
            {
                date = DateTime.Now;
            }
            former.CriminaRecord = date;

            request.Fields.TryGetValue("availability", out value);
            former.Availability = value.ToString();

            request.Fields.TryGetValue("areaTaught", out value);
            former.AreaTaught = value.ToString();

            request.Fields.TryGetValue("hourValue", out value);
            former.HourValue = Decimal.Parse(value);

            former.insert(); exportXml();
            return new Response(400);
        }
        public static Response Update(Request request, Former former)
        {
            System.String value;
            request.Fields.TryGetValue("Name", out value);
            former.Name = value;

            request.Fields.TryGetValue("Address", out value);
            former.Address = value;

            request.Fields.TryGetValue("Contact", out value);
            former.Contact = value;

            DateTime date = new DateTime();
            request.Fields.TryGetValue("ContractEnd", out value);
            if (!DateTime.TryParse(value, out date))
            {
                date = DateTime.Now;
            }
            former.EndContract = date;

            request.Fields.TryGetValue("CriminalRecordDate", out value);
            DateTime.TryParse(value, out date);

            if (!DateTime.TryParse(value, out date))
            {
                date = DateTime.Now;
            }
            former.CriminaRecord = date;


            request.Fields.TryGetValue("availability", out value);
            former.Availability = value.ToString();

            request.Fields.TryGetValue("areaTaught", out value);
            former.AreaTaught = value.ToString();

            request.Fields.TryGetValue("hourValue", out value);
            former.HourValue = Decimal.Parse(value);


            former.update();

            exportXml();
            return new Response(400);
        }

        public List<Employee> expiredDate()
        {
            return new Former().get().FindAll((element) =>
            {
                bool v = 0 > DateTime.Compare(DateTime.Parse(Company.getCurrentDate()), element.CriminaRecord);

                return v;
            });
        }
        public List<Employee> warningDate()
        {
            return new Former().get().FindAll((element) =>
            {
                bool v = 0 == DateTime.Compare(DateTime.Parse(Company.getCurrentDate()), element.CriminaRecord);

                return v;
            });
        }
    }
}
