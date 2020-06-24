using System;

namespace EjerciciosCurso {
    class Program {
        static void Main(string[] args) {
            var ejer = new Ejercicio1();

            ejer.Ejecutar();

            do {
                AdivinaElNumero.Jugar();
                Console.WriteLine("\n¿Volver a jugar?");
            } while (Console.ReadLine().ToLower() == "si");
        }
    }
}
