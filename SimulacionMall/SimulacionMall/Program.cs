using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SimulacionMall
{
    class Program
    {
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
            double ganancia = (ventaPromedio * n.clientesDelDia) - (n.numEmpleados + costoArriendo);
            n.ganancias = ganancia;
        }
        static void Main(string[] args)
        {
            //Archivo 
            FileStream fs = new FileStream("Reporte.txt", FileMode.OpenOrCreate);
            StreamWriter fw = new StreamWriter(fs);
            //Creacion del MALL
            int dia = 1;
            Console.WriteLine("Bienvenido a Mall Simulator");
            Console.WriteLine("Ingrese nombre del mall");
            string nombremall = Console.ReadLine();
            Console.WriteLine("Ingrese cantidad de horas que funciona el mall por dia");
            string horasfuncionamientostr = Console.ReadLine();
            int horasfuncionamiento = Int32.Parse(horasfuncionamientostr);
            new Mall(nombremall, horasfuncionamiento);



            //Creacion de los pisos
            Console.WriteLine("Ingrese numero de pisos");
            int NumPiso = Convert.ToInt32(Console.ReadLine());
            List<Piso> pisosNoSubt = new List<Piso>();
            List<Piso> pisosSubt = new List<Piso>();
            Piso.CrearPiso(NumPiso, pisosNoSubt, pisosSubt);
            List<Negocio> listadenegociostotal = new List<Negocio>();
        
            

            //Creacion Negocios

            foreach (Piso p in pisosNoSubt)
            {
                List<Negocio> negocios = new List<Negocio>();
                CrearNegocio(p, negocios);
                foreach (Negocio n in negocios)
                {
                    listadenegociostotal.Add(n);
                }

            }

            Console.ReadLine();

            //Simulacion
            int clientesTotales = 0;
            double gananciaTotal = 0;
            while (dia <= 10)
            {
                Console.WriteLine("Simulacion del dia: " + dia);
                fw.WriteLine("Simulacion del dia: " + dia);
                //Cantidad de clientes recepcionados y ganancias, promedio y del dia

                int clientesdeldia = 0;
                double gananciadeldia = 0;

                foreach (Negocio n in listadenegociostotal)
                {
                    CalcularClientes(n);
                    CalcularGanancia(n);
                    n.gananciatotal = n.gananciatotal + n.ganancias; //Ganancias seria las ganancias de cada dia del negocio
                    n.clientesTotales = n.clientesTotales + n.clientesDelDia;
                    clientesdeldia = clientesdeldia + n.clientesDelDia;
                    gananciadeldia = gananciadeldia + n.ganancias;

                }

                double gananciamaxima = -9999999999999999;
                double gananciaminima = 9999999999999;
                int clientesmaximos = 0;
                int clientesminimos = 999999999;
                string nombredelatiendacmax = "";
                string nombredelatiendacmin = "";
                string nombredelatiendagmax = "";
                string nombredelatiendagmin = "";

                //Locales con mayor y menor cantidad de clientes atendidos
                foreach (Negocio n in listadenegociostotal)
                {
                    if (n.clientesDelDia > clientesmaximos)
                    {
                        clientesmaximos = n.clientesDelDia;
                        nombredelatiendacmax = n.nombreNegocio;
                    }
                    if (n.clientesDelDia < clientesminimos)
                    {
                        clientesminimos = n.clientesDelDia;
                        nombredelatiendacmin = n.nombreNegocio;
                    }
                    if (n.ganancias > gananciamaxima)
                    {
                        gananciamaxima = n.ganancias;
                        nombredelatiendagmax = n.nombreNegocio;
                    }
                    if (n.ganancias < gananciaminima)
                    {
                        gananciaminima = n.ganancias;
                        nombredelatiendagmin = n.nombreNegocio;
                    }
                }

                clientesTotales = clientesTotales + clientesdeldia;
                gananciaTotal = gananciaTotal + gananciadeldia;

                Console.WriteLine("La cantidad de clientes del dia " + dia + " fue de " + clientesdeldia);
                Console.WriteLine("La cantidad de clientes promedio hasta el dia " + dia + " es de" + (clientesTotales / dia));

                Console.WriteLine("La ganancia del dia " + dia + " fue de " + gananciadeldia);
                Console.WriteLine("La ganancia promedio hasta el dia " + dia + " es de " + (gananciaTotal / dia));

                Console.WriteLine("La tienda con mas clientes en el dia " + dia + " fue " + nombredelatiendacmax);
                Console.WriteLine("La tienda con menos clientes en el dia " + dia + " fue " + nombredelatiendacmin);

                Console.WriteLine("La tienda con mas ganancias en el dia " + dia + " fue " + nombredelatiendagmax + " con una ganancia de " + gananciamaxima);
                Console.WriteLine("La tienda con menos ganancias en el dia " + dia + " fue " + nombredelatiendagmax + "con una ganancia de " + gananciaminima);

                fw.WriteLine("La cantidad de clientes del dia " + dia + " fue de " + clientesdeldia);
                fw.WriteLine("La cantidad de clientes promedio hasta el dia " + dia + " es de" + (clientesTotales / dia));

                fw.WriteLine("La ganancia del dia " + dia + " fue de " + gananciadeldia);
                fw.WriteLine("La ganancia promedio hasta el dia " + dia + " es de " + (gananciaTotal / dia));

                fw.WriteLine("La tienda con mas clientes en el dia " + dia + " fue " + nombredelatiendacmax);
                fw.WriteLine("La tienda con menos clientes en el dia " + dia + " fue " + nombredelatiendacmin);

                fw.WriteLine("La tienda con mas ganancias en el dia " + dia + " fue " + nombredelatiendagmax + " con una ganancia de " + gananciamaxima);
                fw.WriteLine("La tienda con menos ganancias en el dia " + dia + " fue " + nombredelatiendagmax + "con una ganancia de " + gananciaminima);

                dia = dia + 1;

            }


            Console.WriteLine("En cuanto al resumen total: ");
            fw.WriteLine("En cuanto al resumen total: ");
            double gananciatotalmaxima = -99999999999999;
            double gananciatotalminima = 999999999999999; //Numero muy alto, asumimos que el usuario no va a poner algo mas grande que esto
            string nombregananciamax = "";
            string nombregananciamin = "";

            foreach (Negocio n in listadenegociostotal)
            {
                if (n.gananciatotal > gananciatotalmaxima)
                {
                    gananciatotalmaxima = n.gananciatotal;
                    nombregananciamax = n.nombreNegocio;
                }
                if (n.gananciatotal < gananciatotalminima)
                {
                    gananciatotalminima = n.gananciatotal;
                    nombregananciamin = n.nombreNegocio;
                }
            }

            Console.WriteLine("El negocio que mas ganancia tuvo fue  " + nombregananciamax + "con una ganancia total de " + gananciatotalmaxima);
            Console.WriteLine("El negocio que menos ganancia tuvo fue " + nombregananciamin + "con una ganancia total de " + gananciatotalminima);
            fw.WriteLine("El negocio que mas ganancia tuvo fue  " + nombregananciamax + " con una ganancia total de " + gananciatotalmaxima);
            fw.WriteLine("El negocio que menos ganancia tuvo fue " + nombregananciamin + " con una ganancia total de " + gananciatotalminima);
            Console.ReadLine();
            fw.Close();
            fs.Close();
        }
    }
}
