using System;

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
                //calculadora.Decodificar("3+4+3,4-7*1=");
                calculadora.Decodificar("3+4+3,4-7*1=", (n,o) => Console.WriteLine($"{n} {o}"));
                calculadora.Calcula("3+4+3,4-7*1=");
                Console.WriteLine(calculadora.Acumulador);
                //calculadora.Decodificar("3+43   +  4 +3.4-7*1=");
            } catch (Exception e) {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }
}
