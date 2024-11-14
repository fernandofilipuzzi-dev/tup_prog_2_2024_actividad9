using ComercioLib;
using ComercioLib.Models;
using Microsoft.AspNetCore.Mvc;
using webapiServicio.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapiServicio.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComercioController : ControllerBase
{
    //https://learn.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-9.0
    //https://stackoverflow.com/questions/37690114/how-to-return-a-specific-status-code-and-no-contents-from-controller

    readonly static Comercio comercio=new Comercio();

    [HttpGet("AgregarTicket")]
    public IActionResult GetAgregarTicket(string tipo, string dni, int ccNro)
    {
        if(tipo!="CLIENTE" && tipo!="PAGO" && (string.IsNullOrEmpty(dni)==true ^ ccNro==0)==false)
            return BadRequest("Los parámetros no son correctos");

        Ticket t = null;

        if (tipo == "CLIENTE")
        {
            t = new Cliente(dni);
        }
        else if (tipo == "PAGO")
        {
            CuentaCorriente cc = comercio.VerCuentaCorriente(ccNro);
            if (cc != null)
            {
                t = new Pago(cc);
            }
        }

        if (t != null)
        {
            comercio.AgregarTicket(t);
            return Ok("Ticket agregado exitosamente");
        }
        return NotFound("No se puedo agregar el ticket");
    }

    [HttpGet("AtenderTicket")]
    public IActionResult GetAtenderTicket(int tipoTicket)
    {
        Ticket t=comercio.AtenderTicket(tipoTicket);
        
        if(t==null)
            return NotFound("No se encontro ningun ticket");

        if (t != null)
        {
            TicketDTO result = new TicketDTO(t);
            return Ok(result);
        }
        return Ok();
    }

    [HttpGet("AgregarCuentaCorriente")]
    public IActionResult GetAgregarCuentaCorriente(int nro, string dni)
    {
        CuentaCorriente cc=comercio.AgregarCuentaCorriente(nro, dni);

        if (cc == null)
            return NoContent();

        return NotFound();
    }
}
