using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComercioLib.Models
{
    public class CuentaCorriente : IComparable<CuentaCorriente>
    {
        int nroCuenta;
        Cliente titular;
        double saldo;

        public CuentaCorriente(int nroCuenta, Cliente titular)
        {
            this.nroCuenta = nroCuenta;
            this.titular = titular;
        }

        public int CompareTo(CuentaCorriente? other)
        {
            if(other !=null) return nroCuenta.CompareTo(other.nroCuenta);
            return 1;
        }

        public int VerNroCuenta()
        { 
            return nroCuenta;
        }

        public Cliente VerTitular()
        {
            return titular;
        }
    }
}
