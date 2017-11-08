using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Entrega3Grupo1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<Piso> pisoSobreNivel = new List<Piso>();
        List<Piso> pisoSubt = new List<Piso>();
        int contadorPisosSobre = 1;
        int contadorPisosSub = -1;
        public MainWindow()
        {
            InitializeComponent();
            Bienvenido.Visibility = Visibility.Visible;
            Inicio.Visibility = Visibility.Visible;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            CrearPisoSobre.Visibility = Visibility.Hidden;
            CrearPisoSub.Visibility = Visibility.Hidden;
            FinalizarPisos.Visibility = Visibility.Hidden;
            NombreNegocio.Visibility = Visibility.Hidden;
            PrecioMax.Visibility = Visibility.Hidden;
            PrecioMin.Visibility = Visibility.Hidden;
            ValorArriendo.Visibility = Visibility.Hidden;
            Categoria.Visibility = Visibility.Hidden;
            SubCategoria.Visibility = Visibility.Hidden;
            CantidadEmpleados.Visibility = Visibility.Hidden;
            AreaNegocio.Visibility = Visibility.Hidden;
            Stock.Visibility = Visibility.Hidden;
            BotonAgregarNegocio.Visibility = Visibility.Hidden;
            BotonFinalizarNegocios.Visibility = Visibility.Hidden;
        }

        private void Inicio_Click(object sender, RoutedEventArgs e)
        {
            Bienvenido.Visibility = Visibility.Hidden;
            Inicio.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Visible;
            TxtBoxNombreMall.Visibility = Visibility.Visible;
            LabelHoraMall.Visibility = Visibility.Visible;
            LabelNombreMall.Visibility = Visibility.Visible;
            CrearMall.Visibility = Visibility.Visible;


        }


        private void CrearMall_Click(object sender, RoutedEventArgs e)
        {
            Bienvenido.Visibility = Visibility.Hidden;
            Inicio.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Visible;
            CrearPisoSobreNivel.Visibility = Visibility.Visible;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            string nombre = TxtBoxNombreMall.Text;
            int horas = Convert.ToInt32(TxtBoxHorasMall.Text);
            new Mall(nombre, horas);
            CrearPisoSobreNivel.Visibility = Visibility.Visible;
            CrearSubterraneo.Visibility = Visibility.Visible;
            FinalizarPisos.Visibility = Visibility.Visible;
        }

        private void CrearPisoSobreNivel_Click(object sender, RoutedEventArgs e)
        {
            Bienvenido.Visibility = Visibility.Hidden;
            Inicio.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Hidden;
            LabelAreaPiso.Visibility = Visibility.Visible;
            AreaPiso.Visibility = Visibility.Visible;
            CrearPisoSobre.Visibility = Visibility.Visible;
            FinalizarPisos.Visibility = Visibility.Hidden;

        }


        private void CrearPisoSobre_Click(object sender, RoutedEventArgs e)
        {
            List<Negocio> negocio = new List<Negocio>();
            Piso piso = new Piso(contadorPisosSobre, Convert.ToInt32(AreaPiso.Text), negocio);
            pisoSobreNivel.Add(piso);
            Bienvenido.Visibility = Visibility.Hidden;
            Inicio.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Hidden;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Hidden;
            CrearPisoSobre.Visibility = Visibility.Hidden;
            NombreNegocio.Visibility = Visibility.Visible;
            PrecioMax.Visibility = Visibility.Visible;
            PrecioMin.Visibility = Visibility.Visible;
            ValorArriendo.Visibility = Visibility.Visible;
            Categoria.Visibility = Visibility.Visible;
            SubCategoria.Visibility = Visibility.Visible;
            CantidadEmpleados.Visibility = Visibility.Visible;
            AreaNegocio.Visibility = Visibility.Visible;
            Stock.Visibility = Visibility.Visible;
            FinalizarPisos.Visibility = Visibility.Hidden;
            BotonAgregarNegocio.Visibility = Visibility.Visible;
            BotonFinalizarNegocios.Visibility = Visibility.Visible;
            AreaPiso.Clear();
            contadorPisosSobre += 1;
        }

        private void CrearSubterraneo_Click(object sender, RoutedEventArgs e)
        {
            Bienvenido.Visibility = Visibility.Hidden;
            Inicio.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Hidden;
            LabelAreaPiso.Visibility = Visibility.Visible;
            AreaPiso.Visibility = Visibility.Visible;
            CrearPisoSobre.Visibility = Visibility.Hidden;
            CrearPisoSub.Visibility = Visibility.Visible;
            FinalizarPisos.Visibility = Visibility.Hidden;

        }

        private void CrearPisoSub_Click(object sender, RoutedEventArgs e)
        {
            List <Negocio> nada = new List<Negocio>();
            Piso piso = new Piso(contadorPisosSub, Convert.ToInt32(AreaPiso.Text), nada);
            pisoSubt.Add(piso);
            pisoSobreNivel.Add(piso);
            Bienvenido.Visibility = Visibility.Hidden;
            Inicio.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Visible;
            CrearPisoSobreNivel.Visibility = Visibility.Visible;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Visible;
            CrearSubterraneo.Visibility = Visibility.Visible;
            CrearPisoSobre.Visibility = Visibility.Hidden;
            CrearPisoSub.Visibility = Visibility.Hidden;
            FinalizarPisos.Visibility = Visibility.Visible;
            AreaPiso.Clear();
            contadorPisosSub -= 1;
        }

        private void FinalizarPisos_Click(object sender, RoutedEventArgs e)
        {
                Bienvenido.Visibility = Visibility.Hidden;
                Inicio.Visibility = Visibility.Hidden;
                TxtBoxHorasMall.Visibility = Visibility.Hidden;
                TxtBoxNombreMall.Visibility = Visibility.Hidden;
                LabelHoraMall.Visibility = Visibility.Hidden;
                LabelNombreMall.Visibility = Visibility.Hidden;
                CrearMall.Visibility = Visibility.Hidden;
                CrearSubterraneo.Visibility = Visibility.Hidden;
                CrearPisoSobreNivel.Visibility = Visibility.Hidden;
                LabelAreaPiso.Visibility = Visibility.Hidden;
                AreaPiso.Visibility = Visibility.Hidden;
                CrearPisoSobreNivel.Visibility = Visibility.Hidden;
                CrearSubterraneo.Visibility = Visibility.Hidden;
                CrearPisoSobre.Visibility = Visibility.Hidden;
                NombreNegocio.Visibility = Visibility.Hidden;
                PrecioMax.Visibility = Visibility.Hidden;
                PrecioMin.Visibility = Visibility.Hidden;
                ValorArriendo.Visibility = Visibility.Hidden;
                Categoria.Visibility = Visibility.Hidden;
                SubCategoria.Visibility = Visibility.Hidden;
                CantidadEmpleados.Visibility = Visibility.Hidden;
                AreaNegocio.Visibility = Visibility.Hidden;
                Stock.Visibility = Visibility.Hidden;
                FinalizarPisos.Visibility = Visibility.Hidden;
                BotonAgregarNegocio.Visibility = Visibility.Hidden;
                
        }

        private void FinalizarNegocios_Click(object sender, RoutedEventArgs e)
        {
            Bienvenido.Visibility = Visibility.Hidden;
            Inicio.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Visible;
            CrearPisoSobreNivel.Visibility = Visibility.Visible;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            NombreNegocio.Visibility = Visibility.Hidden;
            PrecioMax.Visibility = Visibility.Hidden;
            PrecioMin.Visibility = Visibility.Hidden;
            ValorArriendo.Visibility = Visibility.Hidden;
            SubCategoria.Visibility = Visibility.Hidden;
            CantidadEmpleados.Visibility = Visibility.Hidden;
            AreaNegocio.Visibility = Visibility.Hidden;
            Stock.Visibility = Visibility.Hidden;
            Categoria.Visibility = Visibility.Hidden;
            FinalizarPisos.Visibility = Visibility.Visible;
            BotonAgregarNegocio.Visibility = Visibility.Hidden;
            BotonFinalizarNegocios.Visibility = Visibility.Hidden;
        }

        private void BotonAgregarNegocio_Click(object sender, RoutedEventArgs e)
        {
            Piso actual = pisoSobreNivel.Last();
            List<Negocio> negocios = new List<Negocio>();
            string nombre = NombreNegocio.Text;
            int areaNegocio = Convert.ToInt32(AreaNegocio.Text);
            int valArriendo = Convert.ToInt32(ValorArriendo.Text);
            int canEmpl = Convert.ToInt32(CantidadEmpleados.Text);
            string cat = Categoria.Text;
            int stock = Convert.ToInt32(Stock.Text);
            int pMax = Convert.ToInt32(PrecioMax.Text);
            int pMin = Convert.ToInt32(PrecioMin.Text);
            string subCat = SubCategoria.Text;
            Negocio negocioAcutal = new Negocio(nombre,areaNegocio,actual.numeroPiso,valArriendo,pMin,pMax,stock,canEmpl,cat,subCat);
            negocios.Add(negocioAcutal);
            actual.tiendasPorPiso = negocios;
            Bienvenido.Visibility = Visibility.Hidden;
            Inicio.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Hidden;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Hidden;
            CrearPisoSobre.Visibility = Visibility.Hidden;
            NombreNegocio.Visibility = Visibility.Visible;
            PrecioMax.Visibility = Visibility.Visible;
            PrecioMin.Visibility = Visibility.Visible;
            ValorArriendo.Visibility = Visibility.Visible;
            Categoria.Visibility = Visibility.Visible;
            SubCategoria.Visibility = Visibility.Visible;
            CantidadEmpleados.Visibility = Visibility.Visible;
            AreaNegocio.Visibility = Visibility.Visible;
            Stock.Visibility = Visibility.Visible;
            FinalizarPisos.Visibility = Visibility.Hidden;
            BotonAgregarNegocio.Visibility = Visibility.Visible;
            BotonFinalizarNegocios.Visibility = Visibility.Visible;

            NombreNegocio.Text = "Nombre Negocio";
            PrecioMax.Text = "Precio Maximo";
            PrecioMin.Text = "Precio Minimo";
            ValorArriendo.Text = "Valor Arriendo";
            Categoria.Text = "Categoria";
            SubCategoria.Text = "SubCategoria";
            CantidadEmpleados.Text = "Cantida Empleados";
            AreaNegocio.Text = "Area Negocio";
            Stock.Text = "Stock";
        }
    }
}
