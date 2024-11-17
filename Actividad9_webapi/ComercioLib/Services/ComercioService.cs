using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComercioLib.Models;

namespace ComercioLib.Services;

public class ComercioService
{
    Queue<Cliente> nuevosClientes = new Queue<Cliente>();
    Queue<Pago> nuevosP = new Queue<Pago>();
    List<CuentaCorriente> cuentasCorrientes = new List<CuentaCorriente>();
    List<Ticket> ticketsAtendidos=new List<Ticket>();

    public int CantidadTicketAtendidos 
    {
        get
        {
            return ticketsAtendidos.Count;
        }
    }

    public Ticket VerTicketAtendido(int idx)
    {
        if (idx >= 0 && idx <= CantidadTicketAtendidos)
            return ticketsAtendidos[idx];
        return null;
    }

    public void AgregarTicket(Ticket turno)
    {
        if (turno is Cliente)
        {
            nuevosClientes.Enqueue((Cliente)turno);
        }
        else if (turno is Pago)
        {
            nuevosP.Enqueue((Pago)turno);
        }
    }

    public Ticket AtenderTicket(int tipo)
    {
        Ticket ticket = null;
        if (tipo == 1)
        {
            if (nuevosClientes.Count >= 0)
                ticket = nuevosClientes.Dequeue();
        }
        else if (tipo == 2)
        {
            if (nuevosP.Count >= 0)
                ticket = nuevosP.Dequeue();
        }

        if (ticket !=null)
        {
            ticketsAtendidos.Add(ticket);
        }

        return ticket;
    }

    public CuentaCorriente VerCC(int nroCC)
    {
        CuentaCorriente cc = new CuentaCorriente(nroCC, null);
        cuentasCorrientes.Sort();
        int idx = cuentasCorrientes.BinarySearch(cc);
        if (idx >= 0) return cuentasCorrientes[idx];
        return null;
    }

    public CuentaCorriente AgregarCuentaCorriente(int nroCC, string dni)
    {
        CuentaCorriente cc = VerCC(nroCC);
        if (cc == null)
        {
            Cliente cliente = new Cliente(dni);
            cc = new CuentaCorriente(nroCC, cliente);
            cuentasCorrientes.Add(cc);
            return cc;
        }
        return null;
    }
}
