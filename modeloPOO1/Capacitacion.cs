using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modeloPOO1
{
    class Capacitacion
    {
        public String codigo { get; set; }
        public String nombre { get; set; }
        public String curso { get; set; }
        public DateTime fecha { get; set; }

        public double asignarCosto()
        {
            if (curso == "Desarrollo de aplicaciones con Visual C# 2015") return 1500;
            else if (curso == "Desarrollo Web con ASP Net 2015") return 1750;
            else if (curso == "Desarrollo de aplicaciones moviles") return 2000;
            else return 0;
        }

        public int asignarHoras()
        {
            if (curso == "Desarrollo de aplicaciones con Visual C# 2015") return 50;
            else if (curso == "Desarrollo Web con ASP Net 2015") return 40;
            else if (curso == "Desarrollo de aplicaciones moviles") return 60;
            else return 0;
        }

        public  double calculaSubtotal()
        {
            return asignarCosto();
        }

        public virtual double descuento()
        {
            return 0;
        }

        public virtual double calculaNeto()
        {
            return calculaSubtotal() - descuento();
        }
    }
}
