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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Entrega3Grupo1
{
    [Serializable]
    public partial class MainWindow : Window
    {

        //Fondo de pantalla
        private void SetImagen()
        {
            Image image = new Image();
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new System.Uri("pack://application:,,,/FondoPantalla/FondoPantallaWPF.jpg");
            bi.EndInit();
            image.Source = bi;

            ImageBrush ib = new ImageBrush();
            ib.ImageSource = bi;

            Fondopantalla.Fill = ib;
        }
        public static void CalcularClientes(Negocio n)
        {
            Random rn = new Random();
            int promedioPrecios = (n.precioMin + n.precioMax) / 2;
            int cMAX = Convert.ToInt32(n.clientesDiaAnterior + (n.areaNegocio / 10.0) * (((Math.Max((100 - promedioPrecios), 0)) / 100.0) * n.numEmpleados));
            n.clientesDelDia = rn.Next(0, cMAX);
            n.clientesDiaAnterior = n.clientesDelDia;
        }
        public static void CalcularGanancia(Negocio n)
        {
            Random rn = new Random();
            int ventaPromedio = rn.Next(n.precioMin, n.precioMax);
            int costoArriendo = n.precioArriendo * n.areaNegocio;
            double ganancia = (ventaPromedio * n.clientesDelDia) - (n.numEmpleados + costoArriendo);
            n.ganancias = ganancia;
        }
        Mall a = new Mall("",0,0);
        List<Negocio> todosLosNegocios = new List<Negocio>();
        List<Piso> pisoSobreNivel = new List<Piso>();
        List<Piso> pisoSubt = new List<Piso>();
        int contadorPisosSobre = 1;
        int contadorPisosSub = -1;
        int sueldoPromedio;
        public MainWindow()
        {
            InitializeComponent();
            SetImagen();
            string path = Directory.GetCurrentDirectory();
            string[] filePaths = Directory.GetFiles(path, "*.txt");
            foreach (string file in filePaths)
            {
                string nombre = System.IO.Path.GetFileName(file);
                if (nombre == "Reporte.txt") { }
                else { CargarArchivos.Items.Add(nombre); }
                
            }

            LabelAreaCompleta.Visibility = Visibility.Hidden;
            LabelSeleccioneArchivo.Visibility = Visibility.Visible;
            BotonVolver.Visibility = Visibility.Hidden;
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
            TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
            LabelPisoFinalizado.Visibility = Visibility.Hidden;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
            ButtonSimular.Visibility = Visibility.Hidden;
            GuardarSimulacion.Visibility = Visibility.Hidden;
            LabelSimulacionGuardada.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Hidden;
            LabelSueldoProm.Visibility = Visibility.Hidden;
            LabelCantidadNegocios.Visibility = Visibility.Hidden;
            Reporte.Visibility = Visibility.Hidden;
            TodosLosLocales.Visibility = Visibility.Hidden;
            InformacionPorLocal.Visibility = Visibility.Hidden;
            InformeLocal.Visibility = Visibility.Hidden;
            button.Visibility = Visibility.Hidden;
            NombreArchivo.Visibility = Visibility.Hidden;
           
            
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
            TextBoxSueldoPromedio.Visibility = Visibility.Visible;
            LabelPisoFinalizado.Visibility = Visibility.Hidden;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
            ButtonSimular.Visibility = Visibility.Hidden;
            GuardarSimulacion.Visibility = Visibility.Hidden;
            LabelSimulacionGuardada.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Hidden;
            LabelSueldoProm.Visibility = Visibility.Visible;
            ButonCargar.Visibility = Visibility.Hidden;
            CargarArchivos.Visibility = Visibility.Hidden;
            LabelSeleccioneArchivo.Visibility = Visibility.Hidden;

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
            LabelAreaPiso.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            string nombre = TxtBoxNombreMall.Text;
            int horas = Convert.ToInt32(TxtBoxHorasMall.Text);
            sueldoPromedio = Convert.ToInt32(TextBoxSueldoPromedio.Text);
            a = new Mall(nombre, horas, sueldoPromedio);
            CrearPisoSobreNivel.Visibility = Visibility.Visible;
            FinalizarPisos.Visibility = Visibility.Visible;
            LabelPisoFinalizado.Visibility = Visibility.Hidden;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
            TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
            ButtonSimular.Visibility = Visibility.Hidden;
            GuardarSimulacion.Visibility = Visibility.Hidden;
            LabelSimulacionGuardada.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Hidden;
            LabelSueldoProm.Visibility = Visibility.Hidden;
        }

        private void CrearPisoSobreNivel_Click(object sender, RoutedEventArgs e)
        {
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Visible;
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
            TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
            LabelPisoFinalizado.Visibility = Visibility.Hidden;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Visible;
            ButtonSimular.Visibility = Visibility.Hidden;
            GuardarSimulacion.Visibility = Visibility.Hidden;
            LabelSimulacionGuardada.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Hidden;
            LabelCantidadNegocios.Visibility = Visibility.Visible;

        }


        private void CrearPisoSobre_Click(object sender, RoutedEventArgs e)
        {
            List<Negocio> negocio = new List<Negocio>();
            int tiendasdisponibles = Convert.ToInt32(TextBoxCantidadDeTiendasPorPiso.Text);
            Piso piso = new Piso(contadorPisosSobre, Convert.ToInt32(AreaPiso.Text), negocio, tiendasdisponibles, 1);
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
            TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
            LabelPisoFinalizado.Visibility = Visibility.Hidden;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Visible;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
            AreaPiso.Clear();
            TextBoxCantidadDeTiendasPorPiso.Clear();
            contadorPisosSobre += 1;
            ButtonSimular.Visibility = Visibility.Hidden;
            GuardarSimulacion.Visibility = Visibility.Hidden;
            LabelSimulacionGuardada.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Hidden;
            LabelCantidadNegocios.Visibility = Visibility.Hidden;
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
            TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
            LabelPisoFinalizado.Visibility = Visibility.Hidden;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
            ButtonSimular.Visibility = Visibility.Hidden;
            GuardarSimulacion.Visibility = Visibility.Hidden;
            LabelSimulacionGuardada.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Hidden;

        }

        private void CrearPisoSub_Click(object sender, RoutedEventArgs e)
        {
            List<Negocio> nada = new List<Negocio>();
            Piso piso = new Piso(contadorPisosSub, Convert.ToInt32(AreaPiso.Text), nada, 0, 0);
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
            CrearPisoSobre.Visibility = Visibility.Hidden;
            CrearPisoSub.Visibility = Visibility.Hidden;
            FinalizarPisos.Visibility = Visibility.Visible;
            TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
            LabelPisoFinalizado.Visibility = Visibility.Hidden;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
            AreaPiso.Clear();
            contadorPisosSub -= 1;
            ButtonSimular.Visibility = Visibility.Hidden;
            GuardarSimulacion.Visibility = Visibility.Hidden;
            LabelSimulacionGuardada.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Hidden;
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
            TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
            LabelPisoFinalizado.Visibility = Visibility.Hidden;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
            ButtonSimular.Visibility = Visibility.Visible;
            GuardarSimulacion.Visibility = Visibility.Hidden;
            LabelSimulacionGuardada.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Hidden;
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
            TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
            LabelPisoFinalizado.Visibility = Visibility.Hidden;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
            BotonAgregarNegocio.Visibility = Visibility.Hidden;
            BotonFinalizarNegocios.Visibility = Visibility.Hidden;
            GuardarSimulacion.Visibility = Visibility.Hidden;
            LabelSimulacionGuardada.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Hidden;
            
        }

        private void BotonAgregarNegocio_Click(object sender, RoutedEventArgs e)
        {
            Piso actual = pisoSobreNivel.Last();
            int clientesDeDia = 0;
            int clientesDelDiaAnterior = 0;
            int tiendasUsadas = actual.tiendasUsadas;
            int tiendasdisponibles = actual.cantidadTiendas;
            if (tiendasdisponibles == actual.tiendasUsadas)
            {
                LabelPisoFinalizado.Visibility = Visibility.Hidden;
                NombreNegocio.Visibility = Visibility.Hidden;
                PrecioMax.Visibility = Visibility.Hidden;
                PrecioMin.Visibility = Visibility.Hidden;
                ValorArriendo.Visibility = Visibility.Hidden;
                Categoria.Visibility = Visibility.Hidden;
                SubCategoria.Visibility = Visibility.Hidden;
                CantidadEmpleados.Visibility = Visibility.Hidden;
                AreaNegocio.Visibility = Visibility.Hidden;
                Stock.Visibility = Visibility.Hidden;
                CrearPisoSobreNivel.Visibility = Visibility.Visible;
                FinalizarPisos.Visibility = Visibility.Visible;
                TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
                TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
                Bienvenido.Visibility = Visibility.Hidden;
                Inicio.Visibility = Visibility.Hidden;
                TxtBoxHorasMall.Visibility = Visibility.Hidden;
                TxtBoxNombreMall.Visibility = Visibility.Hidden;
                LabelHoraMall.Visibility = Visibility.Hidden;
                LabelNombreMall.Visibility = Visibility.Hidden;
                CrearMall.Visibility = Visibility.Hidden;
                CrearSubterraneo.Visibility = Visibility.Visible;
                LabelAreaPiso.Visibility = Visibility.Hidden;
                AreaPiso.Visibility = Visibility.Hidden;
                BotonAgregarNegocio.Visibility = Visibility.Hidden;
                BotonFinalizarNegocios.Visibility = Visibility.Hidden;
                GuardarSimulacion.Visibility = Visibility.Hidden;
                LabelSimulacionGuardada.Visibility = Visibility.Hidden;
                MostrarReporte.Visibility = Visibility.Hidden;                
            }
            

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
            List<double> gananciastotales = new List<double>();
            Negocio negocioAcutal = new Negocio(nombre, areaNegocio, actual.numeroPiso, valArriendo, pMin, pMax, stock, canEmpl, cat, subCat, clientesDelDiaAnterior , clientesDeDia, gananciastotales);
            todosLosNegocios.Add(negocioAcutal);
            negocios.Add(negocioAcutal);
            actual.tiendasPorPiso = negocios;
            Bienvenido.Visibility = Visibility.Hidden;
            Inicio.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            CrearPisoSobre.Visibility = Visibility.Hidden;
            TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
            NombreNegocio.Text = "Nombre Negocio";
            PrecioMax.Text = "Precio Maximo";
            PrecioMin.Text = "Precio Minimo";
            ValorArriendo.Text = "Valor Arriendo";
            Categoria.Text = "Categoria";
            SubCategoria.Text = "SubCategoria";
            CantidadEmpleados.Text = "Cantida Empleados";
            AreaNegocio.Text = "Area Negocio";
            Stock.Text = "Stock";
            actual.tiendasUsadas = actual.tiendasUsadas + 1;
            actual.areaUsada = actual.areaUsada + areaNegocio;
            GuardarSimulacion.Visibility = Visibility.Hidden;
            LabelSimulacionGuardada.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Hidden;
            if (actual.areaPiso <= actual.areaUsada)
            {
                todosLosNegocios.Remove(negocioAcutal);
                negocios.Remove(negocioAcutal);
                todosLosNegocios.Add(new Negocio(nombre, actual.areaUsada - actual.areaPiso, actual.numeroPiso, valArriendo, pMin, pMax, stock, canEmpl, cat, subCat, clientesDelDiaAnterior, clientesDeDia, gananciastotales));
                LabelPisoFinalizado.Visibility = Visibility.Hidden;
                NombreNegocio.Visibility = Visibility.Hidden;
                PrecioMax.Visibility = Visibility.Hidden;
                PrecioMin.Visibility = Visibility.Hidden;
                ValorArriendo.Visibility = Visibility.Hidden;
                Categoria.Visibility = Visibility.Hidden;
                SubCategoria.Visibility = Visibility.Hidden;
                CantidadEmpleados.Visibility = Visibility.Hidden;
                AreaNegocio.Visibility = Visibility.Hidden;
                Stock.Visibility = Visibility.Hidden;
                CrearPisoSobreNivel.Visibility = Visibility.Visible;
                FinalizarPisos.Visibility = Visibility.Visible;
                TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
                TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
                Bienvenido.Visibility = Visibility.Hidden;
                Inicio.Visibility = Visibility.Hidden;
                TxtBoxHorasMall.Visibility = Visibility.Hidden;
                TxtBoxNombreMall.Visibility = Visibility.Hidden;
                LabelHoraMall.Visibility = Visibility.Hidden;
                LabelNombreMall.Visibility = Visibility.Hidden;
                CrearMall.Visibility = Visibility.Hidden;
                CrearSubterraneo.Visibility = Visibility.Visible;
                LabelAreaPiso.Visibility = Visibility.Hidden;
                AreaPiso.Visibility = Visibility.Hidden;
                BotonAgregarNegocio.Visibility = Visibility.Hidden;
                BotonFinalizarNegocios.Visibility = Visibility.Hidden;
                GuardarSimulacion.Visibility = Visibility.Hidden;
                LabelSimulacionGuardada.Visibility = Visibility.Hidden;
                MostrarReporte.Visibility = Visibility.Hidden;
            }




        }


        private void ButtonSimular_Click(object sender, RoutedEventArgs e)
        {
            List<string> reporteCompleto = new List<string>();
            FileStream fs = new FileStream("Reporte.txt", FileMode.OpenOrCreate);
            StreamWriter fw = new StreamWriter(fs);
            Inicio.Visibility = Visibility.Hidden;
            Bienvenido.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Hidden;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            CrearPisoSobre.Visibility = Visibility.Hidden;
            CrearPisoSub.Visibility = Visibility.Hidden;
            FinalizarPisos.Visibility = Visibility.Hidden;
            NombreNegocio.Visibility = Visibility.Hidden;
            AreaNegocio.Visibility = Visibility.Hidden;
            CantidadEmpleados.Visibility = Visibility.Hidden;
            Categoria.Visibility = Visibility.Hidden;
            PrecioMax.Visibility = Visibility.Hidden;
            PrecioMin.Visibility = Visibility.Hidden;
            ValorArriendo.Visibility = Visibility.Hidden;
            Stock.Visibility = Visibility.Hidden;
            SubCategoria.Visibility = Visibility.Hidden;
            BotonAgregarNegocio.Visibility = Visibility.Hidden;
            BotonFinalizarNegocios.Visibility = Visibility.Hidden;
            TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
            LabelPisoFinalizado.Visibility = Visibility.Hidden;
            ButtonSimular.Visibility = Visibility.Hidden;
            GuardarSimulacion.Visibility = Visibility.Visible;
            LabelSimulacionGuardada.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Visible;
            InformacionPorLocal.Visibility = Visibility.Visible;
            NombreArchivo.Visibility = Visibility.Visible;
            InformeLocal.Visibility = Visibility.Hidden;
            
           
            int dia = 1;
            int clientesTotales = 0;
            int gananciaTotal = 0;
            while (dia <= 10)
            {
                
                fw.WriteLine("Simulacion del dia: " + dia);
                //Cantidad de clientes recepcionados y ganancias, promedio y del dia

                int clientesdeldia = 0;
                double gananciadeldia = 0;

                foreach (Negocio n in todosLosNegocios)
                {
                    CalcularClientes(n);
                    CalcularGanancia(n);                    
                    n.gananciatotal = n.gananciatotal + n.ganancias; //Ganancias seria las ganancias de cada dia del negocio
                    n.clientesTotales = n.clientesTotales + n.clientesDelDia;
                    clientesdeldia = clientesdeldia + n.clientesDelDia;
                    gananciadeldia = gananciadeldia + n.ganancias;
                    n.listaGanancias.Add(n.ganancias);
                    

                }

                double gananciamaxima = -9999999999999999;
                double gananciaminima = 9999999999999;
                int clientesmaximos = 0;
                int clientesminimos = 999999999;
                string nombredelatiendacmax = "";
                string nombredelatiendacmin = "";
                string nombredelatiendagmax = "";
                string nombredelatiendagmin = "";

                //Locales con mayor y menor cantidad de clientes atendidos
                foreach (Negocio n in todosLosNegocios)
                {
                    if (n.clientesDelDia > clientesmaximos)
                    {
                        clientesmaximos = n.clientesDelDia;
                        nombredelatiendacmax = n.nombreNegocio;
                    }
                    if (n.clientesDelDia < clientesminimos)
                    {
                        clientesminimos = n.clientesDelDia;
                        nombredelatiendacmin = n.nombreNegocio;
                    }
                    if (n.ganancias > gananciamaxima)
                    {
                        gananciamaxima = n.ganancias;
                        nombredelatiendagmax = n.nombreNegocio;
                    }
                    if (n.ganancias < gananciaminima)
                    {
                        gananciaminima = n.ganancias;
                        nombredelatiendagmin = n.nombreNegocio;
                    }
                }

                clientesTotales = clientesTotales + clientesdeldia;
                gananciaTotal = Convert.ToInt32(gananciaTotal + gananciadeldia);

                string TextoReporte = "Simulacion del dia: " + dia
                    + "\nLa cantidad de clientes del dia " + dia + " fue de " + clientesdeldia 
                    + "\nLa cantidad de clientes promedio hasta el dia " + dia + " es de" + (clientesTotales / dia)
                    + "\nLa ganancia del dia " + dia + " fue de " + gananciadeldia
                    + "\nLa ganancia promedio hasta el dia " + dia + " es de " + (gananciaTotal / dia)
                    + "\nLa tienda con mas clientes en el dia " + dia + " fue " + nombredelatiendacmax
                    + "\nLa tienda con menos clientes en el dia " + dia + " fue " + nombredelatiendacmin
                    + "\nLa tienda con mas ganancias en el dia " + dia + " fue " + nombredelatiendagmax + " con una ganancia de " + gananciamaxima
                    + "\nLa tienda con menos ganancias en el dia " + dia + " fue " + nombredelatiendagmax + "con una ganancia de " + gananciaminima + "\n\n";

                fw.WriteLine("La cantidad de clientes del dia " + dia + " fue de " + clientesdeldia);
                fw.WriteLine("La cantidad de clientes promedio hasta el dia " + dia + " es de" + (clientesTotales / dia));

                fw.WriteLine("La ganancia del dia" + dia + " fue de " + gananciadeldia);
                fw.WriteLine("La ganancia promedio hasta el dia " + dia + " es de " + (gananciaTotal / dia));

                fw.WriteLine("La tienda con mas clientes en el dia " + dia + " fue " + nombredelatiendacmax);
                fw.WriteLine("La tienda con menos clientes en el dia " + dia + " fue " + nombredelatiendacmin);

                fw.WriteLine("La tienda con mas ganancias en el dia " + dia + " fue " + nombredelatiendagmax + " con una ganancia de " + gananciamaxima);
                fw.WriteLine("La tienda con menos ganancias en el dia " + dia + " fue " + nombredelatiendagmax + "con una ganancia de " + gananciaminima);

                reporteCompleto.Add(TextoReporte);
                dia = dia + 1;

            }

            Reporte.Text = String.Join("",reporteCompleto);
        }

        private void MostrarReporte_Click(object sender, RoutedEventArgs e)
        {

            Inicio.Visibility = Visibility.Hidden;
            Bienvenido.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Hidden;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            CrearPisoSobre.Visibility = Visibility.Hidden;
            CrearPisoSub.Visibility = Visibility.Hidden;
            FinalizarPisos.Visibility = Visibility.Hidden;
            NombreNegocio.Visibility = Visibility.Hidden;
            AreaNegocio.Visibility = Visibility.Hidden;
            CantidadEmpleados.Visibility = Visibility.Hidden;
            Categoria.Visibility = Visibility.Hidden;
            PrecioMax.Visibility = Visibility.Hidden;
            PrecioMin.Visibility = Visibility.Hidden;
            ValorArriendo.Visibility = Visibility.Hidden;
            Stock.Visibility = Visibility.Hidden;
            SubCategoria.Visibility = Visibility.Hidden;
            BotonAgregarNegocio.Visibility = Visibility.Hidden;
            BotonFinalizarNegocios.Visibility = Visibility.Hidden;
            TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
            LabelPisoFinalizado.Visibility = Visibility.Hidden;
            ButtonSimular.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Hidden;
            GuardarSimulacion.Visibility = Visibility.Hidden;
            LabelSimulacionGuardada.Visibility = Visibility.Hidden;
            Reporte.Visibility = Visibility.Visible;
            BotonVolver.Visibility = Visibility.Visible;
            InformacionPorLocal.Visibility = Visibility.Hidden;
            NombreArchivo.Visibility = Visibility.Hidden;
        }

        private void GuardarSimulacion_Click(object sender, RoutedEventArgs e)
        {
            Inicio.Visibility = Visibility.Hidden;
            Bienvenido.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Hidden;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            CrearPisoSobre.Visibility = Visibility.Hidden;
            CrearPisoSub.Visibility = Visibility.Hidden;
            FinalizarPisos.Visibility = Visibility.Hidden;
            NombreNegocio.Visibility = Visibility.Hidden;
            AreaNegocio.Visibility = Visibility.Hidden;
            CantidadEmpleados.Visibility = Visibility.Hidden;
            Categoria.Visibility = Visibility.Hidden;
            PrecioMax.Visibility = Visibility.Hidden;
            PrecioMin.Visibility = Visibility.Hidden;
            ValorArriendo.Visibility = Visibility.Hidden;
            Stock.Visibility = Visibility.Hidden;
            SubCategoria.Visibility = Visibility.Hidden;
            BotonAgregarNegocio.Visibility = Visibility.Hidden;
            BotonFinalizarNegocios.Visibility = Visibility.Hidden;
            TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
            LabelPisoFinalizado.Visibility = Visibility.Hidden;
            ButtonSimular.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Visible;
            GuardarSimulacion.Visibility = Visibility.Visible;
            LabelSimulacionGuardada.Visibility = Visibility.Visible;
            NombreArchivo.Visibility = Visibility.Visible;
            GuardarSimulacionCompleta guardar = new GuardarSimulacionCompleta(a,todosLosNegocios, pisoSobreNivel,pisoSubt,contadorPisosSobre,contadorPisosSub);
            string nombre = NombreArchivo.Text + ".txt";
            FileStream fs =File.Open(nombre, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, guardar);

        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void InformacionPorLocal_Click(object sender, RoutedEventArgs e)
        {
            foreach (Negocio n in todosLosNegocios)
            {
                TodosLosLocales.Items.Add(n.nombreNegocio);
            }
            TodosLosLocales.Visibility = Visibility.Visible;
            InformacionPorLocal.Visibility = Visibility.Hidden;
            GuardarSimulacion.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Hidden;
            InformeLocal.Visibility = Visibility.Hidden;
            button.Visibility = Visibility.Visible;
            BotonVolver.Visibility = Visibility.Visible;
            NombreArchivo.Visibility = Visibility.Hidden;
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
            string nombre = Convert.ToString(TodosLosLocales.SelectedItem);
            Negocio neg = todosLosNegocios.Find(x => x.nombreNegocio.Contains(nombre));
            nombre = neg.nombreNegocio;
            int cantEmp = neg.numEmpleados;
            string cat = neg.cat;
            int piso = neg.piso;
            int area = neg.areaNegocio;
            int pMin = neg.precioMin;
            int pMax = neg.precioMax;
            int cArriendo = neg.precioArriendo;
            int sueldoEmpleados = neg.numEmpleados * sueldoPromedio;
            int vent = neg.numeroClientes;
            double ganancia = neg.ganancias;
            double gananciat = neg.gananciatotal;
            InformeLocal.Text = "Local: " + nombre
                + "\nCantidad de empleados: " + cantEmp
                + "\nLa categoria: " + cat
                + "\nEl piso en el que se encuentra: " + piso
                + "\nÁrea de local: " + area
                + "\nPrecio manimo: " + pMin
                + "\nPrecio maximo: " + pMax
                + "\nEl costo en arriendo del local: " + cArriendo
                + "\nCosto en sueldos de empleados: " + sueldoEmpleados
                + "\nLas ventas del local este día: " + vent
                + "\nLa ganancia del local del día 1:" + neg.listaGanancias[0]
                + "\nLa ganancia del local del día 2:" + neg.listaGanancias[1]
                + "\nLa ganancia del local del día 3:" + neg.listaGanancias[2]
                + "\nLa ganancia del local del día 4:" + neg.listaGanancias[3]
                + "\nLa ganancia del local del día 5:" + neg.listaGanancias[4]
                + "\nLa ganancia del local del día 6:" + neg.listaGanancias[5]
                + "\nLa ganancia del local del día 7:" + neg.listaGanancias[6]
                + "\nLa ganancia del local del día 8:" + neg.listaGanancias[7]
                + "\nLa ganancia del local del día 9:" + neg.listaGanancias[8]
                + "\nLa ganancia del local del día 10:" + neg.listaGanancias[9]


            + "\nLa ganancia acumulada del local en toda la simulación: " + gananciat;
            TodosLosLocales.Visibility = Visibility.Hidden;
            InformacionPorLocal.Visibility = Visibility.Hidden;
            GuardarSimulacion.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Hidden;
            InformeLocal.Visibility = Visibility.Visible;
            button.Visibility = Visibility.Hidden;
            BotonVolver.Visibility = Visibility.Visible;
        }

        private void Volver(object sender, RoutedEventArgs e)
        {
            Inicio.Visibility = Visibility.Hidden;
            Bienvenido.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Hidden;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            CrearPisoSobre.Visibility = Visibility.Hidden;
            CrearPisoSub.Visibility = Visibility.Hidden;
            FinalizarPisos.Visibility = Visibility.Hidden;
            NombreNegocio.Visibility = Visibility.Hidden;
            AreaNegocio.Visibility = Visibility.Hidden;
            CantidadEmpleados.Visibility = Visibility.Hidden;
            Categoria.Visibility = Visibility.Hidden;
            PrecioMax.Visibility = Visibility.Hidden;
            PrecioMin.Visibility = Visibility.Hidden;
            ValorArriendo.Visibility = Visibility.Hidden;
            Stock.Visibility = Visibility.Hidden;
            SubCategoria.Visibility = Visibility.Hidden;
            BotonAgregarNegocio.Visibility = Visibility.Hidden;
            BotonFinalizarNegocios.Visibility = Visibility.Hidden;
            TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
            LabelPisoFinalizado.Visibility = Visibility.Hidden;
            ButtonSimular.Visibility = Visibility.Hidden;
            GuardarSimulacion.Visibility = Visibility.Visible;
            LabelSimulacionGuardada.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Visible;
            InformacionPorLocal.Visibility = Visibility.Visible;
            InformeLocal.Visibility = Visibility.Hidden;
            Reporte.Visibility = Visibility.Hidden;
        }

        private void Cargar(object sender, RoutedEventArgs e)
        {
            GuardarSimulacionCompleta g;
            string nombre = Convert.ToString(CargarArchivos.SelectedItem);
            FileStream fs = new FileStream(nombre,FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            g = (GuardarSimulacionCompleta) bf.Deserialize(fs);
            a = g.a;
            todosLosNegocios = g.todosLosNegocios;
            pisoSobreNivel = g.pisoSobreNivel;
            pisoSubt = g.pisoSubt;
            contadorPisosSobre = g.contadorPisosSobre;
            contadorPisosSub = g.contadorPisosSub;
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
            TextBoxSueldoPromedio.Visibility = Visibility.Hidden;
            LabelPisoFinalizado.Visibility = Visibility.Hidden;
            TextBoxCantidadDeTiendasPorPiso.Visibility = Visibility.Hidden;
            ButtonSimular.Visibility = Visibility.Visible;
            GuardarSimulacion.Visibility = Visibility.Hidden;
            LabelSimulacionGuardada.Visibility = Visibility.Hidden;
            MostrarReporte.Visibility = Visibility.Hidden;
            NombreArchivo.Visibility = Visibility.Hidden;
            ButonCargar.Visibility = Visibility.Hidden;
            CargarArchivos.Visibility = Visibility.Hidden;
            
        }

      

        

        

        private void ListBoxNegocios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}