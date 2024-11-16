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
        async public Task<Ticket> AgregarTicket(int tipo, string dni, int cc)
        {
            using var cliente = new HttpClient();

            #region consulta
            string url = $"https://localhost:7202/api/Comercio/AgregarTicket?tipo={tipo}&DNI={dni}&nroCC={cc}";
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
            return null;
        }
    }
}
