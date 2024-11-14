using ComercioLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib
{
    public class Comercio
    {
        public Comercio() { }

        Queue<Pago> nuevosP = new Queue<Pago>();
        Queue<Cliente> nuevosClientes = new Queue<Cliente>();

        List<CuentaCorriente> cuentasCorrientes=new List<CuentaCorriente>();


        public void AgregarTicket(Ticket turno)
        {
            if (turno is Pago) nuevosP.Enqueue((Pago)turno);
            else if (turno is Cliente) nuevosClientes.Enqueue((Cliente)turno);
        }

        public Ticket AtenderTicket(int tipo)
        {
            Ticket ticket = null;
            if (tipo == 1)
            {
                if(nuevosClientes.Count>0)
                    ticket = nuevosClientes.Dequeue();
            }
            else if (tipo == 2)
            {
                if (nuevosP.Count > 0)
                    ticket = nuevosP.Dequeue();
            }
            return ticket;
        }

        public CuentaCorriente VerCuentaCorriente(int cc)
        {
            cuentasCorrientes.Sort();
            int idx = cuentasCorrientes.BinarySearch(new CuentaCorriente(cc,null) );
            if(idx>=0) return cuentasCorrientes[idx];
            return null;
        }

        public CuentaCorriente AgregarCuentaCorriente(int nro, string dni)
        {

            CuentaCorriente cc = VerCuentaCorriente(nro);

            if(cc==null)
                cc = new CuentaCorriente(nro, new Cliente(dni));
            
            return cc;
        }
    }
}
