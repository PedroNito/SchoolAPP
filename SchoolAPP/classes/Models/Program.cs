using gestao.classes.controlls;
using System.Xml;

namespace gestao.classes.Models
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = true;
            if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\data"))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\data");
            }
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\data/trainers.xml")) {
                using (XmlWriter writer = XmlWriter.Create("data/trainers.xml", settings))
                {
                    writer.WriteStartElement("root");
                    writer.Flush();
                writer.Close();
                }
            }
            else
            {

                FormerControll.importXml();
            }

            if (!File.Exists(Directory.GetCurrentDirectory() + @"\data/directors.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create("data/directors.xml", settings))
                {
                    writer.WriteStartElement("root");
                    writer.Flush();
                writer.Close();
                }
            }
            else
            {
                DirectorControll.importXml();
            }
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\data/coordinators.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create("data/coordinators.xml", settings))
                {
                    writer.WriteStartElement("root");
                    writer.Flush();
                writer.Close();
                }
            }
            else
            {
                CoordinatorControll.importXml();
            }

            if (!File.Exists(Directory.GetCurrentDirectory() + @"\data/secretaries.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create("data/secretaries.xml", settings))
                {
                    writer.WriteStartElement("root");
                    writer.Flush();
                writer.Close();
                }
            }
            else { 
                SecretaryControll.importXml();
            }
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\data/availabilitytrainers.xml"))
            {
                using (XmlWriter writer = XmlWriter.Create("data/availabilitytrainers.xml", settings))
                {
                    writer.WriteStartElement("root");
                    writer.Flush();
                writer.Close();
                }
            } else
            {
                AvailabilityTrainersControll.importXml();
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new mainMenu());
            Application.Run(new mainMenu());
        }
    }
}