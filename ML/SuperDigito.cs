using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class SuperDigito
    { 
        public int IdSuperDigito { get; set; }
        public int Numero { get; set; }
        public int Resultado { get; set; }
        public string FechaHora { get; set; }
        public List<object> Historiales { get; set; }
        public ML.Usuario Usuario { get; set; }
    }
}
