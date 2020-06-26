using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace TheCSharpFantasy
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            controlJugador controlJugador;            

        }


        public void Iniciar_Pelea(object sender, RoutedEventArgs e)
        {            

            Personaje enemigo;
            Instancia_Enemigo instanciador = new Instancia_Enemigo();
            enemigo = instanciador.Instanciar_Enemigo_Random();

            FightWindow ventanaDePelea = new FightWindow(controlJugador.jugador, enemigo);

            ventanaDePelea.Show();

        }



        private void Seleccionar_Clase(object sender, RoutedEventArgs e)
        {
            Button clase = (Button)sender;

            switch (clase.Content.ToString())
            {
                case "Guerrero":
                    controlJugador.jugador = new Guerrero(textbox_nombreJugador.Text.ToString());
                    break;

                case "Mago":
                    controlJugador.jugador = new Mago(textbox_nombreJugador.Text);
                    break;

                case "Asesino":
                    controlJugador.jugador = new Asesino(textbox_nombreJugador.Text);
                    break;

                case "Arquero":
                    controlJugador.jugador = new Arquero(textbox_nombreJugador.Text);
                    break;
            }

           
        }
    }
}
