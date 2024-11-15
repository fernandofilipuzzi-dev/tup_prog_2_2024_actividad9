
namespace WinFormsAppCliente.Models
{
    abstract public class Ticket
    {
        public int nroOrden { get; set; }
        public DateTime fechaHora { get; set; }

        public override string ToString()
        {
            return $"{nroOrden};{fechaHora:dd/MM/yyy}";
        }

    }
}
