using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionMall
{
    public class Negocio
    {
        string nombreNegocio;
        int numeroClientes;
        int piso;
        int precioArriendo;
        int ganancias;
        int horaApertura;
        int horaCierre;
        int stock;
        int precioMax;
        int precioMin;
        int areaNegocio;
        int numEmpleados;
        int clientesDiaAnterior;
        int clientesDelDia;

        public Negocio(string nombreNegocio, int areaNegocio, int piso, int precioArriendo, int precioMin, int precioMax, int stock, int numEmpleados, int clientesDiaAnterior, int clientesDelDia)
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
        }


        public static void CrearNegocio(Piso p, List<Negocio> negocios)
        {
            int totalNegocio = p.numLocales;
            int areaTotal = 0;
            while (areaTotal <= p.areaPiso)
            {
                Console.WriteLine("Ingrese el nombre del Local o Negocio: ");
                string nombreNegocio = Console.ReadLine();
                Console.WriteLine("Ingrese el area del Local o Negocio: ");
                int areaNegocio = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese valor de arriendo del Local o Negocio por metro cuadrado: ");
                int precioArriendo = (Convert.ToInt32(Console.ReadLine())) * areaNegocio;
                Console.WriteLine("Ingrese precio minimo del Local o Negocio");
                int precioMin = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese precio maximo del Local o Negocio");
                int precioMax = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese stock del Local o Negocio");
                int stock = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el numero de Empleados del Local o Negocio");
                int numEmpleados = Convert.ToInt32(Console.ReadLine());
                int clientesDiaAnterior = 0;
                int clientesDelDia = 0;
                if (areaTotal + areaNegocio <= p.areaPiso)
                {
                    Negocio n = new Negocio(nombreNegocio, areaNegocio, p.numeroPiso, precioArriendo, precioMin, precioMax, stock, numEmpleados, clientesDiaAnterior, clientesDelDia);
                    negocios.Add(n);
                    areaTotal += areaNegocio;
                }
                else
                {
                    areaTotal += areaNegocio;
                }
            }
        }
        public static void CalcularClientes(Negocio n)
        {
            Random rn = new Random();
            int promedioPrecios = (n.precioMin + n.precioMax) / 2;
            int cMAX = Convert.ToInt32(n.clientesDiaAnterior + (n.areaNegocio / 10.0) * (((Math.Max((100 - promedioPrecios), 0)) / 100.0) * n.numEmpleados));
            n.clientesDelDia = rn.Next(0, cMAX);
            n.clientesDiaAnterior = n.clientesDelDia;
        }
        public static double CalcularGanancia(Negocio n)
        {
            Random rn = new Random();
            int ventaPromedio = rn.Next(n.precioMin, n.precioMax);
            int costoArriendo = n.precioArriendo * n.areaNegocio;
            double ganancia = ventaPromedio * n.clientesDelDia - (n.numEmpleados + costoArriendo);
            return ganancia;
        }
    }
}
