using WinFormsAppCliente.Models;
using WinFormsAppCliente.Services;

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

                var ticket = await comercio.AgregarTicket(tipo, dni, cc);

                if (ticket != null)
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
                MessageBox.Show(ex.Message, "Error");
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

                    if (ticket != null)
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

        async private void btnExportarTicketsAtendidos_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Exportando tickets atendidos";
            saveFileDialog1.Filter = "Fichero csv|*.csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;

                FileStream fs = null;
                StreamWriter sw = null;
                try
                {
                    fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                    sw = new StreamWriter(fs);

                    int cant = await comercio.CantidadTicketsAtendido();

                    Console.WriteLine("tipo;numero;dni;ctaCte");
                    for (int idx = 0; idx < cant; idx++)
                    {
                        Ticket ticket = await comercio.VerTicketAtendido(idx);

                        if (ticket != null)
                        {
                            sw.WriteLine(ticket);// me valgo del tostring por polimorfismo
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {
                    if (sw != null) sw.Close();
                    if (fs != null) fs.Close();
                }
            }
        }

        async private void btnImportarCuentasCorrientes_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Importar cuentas corrientes";
            openFileDialog1.Filter = "Fichero csv|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                FileStream fs = null;
                StreamReader sr = null;
                try
                {
                    fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
                    sr = new StreamReader(fs);

                    //(Nro;dni;saldo).
                    sr.ReadLine();//descarto la primera linea

                    while (sr.EndOfStream == false)
                    {
                        string linea = sr.ReadLine();
                        string[] campos = linea.Split(';');

                        int nro = Convert.ToInt32(campos[0]);
                        string dni = campos[1];
                        double saldo = Convert.ToDouble(campos[2]);

                        await comercio.AgregarCuentaCorriente(nro, dni, saldo);//en el server haré las comprobaciones
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {
                    if (sr != null) sr.Close();
                    if (fs != null) fs.Close();
                }
            }
        }

        async private void btnActualizar_Click(object sender, EventArgs e)
        {
            //resuelve el problema si se cargan turnos por otro lado.
            try
            {
                listBox1.Items.Clear();

                //alternativa a la forma que se hizo las consultas para tickets atendidos
                List<Ticket> tickets = await comercio.VerTicketsSinAtender();
                listBox1.Items.AddRange(tickets.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            //me trae los tickets pendientes
            btnActualizar.PerformClick();
        }
    }
}
