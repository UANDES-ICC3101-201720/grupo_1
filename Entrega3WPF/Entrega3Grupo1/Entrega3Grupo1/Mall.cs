using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega3Grupo1
{
    public class Mall
    {
        string nombreMall;
        int horaFuncionamiento;
        int sueldoPromedio;

        public Mall(string nombreMall, int horaFuncionamiento, int sueldoPromedio)
        {
            this.nombreMall = nombreMall;
            this.horaFuncionamiento = horaFuncionamiento;
            List<Piso> pisos = new List<Piso>();
            this.sueldoPromedio = sueldoPromedio;
        }
    }
}
