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
        static void Main(string[] args)
        {  //Archivo 
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
                Negocio.CrearNegocio(p, negocios);
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
                    Negocio.CalcularClientes(n);
                    Negocio.CalcularGanancia(n);
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
