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
using System.Windows.Shapes;


namespace TheCSharpFantasy
{
    /// <summary>
    /// Lógica de interacción para FightWindow.xaml
    /// </summary>
    /// 
    public partial class FightWindow : Window
    {
        Personaje jugador;
        Personaje enemigo;

        bool turno_Jugador = true;
        public FightWindow(Personaje datosJugador, Personaje datosEnemigo)
        {
            InitializeComponent();
            Agregar_Datos_Jugador(datosJugador);
            this.jugador = datosJugador; 
            Agregar_Datos_Enemigo(datosEnemigo);
            this.enemigo = datosEnemigo;

            monitorPelea.Text += "Es el turno de: " + jugador.Nombre;

        }

        private void Agregar_Datos_Jugador(Personaje jugador)
        { 

            BitmapImage miImagen = new BitmapImage();
            miImagen.BeginInit();
            miImagen.UriSource = new Uri(jugador.Imagen, UriKind.Relative);
            miImagen.EndInit();

            imagen_jugador.Source = miImagen;
            vida_jugador.Content += jugador.Vida.ToString();
            energia_jugador.Content += jugador.Energia.ToString();
            mana_jugador.Content += jugador.Mana.ToString();
            estado_jugador.Content += jugador.Estado.ToString();
            nombre_jugador.Content += jugador.Nombre.ToString();

        }

        private void Agregar_Datos_Enemigo(Personaje enemigo)
        {

            BitmapImage miImagen = new BitmapImage();
            miImagen.BeginInit();
            miImagen.UriSource = new Uri(enemigo.Imagen, UriKind.Relative);
            miImagen.EndInit();

            imagen_enemigo.Source = miImagen;
            vida_enemigo.Content += enemigo.Vida.ToString();
            energia_enemigo.Content += enemigo.Energia.ToString();
            mana_enemigo.Content += enemigo.Mana.ToString();
            estado_enemigo.Content += enemigo.Estado.ToString();
            nombre_enemigo.Content += enemigo.Nombre.ToString();

        }

        private void Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Abrir_Ventana(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;

            switch (boton.Content.ToString())
            {
                case "Inventario":
                    InventarioWindow ventanaInventario = new InventarioWindow();
                    ventanaInventario.Show();
                    break;

                case "Mi Personaje":
                    MonitorPersonajeWindow ventanaMonitorPersonaje = new MonitorPersonajeWindow();
                    ventanaMonitorPersonaje.Show();
                    break;

                case "Menu":
                    MenuWindow ventanaMenu = new MenuWindow();
                    ventanaMenu.Show();
                    break;

                default:
                    break;
            }
        }

        private void turnoJugador(object sender, RoutedEventArgs e)
        {

            if (turno_Jugador)
            {
                Button boton = (Button)sender;

                switch (boton.Name.ToString())
                {
                    case "ataque1":

                        enemigo.Vida -= jugador.Daño_fisico;
                        vida_enemigo.Content = "Puntos de vida: " + enemigo.Vida.ToString();
                        monitorPelea.Text += "\n" + enemigo.Nombre + " Ha perdido " + jugador.Daño_fisico + " puntos de vida.";
                        break;

                    case "ataque2":

                        enemigo.Estado = "Paralizado";
                        monitorPelea.Text += "\n" + enemigo.Nombre + " Ha sido paralizado. ";
                        break;

                    case "huir":

                        Close();
                        break;

                    case "pasar":
                        break;                    
                }
            }

            turno_Jugador = false;
            turnoEnemigo();


        }

        private void turnoEnemigo()
        {

            if (enemigo.Vida > 0)
            {

                if (enemigo.Estado == "Saludable")
                {

                    jugador.Vida -= enemigo.Daño_fisico;
                    vida_jugador.Content = "Puntos de vida: " + jugador.Vida.ToString();
                    monitorPelea.Text += "\n" + jugador.Nombre + " Ha perdido " + enemigo.Daño_fisico + " puntos de vida.";

                }
                else
                {

                    enemigo.Estado = "Saludable";
                    monitorPelea.Text += "\n" + enemigo.Nombre + " Ya no se encuentra paralizado. ";

                }

                if(jugador.Vida <= 0)
                {
                    MessageBox.Show("Has perdido");
                    Close();
                }

                turno_Jugador = true;
            }
            else
            {
                MessageBox.Show("Has ganado");
                Close();
            }

        }
    }
}
