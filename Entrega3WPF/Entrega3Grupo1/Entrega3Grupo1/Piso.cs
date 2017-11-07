using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega3Grupo1
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


    }
}
