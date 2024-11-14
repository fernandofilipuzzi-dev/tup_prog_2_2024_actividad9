using ComercioLib.Models;

namespace webapiServicio.DTOs
{
    public class TicketDTO
    {
        public string Tipo { get; set; }    
        public int nroOrden { get; set; }
        public DateTime FechaHora { get; set; }
        public CuentaCorriente ficha 
        { get; set; }
        public int dni { get; set; }

        public TicketDTO(Ticket t)
        {
            if (t is Cliente cliente)
            {
                Tipo = "CLIENTE";

                dni = cliente.VerDNI();

            }
            else if (t is Pago pago)
            {
                Tipo = "PAGO";

                FechaHora = pago.FechaHora;
            }

            nroOrden = t.VerNRO();
            FechaHora = t.VerFecha();

        }
    }
}
 