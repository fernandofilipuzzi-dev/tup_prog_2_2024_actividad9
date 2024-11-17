namespace WinFormsAppCliente.Models
{
    public class Cliente:Ticket
    {

        public int DNI { get; set; }

        public Cliente() { }
        public Cliente(int DNI) { this.DNI = DNI; }

        public override string ToString()
        {
            //tipo;numero;dni;ctaCte
            return $"CLIENTE;{base.ToString()};{DNI};";//falta
        }

        //esto lo hice porque cuando extraigo del listbox compara usando el equals y no por referencia.
        //cuando se serializa en json se pierde la identidad del objeto por memoria
        public override bool Equals(object? obj)
        {
            return obj is Cliente && nroOrden == ((Cliente)obj).nroOrden;
        }


    }
}
