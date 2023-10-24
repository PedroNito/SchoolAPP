using gestao.classes.interfaces;
using gestao.classes.internalStruct;
using gestao.classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestao.classes.controlls
{
    internal class EmployeeControll
    {
        public ListEmployees index(mainMenu _parent)
        {
            List<Employee> employees = Company.GetCompany();

            ListEmployees listEmployeesForm = new ListEmployees(_parent, employees, "EMPLOYEES LIST");

            return listEmployeesForm;
        }

        public addEmployee create(ListEmployees _parent, Request request)
        {
            return new addEmployee(_parent, "ADD EMPLOYEE");
        }

        public addEmployee show(ListEmployees _parent, Employee employee)
        {
            return new addEmployee(_parent, "SHOW EMPLOYEE", employee);
        }

        public addEmployee update(ListEmployees _parent, Employee employee)
        {
            return new addEmployee(_parent, "EDIT EMPLOYEE", employee);
        }

        public ListEmployees expiredDate(mainMenu _parent)
        {
            List<Employee> employees = Company.GetCompany().FindAll(i => i.FindExpired());

            ListEmployees listEmployeesForm = new ListEmployees(_parent, employees, "EXPIRED CRIMINAL RECORD EMPLOYEE");

            return listEmployeesForm;
        }

        public ListEmployees warningDate(mainMenu _parent)
        {
            List<Employee> employees = Company.GetCompany().FindAll(i => i.FindWarning());

            ListEmployees listEmployeesForm = new ListEmployees(_parent, employees, "WARNING END CRIMINAL RECORD");
            return listEmployeesForm;
        }
    }
}
