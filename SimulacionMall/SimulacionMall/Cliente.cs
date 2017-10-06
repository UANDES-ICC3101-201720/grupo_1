using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionMall
{
    class Cliente
    {
        string nombreCliente;
        string rutCliente;
        int dinero;
        string formaDeLlegada;

        public Cliente(string nombreCliente, string rutCliente, int dinero, string formaDeLlegada)
        {
            this.nombreCliente = nombreCliente;
            this.rutCliente = rutCliente;
            this.dinero = dinero;
            this.formaDeLlegada = formaDeLlegada;
            List<Negocio> planDeCompra = new List<Negocio>();
            List<Negocio> visitados = new List<Negocio>();
        } 
    }
}
