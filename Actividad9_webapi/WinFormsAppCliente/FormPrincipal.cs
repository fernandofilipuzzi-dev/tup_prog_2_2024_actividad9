using System.Net.Http.Json;
using System.Security.Policy;
using WinFormsAppCliente.DTOs;
using WinFormsAppCliente.Models;
using WinFormsAppCliente.Services;
using static System.Net.WebRequestMethods;

namespace WinFormsAppCliente
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        async private void btnAgregarTicket_Click(object sender, EventArgs e)
        {
            try
            {
                string dni = tbDNI.Text;
                int cc = 0;

                int tipo = 1;
                if (checkBox1.Checked == true)
                {
                    tipo = 2;
                    cc = Convert.ToInt32(tbCC.Text);
                }

                var comercio = new ComercioClientService();

                var ticket=comercio.AgregarTicket(tipo, dni, cc);

                if(ticket!=null)
                {
                    listBox1.Items.Add(ticket);
                    MessageBox.Show("Turno solicitado");
                }
                else
                {
                    MessageBox.Show("El turno fue rechazado.");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message,"Error");
            }
        }
        async private void btnAtenderCliente_Click(object sender, EventArgs e)
        {
            try
            {
                int tipo = -1;

                if (rbCompra.Checked) tipo = 1;
                else if (rbPago.Checked) tipo = 2;

                if (tipo > 0)
                {
                    string url = $"https://localhost:7202/api/Comercio/AtenderTicket?tipo={tipo}";

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

                        listBox1.Items.Remove(ticket);//me obliga a sobreescibir el equals!

                        //me falta agregar el ciekt primero en el listbox
                    }
                    else
                    {
                        //me faltan mejoras.

                        MessageBox.Show("no pudo quitarlo");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
    }
}
