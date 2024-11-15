using ComercioLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib.DTOs
{
    public class TicketDTO
    {
        public int tipo { get; set; }
        public int nroOrden { get; set; }
        public DateTime fechaHora { get; set; }
        public CuentaCorrienteDTO ficha { get; set; }
        public int dni { get; set; }

        public TicketDTO(Ticket ticket) 
        {
            nroOrden = ticket.VerNro();
            fechaHora = ticket.VerFecha();

            if (ticket is Cliente cliente)
            {
                tipo = 1;
                this.dni = cliente.VerDNI();
            }
            else if (ticket is Pago pago)
            {
                tipo = 2;
                ficha = new CuentaCorrienteDTO(pago.VerCC());
            }
        }

    }
}
