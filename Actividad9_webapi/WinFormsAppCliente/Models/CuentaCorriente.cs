

namespace WinFormsAppCliente.Models
{
    public class CuentaCorriente 
    {
        public int nroCuenta { get; set; }
        public Cliente titular { get; set; }
        public double saldo { get; set; }

        public CuentaCorriente() { }
        public CuentaCorriente(int nroCC, Cliente titular)
        {
            nroCuenta = nroCC;
            this.titular = titular;
        }

    }
}
