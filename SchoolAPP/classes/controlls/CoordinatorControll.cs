using gestao.classes.interfaces;
using gestao.classes.internalStruct;
using gestao.classes.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace gestao.classes.controlls
{
    internal class CoordinatorControll : IControll
    {

        public static List<Employee> index()
        {
            return new Coordinator().get();
        }
     
        public Response create(Request request)
        {
            Coordinator coordinator = new Coordinator();

            string erroMsg = coordinator.InputValidate(request);
            if (erroMsg != "")
            {
                Response response = new Response(500);
                response.data = erroMsg;
                return response;
            }

            String value;
            request.Fields.TryGetValue("Name", out value);
            coordinator.Name = value;


            request.Fields.TryGetValue("Address", out value);
            coordinator.Address = value;


            request.Fields.TryGetValue("Contact", out value);
            coordinator.Contact = value;

            DateTime ContractEnd = new DateTime();
            request.Fields.TryGetValue("ContractEnd", out value);
            DateTime.TryParse(value, out ContractEnd);
            coordinator.EndContract = ContractEnd;


            DateTime CriminalRecordDate = new DateTime();
            request.Fields.TryGetValue("CriminalRecordDate", out value);
            DateTime.TryParse(value, out CriminalRecordDate);
            coordinator.CriminaRecord = CriminalRecordDate;


            request.Fields.TryGetValue("formers", out value);
            foreach (var id in value.Split(';'))
            {
                coordinator.addTrainers((Former)new Former().get().Find(element => element.Id.ToString() == id));
            }

            coordinator.insert();

            exportXml();

            return new Response(400);
        }

        public Response update(Request request, Employee employee)
        {
            Coordinator coordinator = (Coordinator)employee;

            string erroMsg = coordinator.InputValidate(request);
            if (erroMsg != "")
            {
                Response response = new Response(500);
                response.data = erroMsg;
                return response;
            }

            String value;
            request.Fields.TryGetValue("Name", out value);
            coordinator.Name = value;

            request.Fields.TryGetValue("Address", out value);
            coordinator.Address = value;

            request.Fields.TryGetValue("Contact", out value);
            coordinator.Contact = value;

            DateTime ContractEnd = new DateTime();
            request.Fields.TryGetValue("ContractEnd", out value);
            DateTime.TryParse(value, out ContractEnd);
            coordinator.EndContract = ContractEnd;


            DateTime CriminalRecordDate = new DateTime();
            request.Fields.TryGetValue("CriminalRecordDate", out value);
            DateTime.TryParse(value, out CriminalRecordDate);
            coordinator.CriminaRecord = CriminalRecordDate;

            request.Fields.TryGetValue("formers", out value);
            coordinator.deleteTrainers();
            foreach (var id in value.Split(';'))
            {
                coordinator.addTrainers((Former)new Former().get().Find(element => element.Id.ToString() == id));
            }


            coordinator.update();

            exportXml();
            
            return new Response(400);
        }
        public static void store(Request request)
        {

        }
        public static void Insert(Request request)
        {

        }
        public static void Update(Request request)

        {

        }
        public static void exportXml()
        {
            List<Employee> Coordinators = new Coordinator().get();


            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = true;
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            using (XmlWriter writer = XmlWriter.Create("data/coordinators.xml", settings))
            {
                writer.WriteStartElement("root");
                foreach (Coordinator Coordinator in Coordinators)
                {
                    Coordinator.xmlConvert(writer);
                }
                writer.Flush();
                writer.Close();
            }
        }
        public static void importXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Directory.GetCurrentDirectory() + @"\data/coordinators.xml");
            if (!doc.DocumentElement.HasAttributes)
                foreach (XmlNode node in doc.DocumentElement)
                {
                    Coordinator coordinator = new Coordinator();
                    coordinator.Name = node["Name"].InnerText;
                    coordinator.Address = node["Address"].InnerText;
                    coordinator.Contact = node["Contact"].InnerText;
                    coordinator.EndContract = DateTime.ParseExact(node["EndContract"].InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    coordinator.CriminaRecord = DateTime.ParseExact(node["CriminaRecord"].InnerText, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    Console.WriteLine(node);

                    foreach (XmlNode node2 in node["Trainers"]) {
                        coordinator.addTrainers((Former)new Former().get().Find(element => element.Id.ToString() == node2["ID"].InnerText));
                    }
                    coordinator.insert();
                }
        }
        public List<Employee> expiredDate()
        {

            return new Coordinator().get().FindAll((element) =>
            {
                bool v = 0 > DateTime.Compare(DateTime.Parse(Company.getCurrentDate()), element.CriminaRecord);

                return v;
            });

        }
        public List<Employee> warningDate()
        {
            return new Coordinator().get().FindAll((element) =>
            {
                bool v = 0 == DateTime.Compare(DateTime.Parse(Company.getCurrentDate()), element.CriminaRecord);

                return v;
            });
        }
    }
}
