using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp.DTOs;

public class Pago :Ticket
{
    CuentaCorriente ficha;
    int dni;
    static int nroInicio = 0;

 
    public Pago(CuentaCorriente cc)
    {
            nroOrden = ++nroInicio;
            cc = ficha;
    }
}
