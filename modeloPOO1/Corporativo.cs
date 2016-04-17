using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modeloPOO1
{
    class Corporativo:Capacitacion
    {
        public override double descuento()
        {
            return 0.1*calculaSubtotal();
        }

        public override double calculaNeto()
        {
            return calculaSubtotal()-descuento();
        }
    }
}
