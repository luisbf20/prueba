using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlotaLuisBuenoFernandez
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] tablero = new int[4, 4]
            {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {0,0,0,1}
            };

        LogicaNegocio logica = new LogicaNegocio();

        int aciertos = 0;
        public MainWindow()
        {
            InitializeComponent();
            tablaJugadas.ItemsSource = logica.Jugadas;
            
        }

        private void cambiarImagenBoton(Button btn, int x, int y)
        {
            if (tablero[x,y] == 1)
            {
                btn.Content = new Image
                {
                    Source = new BitmapImage(new Uri("imagenes/barco.png", UriKind.Relative)),
                    Stretch = System.Windows.Media.Stretch.Fill
                };
                aciertos++;
                if(aciertos == 4)
                {
                    MessageBox.Show("Has encontrado todos los barcos");
                    DeshabilitarTablero();
                }
            }
            else
            {
                btn.Content = new Image
                {
                    Source = new BitmapImage(new Uri("imagenes/agua_vacio.png", UriKind.Relative)),
                    Stretch = System.Windows.Media.Stretch.Fill
                };
            }
            btn.IsEnabled = false;
        }

        private void Boton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            string[] posiciones = btn.Tag.ToString().Split(',');
            int x = int.Parse(posiciones[0]);
            int y = int.Parse(posiciones[1]);
            cambiarImagenBoton(btn, x, y);
            logica.añadirJugada(new Jugada(x, y));

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            logica.Reset();

            // Resetear botones
            foreach (var control in TableroGrid.Children)
            {
                if (control is Button btn && btn != btnReiniciar)
                {
                    btn.Content = new Image
                    {
                        Source = new BitmapImage(new Uri("imagenes/agua.png", UriKind.Relative)),
                        Stretch = System.Windows.Media.Stretch.Fill
                    };
                    btn.IsEnabled = true;
                }
            }

            aciertos = 0;
        }

        private void DeshabilitarTablero()
        {
            foreach (UIElement element in TableroGrid.Children)
            {
                if (element is Button btn && btn.Name != "btnReiniciar")
                {
                    btn.IsEnabled = false;
                }
            }
        }

    }

}