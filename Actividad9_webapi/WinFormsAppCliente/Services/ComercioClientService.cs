using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppCliente.Models;
using WinFormsAppCliente.DTOs;

namespace WinFormsAppCliente.Services
{
    public class ComercioClientService
    {

        //string urlBase = "https://localhost:7202";

        //api publicada
        string urlBase = "http://comercioturnos.somee.com";

        async public Task<Ticket> AgregarTicket(int tipo, string dni, int cc)
        {
            using var cliente = new HttpClient();

            if (string.IsNullOrEmpty(dni)) dni = "0";

            #region consulta
            string url = $"{urlBase}/api/Comercio/AgregarTicket?tipo={tipo}&DNI={dni}&nroCC={cc}";
            HttpRequestMessage consulta = new HttpRequestMessage();
            consulta.Method = HttpMethod.Get;
            consulta.RequestUri = new Uri(url);
            #endregion

            #region llamada y respuesta
            HttpResponseMessage respuesta = cliente.Send(consulta);
            #endregion

            if (respuesta.IsSuccessStatusCode)
            {
                //ver que al metodo le coloque async adelante - linea 16
                //ver que en 36 tuve que coloar await 
                //esto es asi porque readFromjsonasync es un metodo asincrono
                TicketDTO dto = await respuesta.Content.ReadFromJsonAsync<TicketDTO>();
                Ticket ticket = dto.ToTicket();
                return ticket;
            }
            else
            {
                throw new Exception(respuesta.ReasonPhrase);
            }
        }

        async public Task<Ticket> AtenderTicket(int tipo)
        {
            string url = $"{urlBase}/api/Comercio/AtenderTicket?tipo={tipo}";

            using HttpClient cliente = new HttpClient();

            HttpRequestMessage consulta = new HttpRequestMessage();
            consulta.RequestUri = new Uri(url);
            consulta.Method = HttpMethod.Get;

            HttpResponseMessage respuesta = cliente.Send(consulta);

            if (respuesta.IsSuccessStatusCode)
            {
                //los metodos asincronocs me obligan a usar await y async 
                TicketDTO dto = await respuesta.Content.ReadFromJsonAsync<TicketDTO>();

                Ticket ticket = dto.ToTicket();
                return ticket;
            }
            else
            {
                throw new Exception(respuesta.ReasonPhrase);
            }
        }

        //en estos casos es mejor pedir todos los tickets juntos - pero para ilustrar
        //la forma de usarlo en prog2 usamos esto de verticket y cantidadticket
        async public Task<Ticket> VerTicketAtendido(int idx)
        {
            string url = $"{urlBase}/api/Comercio/VerTicketAtendido?idx={idx}";

            using HttpClient cliente = new HttpClient();

            HttpRequestMessage consulta = new HttpRequestMessage();
            consulta.RequestUri = new Uri(url);
            consulta.Method = HttpMethod.Get;

            HttpResponseMessage respuesta = cliente.Send(consulta);

            if (respuesta.IsSuccessStatusCode)
            {
                //los metodos asincronocs me obligan a usar await y async 
                TicketDTO dto = await respuesta.Content.ReadFromJsonAsync<TicketDTO>();

                Ticket ticket = dto.ToTicket();
                return ticket;
            }
            else
            {
                throw new Exception(respuesta.ReasonPhrase);
            }
        }
        
        async public Task<int> CantidadTicketsAtendido()
        {
            string url = $"{urlBase}/api/Comercio/CantidadTicketsAtendidos";

            using HttpClient cliente = new HttpClient();

            HttpRequestMessage consulta = new HttpRequestMessage();
            consulta.RequestUri = new Uri(url);
            consulta.Method = HttpMethod.Get;

            HttpResponseMessage respuesta = cliente.Send(consulta);

            if (respuesta.IsSuccessStatusCode)
            {
                //los metodos asincronocs me obligan a usar await y async 
                int cantidad = await respuesta.Content.ReadFromJsonAsync<int>();

                return cantidad;
            }
            else
            {
                throw new Exception(respuesta.ReasonPhrase);
            }
        }

        async public Task AgregarCuentaCorriente(int nroCC, string dni, double saldo)
        {
            string url = $"{urlBase}/api/Comercio/AgregarCuentaCorriente?nroCC={nroCC}&dni={dni}&saldo={saldo}";

            using HttpClient cliente = new HttpClient();

            HttpRequestMessage consulta = new HttpRequestMessage();
            consulta.RequestUri = new Uri(url);
            consulta.Method = HttpMethod.Get;

            HttpResponseMessage respuesta = cliente.Send(consulta);

            if (respuesta.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new Exception(respuesta.ReasonPhrase);
            }
        }

        async public Task<List<Ticket>> VerTicketsSinAtender()
        {
            List<Ticket> tickets=new List<Ticket>();

            string url = $"{urlBase}/api/Comercio/VerTicketsSinAtender";

            using HttpClient cliente = new HttpClient();

            HttpRequestMessage consulta = new HttpRequestMessage();
            consulta.RequestUri = new Uri(url);
            consulta.Method = HttpMethod.Get;

            HttpResponseMessage respuesta = cliente.Send(consulta);

            if (respuesta.IsSuccessStatusCode)
            {
                //los metodos asincronocs me obligan a usar await y async 
                List<TicketDTO> dtos = await respuesta.Content.ReadFromJsonAsync<List<TicketDTO>>();

                foreach (TicketDTO dto in dtos)
                {
                    tickets.Add( dto.ToTicket() );
                }
                
                return tickets;
            }
            else
            {
                throw new Exception(respuesta.ReasonPhrase);
            }
        }
    }
}
