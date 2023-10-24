using gestao.classes.internalStruct;
using gestao.classes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestao.classes.interfaces
{
    interface IControll
    {
        public Response create(Request request);

        public Response update(Request request, Employee employee);
    }
}
