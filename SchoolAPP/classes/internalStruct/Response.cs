using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestao.classes.internalStruct
{
    internal class Response
    {
        public Response(int code) { 
            this.code = code;
        }
        public int code;

        public string data;
    }
}
