using System;
using Gtk;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using ZXing;
using IronBarCode;
// using ZXing.Presentation;
// using SixLabors.ImageSharp;
// using SixLabors.ImageSharp.PixelFormats;
using System.Collections.Generic;
// using Image = SixLabors.ImageSharp.Image;

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
          //ESCANEAR MIENTRAS ESTÁ LA CAMARA ABIERTA

          //Create and congif Scanner
          // var scanner = new ImageScanner();
          // // scanner.SetConfiguration(SymbolType.None, Config.Enable, 0);
          // scanner.Cache = false;

          // var keepScanning = true;
          // var cont = 0;
          // while(keepScanning)
          // {
          //      Process.Start("libcamera-still", "-f -t 5000 -o barcode.jpg");
          //      // System.Drawing.Image barcode = System.Drawing.Image.FromFile("barcode.jpg");
          //      System.IntPtr barcodeBitmap = new System.IntPtr();          
          //      System.Drawing.Image barcode = System.Drawing.Image.FromHbitmap(barcodeBitmap);
               
          //      List<Symbol> barcodeScanned = scanner.Scan(barcode);
          //      if(barcodeScanned != null || cont > 100){
          //           Console.Write("Se ha escaneado el código :", barcodeScanned.ToString());
          //           keepScanning = false;
          //      }
          //      cont ++;
          // }
          // Console.Write("He salido del while");
          // Task.Run(() => ScanBarcodes());



          //HACER FOTO Y ESCANEAR
          // Dictionary<DecodeHintType, object> hints = new Dictionary<DecodeHintType, object>();
          // hints.Add(DecodeHintType.TRY_HARDER, true);

          // MultiFormatReader readerParams = new MultiFormatReader();
          // Func<object, LuminanceSource> imageFunc = (object input) =>
          // {
          //      var bitmap = (Bitmap)input;
          //      var source = new LuminanceSource(bitmap);
          // };

          // BarcodeReader reader = new BarcodeReader(); 

          // var keepScanning = true;
          // var cont = 0;
          // while(keepScanning)
          // {
          //      Process.Start("libcamera-still", "-f -t 5000 -o barcode.jpg");               
               // System.Drawing.Image barcodeBitmap = new System.Drawing.Image(@"/barcode.jpg");          
               // Image<Rgba32> barcodeImagea = Image.Load<Rgba32>("/barcode.jpg");
               // Gtk.Image barcodeImage = new Gtk.Image("/barcode.jpg");
               // var image = new System.Drawing.Image.FromFile("barcode.jpg");
               // var barcodeScanned = reader.Decode(barcodeImage);
               
               // if(barcodeScanned != null || cont > 100){
               //      Console.Write("Se ha escaneado el código :", barcodeScanned.ToString());
               //      keepScanning = false;
               // }
               // cont ++;
          // }
          // Console.Write("He salido del while");
          // Process.Start("libcamera-still", "-f -t 5000 -o barcode.jpg");
          // var txt = "Hola";  
          // File.ReadAllBytes("/barcode.png");
          // Bitmap barcodeBitmap = new Bitmap(@"/barcode.jpg");          
          // var reader = new BarcodeReader();
          // BarcodeReader<EAN_8> reader = new BarcodeReader<UPCEANReader>();
          // Result barcode = reader.Decode(barcodeBitmap);
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
          var keepScanning = true;
          var cont = 0;
          while(keepScanning)
          {
               Process.Start("libcamera-still", "-f -t 5000 -o barcode.jpg");               
               var result = IronBarCode.BarcodeReader.Read(@"barcode.jpg");
               if(result != null || cont > 100){
                    Console.Write("Se ha escaneado el código :",result.First().Text);
               }
               cont ++;
          }
          Console.Write("He salido del while");
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
