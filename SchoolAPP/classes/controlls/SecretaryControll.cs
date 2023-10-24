using gestao.classes.interfaces;
using gestao.classes.internalStruct;
using gestao.classes.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace gestao.classes.controlls
{
    internal class SecretaryControll : IControll
    {

        public static List<Employee> index()
        {
            return new Secretary().get();
        }
        public static Secretary Show(Secretary secretary)
        {
            return secretary;
        }

        public Response update(Request request, Employee employee)
        {
            Secretary secretary = (Secretary)employee;

            string erroMsg = secretary.InputValidate(request);
            if (erroMsg != "")
            {
                Response response = new Response(500);
                response.data = erroMsg;
                return response;
            }

            String value;
            request.Fields.TryGetValue("Name", out value);
            secretary.Name = value;


            request.Fields.TryGetValue("Address", out value);
            secretary.Address = value;


            request.Fields.TryGetValue("Contact", out value);
            secretary.Contact = value;

            DateTime ContractEnd = new DateTime();
            request.Fields.TryGetValue("ContractEnd", out value);
            DateTime.TryParse(value, out ContractEnd);
            secretary.EndContract = ContractEnd;


            DateTime CriminalRecordDate = new DateTime();
            request.Fields.TryGetValue("CriminalRecordDate", out value);
            DateTime.TryParse(value, out CriminalRecordDate);

            secretary.CriminaRecord = CriminalRecordDate;

            request.Fields.TryGetValue("director", out value);

            secretary.Director = (Director)new Director().get().Find((element) =>
            {
                bool v = element.Id == int.Parse(value);
                return v;
            });

            request.Fields.TryGetValue("area", out value);
            secretary.Area = value;
            secretary.update();

            exportXml();
            return new Response(400);

        }
        public Response create(Request request)
        {
            Secretary secretary = new Secretary();


            string erroMsg = secretary.InputValidate(request);
            if (erroMsg != "")
            {
                Response response = new Response(500);
                response.data = erroMsg;
                return response;
            }

            String value;
            request.Fields.TryGetValue("Name", out value);
            secretary.Name = value;


            request.Fields.TryGetValue("Address", out value);
            secretary.Address = value;


            request.Fields.TryGetValue("Contact", out value);
            secretary.Contact = value;

            
            DateTime ContractEnd = new DateTime();
            request.Fields.TryGetValue("ContractEnd", out value);
            DateTime.TryParse(value, out ContractEnd);
            secretary.EndContract = ContractEnd;


            DateTime CriminalRecordDate = new DateTime();
            request.Fields.TryGetValue("CriminalRecordDate", out value);
            DateTime.TryParse(value, out CriminalRecordDate);
            secretary.CriminaRecord = CriminalRecordDate;

            request.Fields.TryGetValue("area", out value);
            secretary.Area = value;

            request.Fields.TryGetValue("director", out value);

            secretary.Director = (Director)new Director().get().Find((element) =>
            {
                bool v = element.Id == int.Parse(value);
                return v;
            });

            secretary.insert();
            exportXml();
            return new Response(400);
        }

        public static void importXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Directory.GetCurrentDirectory() + @"\data/secretaries.xml");
            if(!doc.DocumentElement.HasAttributes)
                foreach (XmlNode node in doc.DocumentElement)
                {
                    Secretary secretary = new Secretary();
                    secretary.Name = node["Name"].InnerText;
                    secretary.Address = node["Address"].InnerText;
                    secretary.Contact = node["Contact"].InnerText;
                    secretary.EndContract = DateTime.Parse(node["EndContract"].InnerText);
                    secretary.CriminaRecord = DateTime.Parse(node["CriminaRecord"].InnerText);
                    secretary.Director = (Director)new Director().get().Find((element) =>
                    {
                        bool v = element.Id == int.Parse(node["DirectorId"].InnerText);
                        return v;
                    });
                    secretary.Area = node["Area"].InnerText;
                    secretary.insert();
                }
        }
        public static void exportXml()
        {
            List<Employee> Secretaries = new Secretary().get();


            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = true;
            using (XmlWriter writer = XmlWriter.Create("data/secretaries.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("root");
                foreach (Secretary Secretary in Secretaries)
                {
                    Secretary.xmlConvert(writer);
                }
                writer.Flush();
                writer.Close();
            }
        }

        public static void store(Request request)
        {

        }
        public static void Update(Request request)
        {

        }
        public List<Employee> expiredDate()
        {

            return new Secretary().get().FindAll((element) =>
            {
                bool v = 0 > DateTime.Compare(DateTime.Parse(Company.getCurrentDate()), element.CriminaRecord);

                return v;
            });

        }
        public List<Employee> warningDate()
        {
            return new Secretary().get().FindAll((element) =>
            {
                bool v = 0 == DateTime.Compare(DateTime.Parse(Company.getCurrentDate()), element.CriminaRecord);

                return v;
            });
        }
    }
}
