
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsAppCliente.Models;

namespace WinFormsAppCliente.DTOs
{
    public class CuentaCorrienteDTO
    {
        public int nroCuenta { get; set; }
        public int dni { get; set; }
        public double saldo { get; set; }

        public CuentaCorrienteDTO(CuentaCorriente cc)
        {
            this.nroCuenta=cc.nroCuenta;
            
            //falta terminar.
        }
    }
}
