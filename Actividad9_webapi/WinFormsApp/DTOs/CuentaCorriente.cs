

namespace WinFormsApp.DTOs;

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
