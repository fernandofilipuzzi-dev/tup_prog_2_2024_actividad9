using ComercioLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib.DTOs
{
    public class CuentaCorrienteDTO
    {
        public int nroCuenta { get; set; }
        public int dni { get; set; }
        public double saldo { get; set; }

        public CuentaCorrienteDTO(CuentaCorriente cc)
        {
            this.nroCuenta=cc.VerNroCuenta();

            if (cc.VerTitular() != null)
            {
                this.dni = cc.VerTitular().VerDNI();
            }

            this.saldo = saldo;
        }
    }
}
