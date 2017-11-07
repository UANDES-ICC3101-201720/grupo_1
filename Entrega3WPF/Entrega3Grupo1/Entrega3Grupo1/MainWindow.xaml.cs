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
            Cancelar.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            NumeroLocales.Visibility = Visibility.Hidden;
            LabelNumeroLocales.Visibility = Visibility.Hidden;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            CrearPisoSobre.Visibility = Visibility.Hidden;
            CrearPisoSub.Visibility = Visibility.Hidden;
            NumeroEstacionamientos.Visibility = Visibility.Hidden;
            LabelNumeroEsatcionamientos.Visibility = Visibility.Hidden;

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
            Cancelar.Visibility = Visibility.Visible;


        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {

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
            Cancelar.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Visible;
            CrearPisoSobreNivel.Visibility = Visibility.Visible;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            LabelNumeroLocales.Visibility = Visibility.Hidden;
            NumeroLocales.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            string nombre = TxtBoxNombreMall.Text;
            int horas = Convert.ToInt32(TxtBoxHorasMall.Text);
            new Mall(nombre, horas);
            CrearPisoSobreNivel.Visibility = Visibility.Visible;
            CrearSubterraneo.Visibility = Visibility.Visible;
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
            Cancelar.Visibility = Visibility.Visible;
            CrearSubterraneo.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Hidden;
            LabelAreaPiso.Visibility = Visibility.Visible;
            LabelNumeroLocales.Visibility = Visibility.Visible;
            NumeroLocales.Visibility = Visibility.Visible;
            AreaPiso.Visibility = Visibility.Visible;
            CrearPisoSobre.Visibility = Visibility.Visible;
            
        }

            
        private void CrearPisoSobre_Click(object sender, RoutedEventArgs e)
        {
            Piso piso = new Piso(contadorPisosSobre, Convert.ToInt32(AreaPiso.Text), Convert.ToInt32(NumeroLocales.Text));
            pisoSobreNivel.Add(piso);
            Bienvenido.Visibility = Visibility.Hidden;
            Inicio.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            Cancelar.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Visible;
            CrearPisoSobreNivel.Visibility = Visibility.Visible;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            LabelNumeroLocales.Visibility = Visibility.Hidden;
            NumeroLocales.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Visible;
            CrearSubterraneo.Visibility = Visibility.Visible;
            CrearPisoSobre.Visibility = Visibility.Hidden;
            AreaPiso.Clear();
            NumeroLocales.Clear();
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
            Cancelar.Visibility = Visibility.Visible;
            CrearSubterraneo.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Hidden;
            LabelAreaPiso.Visibility = Visibility.Visible;
            LabelNumeroLocales.Visibility = Visibility.Hidden;
            NumeroLocales.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Visible;
            CrearPisoSobre.Visibility = Visibility.Hidden;
            CrearPisoSub.Visibility = Visibility.Visible;
            NumeroEstacionamientos.Visibility = Visibility.Visible;
            LabelNumeroEsatcionamientos.Visibility = Visibility.Visible;

        }

        private void CrearPisoSub_Click(object sender, RoutedEventArgs e)
        {
            Piso piso = new Piso(contadorPisosSub, Convert.ToInt32(AreaPiso.Text), Convert.ToInt32(NumeroEstacionamientos.Text));
            pisoSubt.Add(piso);
            pisoSobreNivel.Add(piso);
            Bienvenido.Visibility = Visibility.Hidden;
            Inicio.Visibility = Visibility.Hidden;
            TxtBoxHorasMall.Visibility = Visibility.Hidden;
            TxtBoxNombreMall.Visibility = Visibility.Hidden;
            LabelHoraMall.Visibility = Visibility.Hidden;
            LabelNombreMall.Visibility = Visibility.Hidden;
            CrearMall.Visibility = Visibility.Hidden;
            Cancelar.Visibility = Visibility.Hidden;
            CrearSubterraneo.Visibility = Visibility.Visible;
            CrearPisoSobreNivel.Visibility = Visibility.Visible;
            LabelAreaPiso.Visibility = Visibility.Hidden;
            LabelNumeroLocales.Visibility = Visibility.Hidden;
            NumeroLocales.Visibility = Visibility.Hidden;
            AreaPiso.Visibility = Visibility.Hidden;
            CrearPisoSobreNivel.Visibility = Visibility.Visible;
            CrearSubterraneo.Visibility = Visibility.Visible;
            CrearPisoSobre.Visibility = Visibility.Hidden;
            NumeroEstacionamientos.Visibility = Visibility.Hidden;
            LabelNumeroEsatcionamientos.Visibility = Visibility.Hidden;
            NumeroEstacionamientos.Clear();
            AreaPiso.Clear();
            NumeroLocales.Clear();
            contadorPisosSub -= 1;
        }
    }
}
