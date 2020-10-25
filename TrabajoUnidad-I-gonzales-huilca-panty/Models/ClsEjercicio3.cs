using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabajoUnidad_I_gonzales_huilca_panty.Models
{
    public class ClsEjercicio3
    {
        public string texto { get; set; }
        public string palabra { get; set; }
        public string palabraClave { get; set; }
        public int contador { get; set; }

        public ClsEjercicio3()
        {
        }

        public ClsEjercicio3(string palabraClave)
        {
            this.palabraClave = palabraClave;
        }
    }
}