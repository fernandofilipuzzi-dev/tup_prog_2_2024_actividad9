
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsAppCliente.Models;

namespace WinFormsAppCliente.DTOs
{
    public class TicketDTO
    {
        public int tipo { get; set; }
        public int nroOrden { get; set; }
        public DateTime fechaHora { get; set; }
        public CuentaCorrienteDTO ficha { get; set; }
        public int DNI { get; set; }

        public TicketDTO()
        { }

        public Ticket ToTicket()
        {
            Ticket ticket = null;
            if (tipo == 1)
            {
                ticket=new  Cliente(DNI);
                ticket.nroOrden = nroOrden;
            }
            else if(tipo == 2)
            {
                CuentaCorriente cc = null;
                if (ficha!=null)
                    cc=ficha.ToCuentaCorriente();
                ticket = new Pago(cc);
                ticket.nroOrden = nroOrden;
            }
            return ticket;
        }
    }
}
