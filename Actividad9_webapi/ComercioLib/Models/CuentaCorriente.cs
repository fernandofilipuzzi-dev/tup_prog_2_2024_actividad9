using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib.Models
{
    public class CuentaCorriente:IComparable<CuentaCorriente>
    {
        int nroCuenta;
        Cliente titular;
        double saldo;

        public CuentaCorriente(int nro, Cliente titular)
        {
            this.titular = titular;
            nroCuenta = nro;
        }

        public int CompareTo(CuentaCorriente? other)
        {
            return nroCuenta.CompareTo(other?.nroCuenta);
        }
    }
}
