using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.DTOs;

abstract public class Ticket
{
    protected int nroOrden ;
    public DateTime FechaHora;

    public int VerNRO() 
    {
        return nroOrden;
    }

    public DateTime VerFecha()
    {
        return FechaHora;
    }
}
