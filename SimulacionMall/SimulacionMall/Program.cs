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


            //Creacion Negocios
            foreach (Piso p in pisosNoSubt)
            {
                List<Negocio> negocios = new List<Negocio>();
                Negocio.CrearNegocio(p, negocios);
            }
            Console.ReadLine();
        }
    }
}
