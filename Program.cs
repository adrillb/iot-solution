using System;
using Gtk;

namespace Prueba1
{
    class Program
    {        
        static void Main()
        {
            Application.Init();

            Window win = new Window("iot-solution");

            //Creación de un nuevo Grid
            Grid grid = new Grid();
            win.Add(grid);

            //Creación de botones
            Button button1 = new Button();
            button1.Label = "NUEVA COMPRA";
            button1.SetSizeRequest(300, 100);
            button1.Clicked += Onbutton1Clicked;

            Button button2 = new Button();
            button2.Label = "CONSULTAS ESTADO NEVERA";
            button2.SetSizeRequest(300, 100);
            button2.Clicked += Onbutton2Clicked;

            Button button3 = new Button();
            button3.Label = "IDEAS NUEVAS RECETAS";
            button3.SetSizeRequest(300, 100);
            button3.Clicked += Onbutton3Clicked;

            //Metemos los botones en el Grid y ajustamos su posición
            grid.Attach(button1, 2, 1, 1, 1);             //(child, left, top, width, height)
            grid.Attach(button2, 2, 2, 2, 2);                           
            grid.Attach(button3, 2, 3, 3, 3);                           

            //Inicializamos la ventana
            Gdk.RGBA backgroundColor = new Gdk.RGBA();
            backgroundColor.Parse("#9B9B9B");
            win.OverrideBackgroundColor(StateFlags.Normal, backgroundColor); //Este método da warnign, habría que buscar otra opción            
            win.ShowAll();
            win.Fullscreen();

            Application.Run();
        }

        //Funciones botones    
        //Botón 1
       static void Onbutton1Clicked(object sender, EventArgs arg)
       {

       }
       //Botón 2
       static void Onbutton2Clicked(object sender, EventArgs arg)
       {

       }
       //Botón 3
       static void Onbutton3Clicked(object sender, EventArgs arg)
       {

       }
    }
}
