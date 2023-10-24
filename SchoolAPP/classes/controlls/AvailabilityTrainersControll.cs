using gestao.classes.interfaces;
using gestao.classes.internalStruct;
using gestao.classes.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace gestao.classes.controlls
{
    class AvailabilityTrainersControll
    {
        public AvailabilityTrainersControll()
        {

        }
        public Response store(Request request)
        {
            foreach (var item in request.Fields)
            {
                AvailabilityTrainers availability = new AvailabilityTrainers();

                availability.date = DateTime.ParseExact(item.Key, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
                availability.former = (Former)new Former().get().Find(element => element.Id.ToString() == item.Value);

                MessageBox.Show(item.Value);
                AvailabilityTrainers availabilityGet = availability.get().Find(element => 0 == DateTime.Compare(element.date, DateTime.ParseExact(item.Key, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture)));
                if (availabilityGet != null)
                {

                   availability.update();
                }
                else
                {
                    availability.insert();
                }
            }
            allocateTrainer allocateTrainer = (allocateTrainer)request.Page;
            exportXml();
            return new Response(400);
        }
        public static void importXml()
        {
            AvailabilityTrainers availability = new AvailabilityTrainers();
            XmlDocument doc = new XmlDocument();
            doc.Load(Directory.GetCurrentDirectory() + @"\data/availabilitytrainers.xml");
            if (!doc.DocumentElement.HasAttributes)
                foreach (XmlNode node in doc.DocumentElement)
                {
                    availability.date = DateTime.ParseExact(node["Date"].InnerText, "MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
                    availability.former = (Former)new Former().get().Find(element => element.Id.ToString() == node["Trainer"]["ID"].InnerText);
                    availability.insert();
                }
        }



        public static void exportXml()
        {
            List<AvailabilityTrainers> availabilities = Company.GetAvailabilityTrainers();


            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = true;
            using (XmlWriter writer = XmlWriter.Create("data/availabilitytrainers.xml", settings))
            {
                writer.WriteStartElement("root");
                foreach (AvailabilityTrainers availability in availabilities)
                {
                    availability.xmlConvert(writer);
                }
                writer.Flush();
                writer.Close();
            }
        }
    }
}
