using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionMall
{
    public class Negocio
    { public string nombreNegocio;
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


        public static void CrearNegocio(Piso p, List<Negocio> negocios)
        {
            int totalNegocio = p.numLocales;
            int areaTotal = 0;
            while (areaTotal < p.areaPiso)
            {
                string categoria = "";
                string subcategoria = "";
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
                    Negocio n = new Negocio(nombreNegocio, areaNegocio, p.numeroPiso, precioArriendo, precioMin, precioMax, stock, numEmpleados, clientesDiaAnterior, clientesDelDia, categoria, subcategoria);
                    Console.WriteLine("Ingrese la Categoria del Local o Negocio");
                    Console.WriteLine("Ingrese 1  Comercial, 2 para Comida y 3 para Entretencion");
                    int y = Convert.ToInt32(Console.ReadLine());
                    if (y == 1)
                    {
                        Console.WriteLine("Ingrese la Subcategoria del Local o Negocio");
                        Console.WriteLine("Ingrese 1 para Ropa, 2 para Hogar, 3 para Alimento, 4 para Ferreteria o 5 para Tecnologia");
                        int x = Convert.ToInt32(Console.ReadLine());
                        if (x == 1) { n.subcat = "Ropa"; }
                        else if (x == 2) { n.subcat = "Hogar"; }
                        else if (x == 3) { n.subcat = "Alimento"; }
                        else if (x == 4) { n.subcat = "Ferreteria"; }
                        else if (x == 5) { n.subcat = "Tecnologia"; }
                        n.cat = "Comercial";
                    }
                    else if (y == 2)
                    {
                        Console.WriteLine("Ingrese la Subcategoria del Local o Negocio");
                        Console.WriteLine("Ingrese 1 para Rapida o 2 para Restaurant");
                        int x = Convert.ToInt32(Console.ReadLine());
                        if (x == 1) { n.subcat = "Rapida"; }
                        else if (x == 2) { n.subcat = "Restaurant"; }
                        n.cat = "Comida";
                    }
                    else if (y == 3)
                    {
                        Console.WriteLine("Ingrese la Subcategoria del Local o Negocio");
                        Console.WriteLine("Ingrese 1 para Cine, 2 para Juegos o 3 para Bowling");
                        int x = Convert.ToInt32(Console.ReadLine());
                        if (x == 1) { n.subcat = "Cinea"; }
                        else if (x == 2) { n.subcat = "Juegost"; }
                        else if (x == 3) { n.subcat = "Bowling"; }
                        n.cat = "Juego";
                    }
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
        public static void CalcularGanancia(Negocio n)
        {
            Random rn = new Random();
            int ventaPromedio = rn.Next(n.precioMin, n.precioMax);
            int costoArriendo = n.precioArriendo * n.areaNegocio;
            double ganancia = ventaPromedio * n.clientesDelDia - (n.numEmpleados + costoArriendo);
            n.ganancias = ganancia;
        }
    }
}
