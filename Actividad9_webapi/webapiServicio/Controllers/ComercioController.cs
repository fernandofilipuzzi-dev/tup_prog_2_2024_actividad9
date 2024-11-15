using ComercioLib.DTOs;
using ComercioLib.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapiServicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComercioController : ControllerBase
    {
        readonly static Comercio comercio = new Comercio();

        [HttpGet("AgregarTicket")]
        public IActionResult GetAgregarTicket(int tipo, string dni, int nroCC)
        {
            Ticket t = null;
            if (tipo == 1)
            {
                t = new Cliente(dni);
            }
            else if (tipo == 2)
            {
                CuentaCorriente cc = comercio.VerCC(nroCC);
                if (cc != null)
                {
                    t = new Pago(cc);
                }
                else
                {
                    return NotFound("No encontro la cuenta corriente");
                }
            }

            if (t != null)
            {
                comercio.AgregarTicket(t);
                TicketDTO dto = new TicketDTO(t);
                return Ok(dto);
            }

            return NoContent(); 
        }

        [HttpGet("AtenderTicket")]
        public IActionResult GetAtenderTicket(int tipo)
        {
            Ticket atendido=comercio.AtenderTicket(tipo);

            if (atendido != null)
            {
                TicketDTO dto = new TicketDTO(atendido);
                return Ok(dto);
            }

            return NotFound("No se encontraron tickets");
        }

        [HttpGet("AgregarCuentaCorriente")]
        public IActionResult GetAgregarCuentaCorriente(int nroCC, string dni)
        {
            CuentaCorriente cc=comercio.AgregarCuentaCorriente(nroCC, dni);

            if (cc != null) return Ok("La cuenta fue agregada");
            return NotFound();
        }

    }
}
