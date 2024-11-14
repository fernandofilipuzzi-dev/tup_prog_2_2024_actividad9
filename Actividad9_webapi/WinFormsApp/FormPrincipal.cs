using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp.DTOs;
using static System.Net.WebRequestMethods;

namespace WinFormsApp
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        async private void button1_Click(object sender, EventArgs e)
        {
            using var cliente = new HttpClient() ;
            
            string dni = textBox1.Text;

            string tipo = "CLIENTE";
            string url = $"https://localhost:7191/api/Comercio/AgregarTicket?tipo={tipo}&dni={dni}";

            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };

            HttpResponseMessage response = cliente.Send(request);

            string mensaje = "No exito";
            if (response.IsSuccessStatusCode)
            {
                mensaje = "exito!";
            }
            MessageBox.Show(mensaje);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using var cliente = new HttpClient();

            int tipo = 1;

            
            string url = $"https://localhost:7191/api/Comercio/AtenderTicket?tipoTicket={tipo}";
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };

            HttpResponseMessage response = cliente.Send(request); 


            string mensaje = "No exito";
            if (response.IsSuccessStatusCode)
            {
                var t = response.Content.ReadFromJsonAsync<TicketDTO>();
                
            }
            MessageBox.Show(mensaje);
        }
    }
}
