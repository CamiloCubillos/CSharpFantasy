using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TheCSharpFantasy
{
    public class Personaje
    {
        public string Nombre;
        public int Vida;
        public int Daño_fisico;
        public int Energia;
        public int Daño_magico;
        public int Mana;
        public int Sigilo;
        public int Suerte;
        public string Estado;
        public string Imagen;

    }

    public class Guerrero : Personaje
    {        
        public Guerrero(String nombre)
        {
            this.Nombre = nombre;
            this.Vida = 100;
            this.Daño_fisico = 5;
            this.Energia = 50;
            this.Daño_magico = 0;
            this.Mana = 0;
            this.Sigilo = 1;
            this.Suerte = 1;
            this.Imagen = "/media/img/ilustracion_guerrero.jpg";
            this.Estado = "Saludable";

        }

    }

    public class Mago : Personaje
    {
        public Mago(String nombre)
        {
            this.Nombre = nombre;
            this.Vida = 80;
            this.Daño_fisico = 2;
            this.Energia = 20;
            this.Daño_magico = 5;
            this.Mana = 50;
            this.Sigilo = 1;
            this.Suerte = 3;
            this.Imagen = "/media/img/ilustracion_mago.jpg";
            this.Estado = "Saludable";
        }

    }

    public class Arquero : Personaje
    {
        public Arquero(String nombre)
        {
            this.Nombre = nombre;
            this.Vida = 60;
            this.Daño_fisico = 7;
            this.Energia = 50;
            this.Daño_magico = 2;
            this.Mana = 20;
            this.Sigilo = 3;
            this.Suerte = 1;
            this.Imagen = "/media/img/ilustracion_arquero.jpg";
            this.Estado = "Saludable";
        }

    }

    public class Asesino : Personaje
    {
        public Asesino(String nombre)
        {
            this.Nombre = nombre;
            this.Vida = 50;
            this.Daño_fisico = 10;
            this.Energia = 20;
            this.Daño_magico = 0;
            this.Mana = 0;
            this.Sigilo = 5;
            this.Suerte = 5;
            this.Imagen = "/media/img/ilustracion_asesino.jpg";
            this.Estado = "Saludable";
        }

    }

    public class controlJugador
    {
        public static Personaje jugador;
    }


    public class Instancia_Enemigo
    {
        public Personaje Instanciar_Enemigo_Random()
        {
            Random semilla = new Random();

            Personaje enemigo = new Personaje();

            int claseACrear = semilla.Next(1, 5);

            switch (claseACrear)
            {
                case 1:
                    enemigo = new Guerrero("Guerrero");
                    return enemigo;

                case 2:
                    enemigo = new Mago("Mago");
                    return enemigo;

                case 3:
                    enemigo = new Asesino("Asesino");
                    return enemigo;

                case 4:
                    enemigo = new Arquero("Arquero");
                    return enemigo;

                default:
                    break;
            }

            return enemigo;

        }

    }

    public class Ataque_Fisico
    {

        float Daño;       
        float Gasto_Energia;

        public Ataque_Fisico(float daño, float gasto_energia)
        {

            this.Daño = daño;
            this.Gasto_Energia = gasto_energia;

        }

    }

    public class Ataque_Magico
    {

        float Daño;
        float Gasto_Mana;

        public Ataque_Magico(float daño, float gasto_mana)
        {

            this.Daño = daño;
            this.Gasto_Mana = gasto_mana;

        }

    }


}
