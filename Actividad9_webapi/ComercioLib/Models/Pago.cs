using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib.Models
{
    public class Pago : Ticket
    {
        static int nroInicio = 0;

        CuentaCorriente ficha;

        public Pago(CuentaCorriente cc)
        {
            ficha = cc;
            nroOrden = ++nroInicio;
        }

        public CuentaCorriente VerCC()
        {
            return ficha;
        }

    }
}
