using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionMall
{
    public class Piso
    {
        public int numeroPiso;
        public int areaPiso;
        public int numLocales;

        public Piso(int numeroPiso, int areaPiso, int numLocales)
        {
            this.numeroPiso = numeroPiso;
            this.areaPiso = areaPiso;
            this.numLocales = numLocales;
            List<Negocio> tiendasPorPiso = new List<Negocio>();
        }
        public static void CrearPiso(int numPisos, List<Piso> pisosNoSubt, List<Piso> pisosSubt)
        {
            int pUp = 0;
            int p = 0;
            int pDown = 0;
            while (p <= numPisos)
            {
                Console.WriteLine("Si desea crear un piso sobre nivel ingrese 1, si desea uno subterraneo ingrese 2");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el area de este piso en metros cuadrados");
                int y = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese el numero de Locales para este piso: ");
                int z = Convert.ToInt32(Console.ReadLine());
                if (x == 2)
                {
                    pDown = pDown - 1;
                    Piso piso = new Piso(pDown, y,z);
                    pisosSubt.Add(piso);
                }
                else if (x == 1)
                {
                    pUp = pUp + 1;
                    Piso piso = new Piso(pUp, y,z);
                    pisosNoSubt.Add(piso);
                }
            }
        }

    }
}
