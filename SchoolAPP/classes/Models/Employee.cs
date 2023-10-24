using gestao.classes.internalStruct;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace gestao.classes.Models
{
    public abstract class Employee
    {
        private int id;

        private string name;

        private string address;

        private string contact;

        private DateTime endContract;

        private DateTime criminaRecord;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string Contact
        {
            get
            {
                return contact;
            }
            set
            {
                contact = value;
            }
        }

        public DateTime EndContract
        {
            get
            {
                return endContract;
            }
            set
            {
                endContract = value;
            }
        }

        public DateTime CriminaRecord
        {
            get
            {
                return criminaRecord;
            }
            set
            {
                criminaRecord = value;
            }
        }

        public Employee()
        {

        }

        public bool FindExpired()
        {
            if (0 < DateTime.Compare(DateTime.ParseExact(Company.getCurrentDate(), "yyyy-MM-dd", CultureInfo.InvariantCulture), DateTime.ParseExact(this.CriminaRecord.ToString("yyyy-MM-dd"), "yyyy-MM-dd", CultureInfo.InvariantCulture)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Explicit predicate delegate.
        public bool FindWarning()
        {

            if (0 == DateTime.Compare(DateTime.ParseExact(Company.getCurrentDate(), "yyyy-MM-dd", CultureInfo.InvariantCulture), this.CriminaRecord))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void xmlConvert(XmlWriter xml)
        {
            xml.WriteElementString("ID", this.Id.ToString());
            xml.WriteElementString("Name", this.Name);
            xml.WriteElementString("Address", this.Address);
            xml.WriteElementString("Contact", this.Contact);
            xml.WriteElementString("EndContract", this.EndContract.ToString("yyyy-MM-dd"));
            xml.WriteElementString("CriminaRecord", this.criminaRecord.ToString("yyyy-MM-dd"));
        }

        public string convterCsv()
        {
            string elementXml = "";

            elementXml += this.Id + ";";
            elementXml += this.Address + ";";
            elementXml += this.Contact + ";";
            elementXml += this.EndContract.ToString("yyyy-MM-dd") + "; ";
            elementXml += this.criminaRecord.ToString("yyyy-MM-dd") + "; ";

            return elementXml;
        }
        public Employee(string Name, string Address, string Contact, DateTime EndContract, DateTime CriminaRecord)
        {
            name = Name;
            address = Address;
            contact = Contact;
            endContract = EndContract;
            criminaRecord = CriminaRecord;
        }

        public List<Employee> get()
        {
            return Company.GetCompany().FindAll(
                element => (element.GetType()) == this.GetType()
                ).OrderBy(element => element.GetType()).ToList();
        }
        public List<Employee> get(string date)
        {
            return Company.GetCompany(date).FindAll(
                element => (element.GetType()) == this.GetType()
                ).OrderBy(element => element.GetType()).ToList();
        }
        public void update()
        {
            int index = Company
                .GetCompany()
                .FindIndex(element => element.GetType() == this.GetType() && element.Id == this.Id);

            Company.GetCompany()[index] = this;
        }
        public void insert()
        {
            if (Company.GetCompany().FindAll(element => element.GetType() == this.GetType()).LastOrDefault() != null)
                this.Id = Company.GetCompany().FindAll(element => element.GetType() == this.GetType()).Last().Id + 1;
            else
                this.Id = 1;

            Company.addEmployee(this);
        }

        public static string staticInputValidate(Request request)
        {
            System.String value;

            request.Fields.TryGetValue("Name", out value);
            if (string.IsNullOrEmpty(value))
            {
                return "Please, insert a valid name! \n";
            }
            else
            {
                foreach (char c in value)
                {
                    if (!char.IsLetter(c) && c != ' ')
                    {
                        return "Name should contain only letters!\n";
                    }
                }
            }

            request.Fields.TryGetValue("Address", out value);
            if (string.IsNullOrEmpty(value))
            {
                return "Please, insert a valid address!\n" ;
            }

            request.Fields.TryGetValue("Contact", out value);
            if (string.IsNullOrEmpty(value) || (value.Length != 9))
            {
                return "Please, insert a valid contact with nine numeric digits! \n";
            }
            else
            {
                foreach (char c in value)
                {
                    if (!char.IsDigit(c))
                    {
                        return "Contact should contain only nine numeric digits!\n";
                    }
                }
            }

            return "";
        }
    }
}
