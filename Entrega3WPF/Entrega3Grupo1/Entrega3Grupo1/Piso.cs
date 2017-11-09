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
        public List<Negocio> tiendasPorPiso;
        public int cantidadTiendas;
        public int tiendasUsadas;

        public Piso(int numeroPiso, int areaPiso, List<Negocio> tiendasPorPiso, int cantidadTiendas, int tiendasUsadas)
        {
            this.numeroPiso = numeroPiso;
            this.areaPiso = areaPiso;
            this.tiendasPorPiso = tiendasPorPiso;
            this.cantidadTiendas = cantidadTiendas;
            this.tiendasUsadas = tiendasUsadas;
        
        }


    }
}