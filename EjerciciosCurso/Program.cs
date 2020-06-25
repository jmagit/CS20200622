using System;
using System.Drawing;
using EjerciciosCurso.Util;

namespace EjerciciosCurso {
    class Program {

        static void Pinta(string n, string o) {
            Console.WriteLine($"{n} {o}");
        }
        static void OtroPinta(string n, string o) {
            Console.WriteLine($"\t{n} {o}");
        }
        static void TocaNarices(string n, string o) {
            Console.WriteLine($"\t{n}\n\t{o}");
        }

        static void Main() {
            //var ejer = new Ejercicio1();

            //ejer.Ejecutar();

            //do {
            //    AdivinaElNumero.Jugar();
            //    Console.WriteLine("\n¿Volver a jugar?");
            //} while (Console.ReadLine().ToLower() == "si");

            try {
                Calculadora calculadora = new Calculadora();
                calculadora.Decodificar("3+4+3,4-7*1=");
                //calculadora.Decodificar("3333  + 4,6 +3,4 -7* 1=");
                //Action<string, string> fn = delegate (string n, string o) {
                //    Console.WriteLine($"\t{n}\t{o}");
                //};
                //calculadora.Decodificar("3+4+3,4-7*1=", Program.Pinta);
                //calculadora.Decodificar("3+4+3,4-7*1=", delegate (string n, string o) {
                //    Console.WriteLine($"\t\t{n}\t{o}");
                //});
                //calculadora.Decodificar("3+4+3,4-7*1=", (n, o) => Console.WriteLine($"\t\t{n}\t{o}"));
                int cont = 0;
                string titulo = "algo";
                EventHandler<CalculoEventArgs> fn = (sender, e) => cont++;
                calculadora.Resultado += (sender, e) => Console.WriteLine($"{titulo} {e.Operando}\t{e.Operacion} --> {e.Resultado}");
                calculadora.Resultado += fn;
                calculadora.Calcula("3+4+3,4-7*1=");
                Console.WriteLine(calculadora.Acumulador);
                Console.WriteLine(cont);
                calculadora.Resultado -= fn;
                cont = 0;
                titulo = "";
                calculadora.Calcula("3+4+3,4-7*1=");
                Console.WriteLine(calculadora.Acumulador);
                Console.WriteLine(cont);

            } catch (Exception e) {
                Console.WriteLine("ERROR: " + e.Message);
            }

            //string cad = "Hola mundo";
            //Console.WriteLine(ValidacionesExtender.IsLenMax(cad, 10));
            //Console.WriteLine(cad.IsLenMax(10));

            //Figura[] tabla = { new Circulo(10), new Triangulo(5, 10, Color.Green), new Rectangulo(5, 10), new Cuadrado(10, Color.Red) };
            //double areaTabla = 0;
            //foreach (var f in tabla)
            //    areaTabla += f.Area;
            //Console.WriteLine($"Área Tabla: {areaTabla}");
            //areaTabla = 0;
            //foreach (var f in tabla)
            //    if(f is Circulo c)
            //        areaTabla += c.Area;
            //    else if(f is Triangulo t)
            //        areaTabla += t.Area;
            //    else if(f is Cuadrado cua)
            //        areaTabla += cua.Area;
            //    else if(f is Rectangulo r)
            //        areaTabla += r.Area;
            //Console.WriteLine($"Área Tabla: {areaTabla}");
            //areaTabla = 0;
            //foreach (var f in tabla)
            //    switch(f.GetType().Name) {
            //        case "Circulo": areaTabla += f.Area; break;
            //        case "Triangulo": areaTabla += f.Area; break;
            //        case "Rectangulo": areaTabla += f.Area; break;
            //        case "Cuadrado": areaTabla += f.Area; break;
            //    }
            //Console.WriteLine($"Área Tabla: {areaTabla}");

            //var ensamblado = typeof(Triangulo).Assembly;
            //var nom = "EjerciciosCurso.Circulo";
            //Type clase = ensamblado.GetType(nom);
            //dynamic instancia = ensamblado.CreateInstance(nom, ); // = clase.
            //areaTabla = instancia.Area;
        }
    }
}
