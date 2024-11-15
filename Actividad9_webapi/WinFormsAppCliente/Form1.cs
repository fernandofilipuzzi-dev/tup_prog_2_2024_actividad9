using System.Security.Policy;

namespace WinFormsAppCliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dni = textBox1.Text;
            int tipo = 1;

            using var cliente=new HttpClient();

            string url = $"https://localhost:7202/api/Comercio/AgregarTicket?tipo={tipo}&dni={dni}&nroCC=0";

            HttpRequestMessage consulta = new HttpRequestMessage();
            consulta.Method = HttpMethod.Get;
            consulta.RequestUri = new Uri(url);

            HttpResponseMessage respuesta= cliente.Send(consulta);

            if (respuesta.IsSuccessStatusCode)
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("no ok!");
            }
        }
    }
}
