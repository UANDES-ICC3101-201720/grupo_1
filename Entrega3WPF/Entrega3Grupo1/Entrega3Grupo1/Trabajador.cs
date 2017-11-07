using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega3Grupo1
{
    class Trabajador
    {
        string nombreTrabajador;
        int rutTrabajador;
        int sueldo;

        public Trabajador(string nombreTrabajador, int rutTrabajador, int sueldo)
        {
            this.nombreTrabajador = nombreTrabajador;
            this.rutTrabajador = rutTrabajador;
            this.sueldo = sueldo;
        }
    }
}