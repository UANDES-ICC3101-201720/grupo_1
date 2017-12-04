using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega3Grupo1
{   [Serializable]
    public class Negocio
    {
        public List<double> listaGanancias;
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


        public Negocio(string nombreNegocio, int areaNegocio, int piso, int precioArriendo, int precioMin, int precioMax, int stock, int numEmpleados, string cat, string subcat, int clientesDiaAnterior, int clientesDelDia, List<double> listaGanancias)
        {
            this.nombreNegocio = nombreNegocio;
            this.areaNegocio = areaNegocio;
            this.piso = piso;
            this.precioArriendo = precioArriendo;
            this.precioMax = precioMax;
            this.precioMin = precioMin;
            this.stock = stock;
            this.numEmpleados = numEmpleados;
            this.cat = cat;
            this.subcat = subcat;
            this.clientesDiaAnterior = clientesDiaAnterior;
            this.clientesDelDia = clientesDelDia;
            this.listaGanancias = listaGanancias;
        }
        public override string ToString()
        {
            return "Nombre: " + nombreNegocio + " | Cantidad de Empleados: " + numEmpleados + " | Categoria: " + cat + " | Piso: " + piso + " | Area del Local: " + areaNegocio + " | Precio Min/Max: " + precioMin + "/" + precioMax + " | Costo arriendo: " + precioArriendo;
        }
    }
}