using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionMall
{
    public class Negocio
    {
        public string nombreNegocio;
        public int numeroClientes;
        public int piso;
        public int precioArriendo;
        public double ganancias;
        public int horaApertura;
        public int horaCierre;
        public int stock;
        public int precioMax;
        public int precioMin;
        public int areaNegocio;
        public int numEmpleados;
        public int clientesDiaAnterior;
        public int clientesDelDia;
        public string cat;
        public string subcat;
        public double gananciatotal = 0;
        public int clientesTotales = 0;


        public Negocio(string nombreNegocio, int areaNegocio, int piso, int precioArriendo, int precioMin, int precioMax, int stock, int numEmpleados, int clientesDiaAnterior, int clientesDelDia, string cat, string subcat)
        {
            this.nombreNegocio = nombreNegocio;
            this.areaNegocio = areaNegocio;
            this.piso = piso;
            this.precioArriendo = precioArriendo;
            this.precioMax = precioMax;
            this.precioMin = precioMin;
            this.stock = stock;
            this.numEmpleados = numEmpleados;
            this.clientesDiaAnterior = clientesDiaAnterior;
            this.clientesDelDia = clientesDelDia;
            this.cat = cat;
            this.subcat = subcat;
        }

    }
}
