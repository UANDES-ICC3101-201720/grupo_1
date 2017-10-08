using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionMall
{
    class Program
    {
        static void Main(string[] args)
        { //Creacion del MALL
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
                Console.WriteLine("Simulacion del dia" + dia);
                //Cantidad de clientes recepcionados y ganancias, promedio y del dia

                int clientesdeldia = 0;                
                double gananciadeldia = 0;

                foreach (Negocio n in listadenegociostotal)
                {
                    Negocio.CalcularClientes(n);
                    Negocio.CalcularGanancia(n);
                    clientesdeldia = clientesdeldia + n.clientesDelDia;
                    gananciadeldia = gananciadeldia + n.ganancias;
                }

                clientesTotales = clientesTotales + clientesdeldia;
                gananciaTotal = gananciaTotal + gananciadeldia;

                Console.WriteLine("La cantidad de clientes del dia " + dia + "fue de " + clientesdeldia);
                Console.WriteLine("La cantidad de clientes promedio hasta el dia " + dia + "es de" + (clientesTotales / dia));

                Console.WriteLine("La ganancia del dia " + dia + "fue de " + gananciadeldia);
                Console.WriteLine("La ganancia promedio hasta el dia " + dia + " es de " + (gananciaTotal / dia));


                //Mayor y menor cantidad de ganancia y clientes
                
                dia = dia + 1;

            }
            Console.ReadLine();




            



            



        }
    }
}
