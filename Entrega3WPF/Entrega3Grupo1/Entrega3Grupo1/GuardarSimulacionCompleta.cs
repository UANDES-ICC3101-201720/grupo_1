using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entrega3Grupo1
{
    [Serializable]
    public class GuardarSimulacionCompleta
    {
        public Mall a;
        public List<Negocio> todosLosNegocios;
        public List<Piso> pisoSobreNivel;
        public List<Piso> pisoSubt;
        public int contadorPisosSobre;
        public int contadorPisosSub;

        public GuardarSimulacionCompleta(Mall a,List<Negocio> todosLosNegocios, List<Piso> pisoSobreNivel, List<Piso> pisoSubt, int contadorPisosSobre, int contadorPisosSub)
        {
            this.a = a;
            this.todosLosNegocios = todosLosNegocios;
            this.pisoSobreNivel = pisoSobreNivel;
            this.pisoSubt = pisoSubt;
            this.contadorPisosSobre = contadorPisosSobre;
            this.contadorPisosSub = contadorPisosSub;
        }
    }
}
