using Juegos;
using Juegos.Ajedrez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace AjedrezWPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private Juego juego = new Juego();
        private Button[,] botones = new Button[8, 8];

        public MainWindow() {
            InitializeComponent();
            juego.Inicializar();
            ImageBrush blancoBrush = new ImageBrush(new BitmapImage
                (new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/MBlanco.jpg", UriKind.RelativeOrAbsolute)));
            ImageBrush negroBrush = new ImageBrush(new BitmapImage
                (new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/MNegro.jpg", UriKind.RelativeOrAbsolute)));

            for (int f = 0; f <= 7; f++)
                for (int c = 0; c <= 7; c++) {
                    Button btn = new Button();
                    btn.Background = Tablero.ColorEscaque(7 - f, c) == Juegos.Color.Blanco
                        ? blancoBrush : negroBrush;
                    btn.Tag = "" + (char)('A' + c) + (char)('8' - f);
                    btn.Click += btnPosicion_Click;
                    Grid.SetColumn(btn, c);
                    Grid.SetRow(btn, f);
                    tablero.Children.Add(btn);
                    botones[7 - f, c] = btn;
                }
            juego.Promocion += Juego_Promocion;
            this.Pintar();
        }

        private void btnPosicion_Click(object sender, RoutedEventArgs e) {
            txtJugada.Text += ((Button)sender).Tag;
            if (txtJugada.Text.Length >= 4)
                btnJugar_Click(sender, e);
        }

        private void btnJugar_Click(object sender, RoutedEventArgs e) {
            try {
                juego.Jugada(txtJugada.Text);
                lstJugadas.Items.Add((juego.Turno == Juegos.Color.Blanco ? "N: " : "B: ") + txtJugada.Text);
                lstJugadas.SelectedIndex = lstJugadas.Items.Count - 1;
                this.Pintar();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error en la jugada", MessageBoxButton.OK, MessageBoxImage.Error);
            } finally {
                txtJugada.Text = "";
            }
        }
        private void Pintar() {
            Tablero t = juego.Tablero;
            for (int f = 0; f <= 7; f++)
                for (int c = 0; c <= 7; c++) {
                    Pieza p = t[f + 1, c + 1];
                    if (p == null)
                        botones[f, c].Content = null;
                    else {
                        string nom = p.GetType().Name.ToLower();
                        nom += p.Color == Juegos.Color.Negro ? "n" : "b";
                        botones[f, c].Content = new Image {
                            Source = new BitmapImage(new Uri($@"pack://application:,,,/{Assembly.GetExecutingAssembly().GetName().Name};component/ImgAjedrez/{nom}.gif", UriKind.RelativeOrAbsolute))
                        };
                    }
                }
            if (juego.Turno == Juegos.Color.Blanco) {
                lblPideJugada.Background = Brushes.White;
                lblPideJugada.Foreground = Brushes.Black;
            } else {
                lblPideJugada.Background = Brushes.Black;
                lblPideJugada.Foreground = Brushes.White;
            }
            lblPideJugada.Content = "Juegan la " + (juego.Turno == Juegos.Color.Blanco ? "blancas" : "negras");
        }
        private void Juego_Promocion(object sender, PromocionEventArgs e) {
            var dlg = new PromocionWindow {
                Owner = this
            };
            dlg.ShowDialog();
            switch (dlg.Tag?.ToString()?.ToLower()) {
                case "dama":
                    e.Pieza = new Dama((sender as Peon).Color);
                    break;
                case "alfil":
                    e.Pieza = new Alfil((sender as Peon).Color);
                    break;
                case "torre":
                    e.Pieza = new Torre((sender as Peon).Color);
                    break;
                case "caballo":
                    e.Pieza = new Caballo((sender as Peon).Color);
                    break;
                default:
                    throw new JuegoException("ERROR: El nombre de la pieza debe ser: Dama, Alfil, Torre o Caballo");
            }
            txtJugada.Text += " ↑ " + dlg.Tag?.ToString();
        }

    }
}
