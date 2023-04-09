using System;
using Gtk;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using ZXing;
using ZXing.SkiaSharp;

namespace Prueba1
{
    class Program
    {                

        [Obsolete]
        static void Main()
        {
            Application.Init();

            Window win = new Window("iot-solution");

            //Creación de un nuevo Grid
            Grid innerGrid = new Grid();
            Grid outerGrid = new Grid();                                    

            //Creación de botones
            int spaceBetweenButtons = 5;    //private readonly 

            Button button1 = new Button();
            button1.Label = "NUEVA COMPRA";
            button1.SetSizeRequest(300, 100);
            button1.Clicked += Onbutton1Clicked;            
            AddExpandProperties(button1);                        
            AddMarginProperty(button1, spaceBetweenButtons);            

            Button button2 = new Button();
            button2.Label = "CONSULTAS ESTADO NEVERA";
            button2.SetSizeRequest(300, 100);
            button2.Clicked += Onbutton2Clicked;
            AddExpandProperties(button2);
            AddMarginProperty(button2, spaceBetweenButtons);

            Button button3 = new Button();
            button3.Label = "IDEAS NUEVAS RECETAS";
            button3.SetSizeRequest(300, 100);
            button3.Clicked += Onbutton3Clicked;
            AddExpandProperties(button3);
            AddMarginProperty(button3, spaceBetweenButtons);

            //Metemos los botones en el Grid y ajustamos su posición
            innerGrid.Attach(button1, 2, 0, 1, 1);             //(child, left, top, width, height)
            innerGrid.Attach(button2, 1, 2, 1, 1);                           
            innerGrid.Attach(button3, 2, 3, 1, 1);                           

            // button1.Halign = Align.Center;
            // button1.Valign = Align.Center;

            //Introducimos el Grid interior en el exterior y ambos en una box, esta a su vez en la Window   
            AddExpandProperties(innerGrid);         
            outerGrid.Attach(innerGrid, 10, 10, 1, 1);
            // Box box = new Box(Gtk.Orientation.Vertical, 0);
            // box.PackStart(outerGrid, true, true, 0);
            win.Add(outerGrid);

            //Inicializamos la ventana
            Gdk.RGBA backgroundColor = new Gdk.RGBA();
            backgroundColor.Parse("#9B9B9B");
            win.OverrideBackgroundColor(StateFlags.Normal, backgroundColor); //Este método da warning, habría que buscar otra opción            
            win.ShowAll();
            win.Fullscreen();

            Application.Run();
        }

        //Funciones botones    
        //Botón 1
       static void Onbutton1Clicked(object sender, EventArgs arg)
       {
          Process.Start("libcamera-still", "-f -t 5000 -o barcode.jpg");
          // var txt = "Hola";  
          File.ReadAllBytes("/barcode.png");
          Bitmap barcodeBitmap = new Bitmap(@"/barcode.jpg");          
          var reader = new BarcodeReader();
          // BarcodeReader<EAN_8> reader = new BarcodeReader<UPCEANReader>();
          Result barcode = reader.Decode(barcodeBitmap);
          // if(results != null)
          // {
          //      Console.Write("A barcode has been readed");
          //      foreach(BarcodeResult result in results)
          //      {
          //           Console.Write(result.Text);
          //      } 
          // }
          
          // BarcodeReaderGeneric reader = new BarcodeReaderGeneric();
          
          //   BarcodeWriter barcodeWriter = new ZXing.BarcodeWriter();
          //   barcodeWriter.Format = BarcodeFormat.CODABAR;
          //   Bitmap bm =  new Bitmap(barcodeWriter.Write(txt), 300, 300);
          
          // Result barcode = reader.           
            // Process.Start("rm", "barcode.jpg");

       }
       //Botón 2
       static void Onbutton2Clicked(object sender, EventArgs arg)
       {

       }
       //Botón 3
       static void Onbutton3Clicked(object sender, EventArgs arg)
       {

       }

       static void AddExpandProperties(Widget widget)
       {
            widget.Hexpand = true;
            widget.Vexpand = true;
       }

       static void AddMarginProperty(Widget widget, int margin)
       {
            widget.Margin = margin;
       }
    }
}
