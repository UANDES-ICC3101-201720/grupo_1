using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulacionMall
{
    public class Negocio
    {
        string nombreNegocio;
        int numeroClientes;
        int piso;
        int precioArriendo;
        int ganancias;
        int horaApertura;
        int horaCierre;
        int stock;
        int precioMax;
        int precioMin;
        int areaNegocio;

        public Negocio(string nombreNegocio, int areaNegocio, int piso, int precioArriendo)
        {
            this.nombreNegocio = nombreNegocio;
            this.areaNegocio = areaNegocio;
            this.piso = piso;
            this.precioArriendo = precioArriendo;
        }

        public static void CrearNegocio(Piso p,List<Negocio>negocios)
        {
            int totalNegocio = p.numLocales;
            int areaTotal = 0;
                while (areaTotal <= p.areaPiso)
                {
                    Console.WriteLine("Ingrese el nombre del Local o Negocio: ");
                    string nombreNegocio = Console.ReadLine();
                    Console.WriteLine("Ingrese el area del Local o Negocio: ");
                    int areaNegocio = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese valor de arriendo del Local o Negocio por metro cuadrado: ");
                    int precioArriendo = (Convert.ToInt32(Console.ReadLine())) * areaNegocio;
                    if (areaTotal + areaNegocio <= p.areaPiso)
                    {
                        Negocio n = new Negocio(nombreNegocio, areaNegocio, p.numeroPiso, precioArriendo);
                        negocios.Add(n);
                        areaTotal += areaNegocio;
                    }
                    else
                    {
                        areaTotal += areaNegocio;
                    }
                }
        }
    }
}
