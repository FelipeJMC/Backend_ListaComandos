using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaComandos.BL.Response
{
    public class Response
    {
        public string Estado { get; set; }
        public string Mensaje { get; set; }
        public object Data { get; set; }
    }
}
