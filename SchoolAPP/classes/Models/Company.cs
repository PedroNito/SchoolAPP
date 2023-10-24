using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace gestao.classes.Models
{

    //Class to return list of employees
    class Company
    {
        private static List<Employee> Employees = new List<Employee>();
        private static DateTime CurrentDate = new DateTime();
        private static List<AvailabilityTrainers> availabilitiesTrainers;

        private Company()
        {
        }
        static Company()
        {
            GetAvailabilityTrainers();
            GetCompany();
        }
        public static List<AvailabilityTrainers> GetAvailabilityTrainers()
        {
            if (availabilitiesTrainers == null)
            {
                availabilitiesTrainers = new List<AvailabilityTrainers>();
            }

            return availabilitiesTrainers;
        }
        public static void addAvailabilityTrainers(AvailabilityTrainers availability)
        {
            availabilitiesTrainers.Add(availability);
        }

        public static List<Employee> GetCompany()
        {
            if (Employees == null)
            {
                Employees = new List<Employee>();
            }
            return Employees.FindAll(element => 0 >= DateTime.Compare(DateTime.Parse(Company.getCurrentDate()), DateTime.Parse(element.EndContract.ToString("yyyy-MM-dd"))));
        }
        public static List<Employee> GetCompany(string date)
        {
            if (Employees == null)
            {
                Employees = new List<Employee>();
            }
            return Employees.FindAll(element => 0 >= DateTime.Compare(DateTime.Parse(date), DateTime.Parse(element.EndContract.ToString("yyyy-MM-dd"))));
        }
        public static string getCurrentDate()
        {
            return CurrentDate.ToString("yyyy-MM-dd");
        }
        public static void setCurrentDate(DateTime currentDate)
        {
            CurrentDate = currentDate;
        }
        //add Employee form list 
        public static void addEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        //Remove Employee form list 
        public static void editEmployee(Employee employee)
        {
            int index = Employees.FindLastIndex(c => c.Id == employee.Id);
            if (index != -1)
            {
                Employees[index] = employee;
            }
        }
        //Remove Employee form list 
        public static void deleteEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        public static Employee getEmployee(int id)
        {
            if (Employees.Find(elem => elem.Id == id) == null)
            {
                throw new Exception("Not Found");
            }

            return Employees.Find(elem => elem.Id == id);
        }
    }
}
