using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test
{
    public class CuentaBancaria
    {
        private int NumeroCuenta { get; set; }
        private decimal Saldo { get; set; }
        public CuentaBancaria(string NumeroCuenta)
        {
            this.NumeroCuenta = NumeroCuenta;
        }
        public void Ingreso(decimal ingreso)
        {
            Saldo += ingreso;
        }

    }
}