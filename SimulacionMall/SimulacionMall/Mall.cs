using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionMall
{
    public class Mall
    {
        string nombreMall;
        int horaFuncionamiento;

        public Mall(string nombreMall, int horaFuncionamiento)
        {
            this.nombreMall = nombreMall;
            this.horaFuncionamiento = horaFuncionamiento;
            List<Piso> pisos = new List<Piso>();
        }
    }
}
