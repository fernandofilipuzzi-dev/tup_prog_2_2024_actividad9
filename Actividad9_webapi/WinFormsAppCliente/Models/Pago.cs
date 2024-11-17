using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppCliente.Models
{
    public class Pago : Ticket
    {
        CuentaCorriente ficha { get; set; }

        public Pago()
        {
        }

        public Pago(CuentaCorriente cc)
        {
            ficha = cc;
        }

        public override string ToString()
        {
            //tipo;numero;dni;ctaCte
            int dni = 0;
            int nroCuenta = 0;
            if (ficha != null)
            {
                nroCuenta = ficha.nroCuenta;
                if (ficha.titular != null) dni = ficha.titular.DNI;
            }
            
            return $"PAGO;{base.ToString()};{dni};{nroCuenta}";
        }

        //esto lo hice porque cuando extraigo del listbox compara usando el equals y no por referencia.
        //cuando se serializa en json se pierde la identidad del objeto por memoria
        public override bool Equals(object? obj)
        {
            return obj is Pago && nroOrden == ((Pago)obj).nroOrden;
        }
    }
}
