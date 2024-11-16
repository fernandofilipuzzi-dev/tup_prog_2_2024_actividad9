using System.Net;
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

        ComercioClientService comercio = new ComercioClientService();

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

                var ticket=await comercio.AgregarTicket(tipo, dni, cc);

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
                    var ticket = await comercio.AtenderTicket(tipo);

                    if(ticket!=null)
                    { 
                        listBox1.Items.Remove(ticket);//me obliga a sobreescibir el equals!
                    }
                    else
                    {
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
