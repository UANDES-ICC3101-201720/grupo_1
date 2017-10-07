using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionMall
{
    class Cliente
    {
        string nombreCliente;
        string rutCliente;
        int dinero;
        int piso;
        string formaDeLlegada;
        List<Negocio> plandeCompra;
        List<Negocio> visitados;

        public Cliente(string nombreCliente, string rutCliente, int dinero, string formaDeLlegada)
        {
            this.nombreCliente = nombreCliente;
            this.rutCliente = rutCliente;
            this.dinero = dinero;
            this.formaDeLlegada = formaDeLlegada;
            this.piso = piso;
            List<Negocio> planDeCompra = new List<Negocio>();
            List<Negocio> visitados = new List<Negocio>();
        } 
        public void visitarTiendas(Cliente c)
        {
            foreach(Negocio negocio in c.plandeCompra)
            {
                if (c.visitados.Contains(negocio) = false)
                {
                    c.visitados.Add(negocio);
                    

                }
            }
        }

        
            
    }
}
