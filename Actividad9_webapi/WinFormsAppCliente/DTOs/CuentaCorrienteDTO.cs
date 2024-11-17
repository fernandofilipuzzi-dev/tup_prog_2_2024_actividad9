
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public CuentaCorrienteDTO()
        {
        }

        public CuentaCorrienteDTO(CuentaCorriente cc)
        {
            this.nroCuenta=cc.nroCuenta;

            if(cc.titular!=null)
                this.dni = cc.titular.DNI;
            this.saldo = cc.saldo;
        }

        public CuentaCorriente ToCuentaCorriente()
        {
            CuentaCorriente cc = new CuentaCorriente(nroCuenta, new Cliente(dni));
            return cc;
        }
    }
}
