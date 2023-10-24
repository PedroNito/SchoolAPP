using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestao.classes.internalStruct
{
    public class Request
    {
        public Dictionary<string, string> Fields = new Dictionary<string, string>();

        public Form Page;

        public Request(Form page) { 
            this.Page = page;
        }
    }
}
