using System;

namespace Transer.Tecnologia.Automatizacion.Infrastructure
{
    public class Consola
    {
        /*VERSION PRODUCCION*/
        public string _Titulo { get; set; }
        public Random r { get; set; }
        public Consola(string Titulo)
        {
            _Titulo = Titulo;
            r = new Random();
        }
        public void Ih(string mensaje)
        {
            //mensaje += " " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            mensaje += " " + " " + DateTime.Now.ToLongTimeString();
            Console.WriteLine(mensaje);
        }
        public void Ih(string mensaje, bool fecha)
        {
            if (fecha)
            {
                mensaje += " " + " " + DateTime.Now.ToLongTimeString();
            }
            Console.WriteLine(mensaje);
        }
        public void Ihe(string mensaje)
        {
            Console.Write("       ");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(mensaje);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" \r\n");
        }


        public void Cc(string mensaje)
        {
            Console.Clear();
            Console.WriteLine(_Titulo);
            int c = r.Next(0, 9);
            Console.WriteLine(" ");
            Console.Write("Fecha :  " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
            Console.WriteLine(" ");
            Console.WriteLine("");

            Console.Write("Procesando . . . ");
            switch (r.Next(0, 9))
            {
                case 0:
                    {
                        Console.Write("-");
                        break;
                    }
                case 1:
                    {
                        Console.Write("\\");
                        break;
                    }
                case 2:
                    {
                        Console.Write("/");
                        break;
                    }
                case 3:
                    {
                        Console.Write("*");
                        break;
                    }
                case 4:
                    {
                        Console.Write(".");
                        break;
                    }
                case 5:
                    {
                        Console.Write("-");
                        break;
                    }
                case 6:
                    {
                        Console.Write("\\");
                        break;
                    }
                case 7:
                    {
                        Console.Write("/");
                        break;
                    }
                case 8:
                    {
                        Console.Write("*");
                        break;
                    }
                case 9:
                    {
                        Console.Write(".");
                        break;
                    }
                default:
                    {
                        Console.Write("*");
                        break;
                    }
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(mensaje);
        }
        public void CRed()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public void CYellow()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        public void CBlack()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Clear()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }
        public void Cgreen()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public void Cblue()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ReadKey(string mensaje, bool pausar)
        {
            /*Console.Clear();
            Console.WriteLine(_Titulo);
            int c = r.Next(0, 9);
            Console.WriteLine(" ");
            Console.Write("Fecha :  " + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
            Console.WriteLine(" ");
            Console.WriteLine("");
            Console.Write("Procesando . . . ");
            switch (r.Next(0, 9))
            {
                case 0:
                    {
                        Console.Write("-");
                        break;
                    }
                case 1:
                    {
                        Console.Write("\\");
                        break;
                    }
                case 2:
                    {
                        Console.Write("/");
                        break;
                    }
                case 3:
                    {
                        Console.Write("*");
                        break;
                    }
                case 4:
                    {
                        Console.Write(".");
                        break;
                    }
                case 5:
                    {
                        Console.Write("-");
                        break;
                    }
                case 6:
                    {
                        Console.Write("\\");
                        break;
                    }
                case 7:
                    {
                        Console.Write("/");
                        break;
                    }
                case 8:
                    {
                        Console.Write("*");
                        break;
                    }
                case 9:
                    {
                        Console.Write(".");
                        break;
                    }
                default:
                    {
                        Console.Write("*");
                        break;
                    }
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(mensaje);*/
            if (pausar)
            {
                //Console.ReadKey();
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                System.Threading.Thread.Sleep(1000);
            }

        }

    }
}
