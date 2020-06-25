using System;
using System.Drawing;

namespace EjerciciosCurso {
    class Program {
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
                //calculadora.Decodificar("3+4+3,4-7*1=", (n,o) => Console.WriteLine($"{n} {o}"));
                calculadora.Resultado += (sender, e) => Console.WriteLine($"{e.Operando} {e.Operacion} --> {e.Resultado}");
                calculadora.Calcula("3+4+3,4-7*1=");
                Console.WriteLine(calculadora.Acumulador);

                //string cad = "Hola mundo";
                //Console.WriteLine(Validaciones.IsLenMax(cad, 10));
                //Console.WriteLine(cad.IsLenMax(10));

                Console.WriteLine(new Circulo(10));
                Console.WriteLine(new Triangulo(5, 10, Color.Green));
                Console.WriteLine(new Rectangulo(5, 10));
                Console.WriteLine(new Cuadrado(10, Color.Red));

            } catch (Exception e) {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }
}
