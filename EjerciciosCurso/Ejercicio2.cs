using System;
using System.Collections.Generic;
using System.Text;

namespace EjerciciosCurso {
    public class Ejercicio2 {
        public static void Ejecutar() {
            var n = new Random().Next(1, 100);
            Console.WriteLine("Adivina que número he pensado:");
            for (var i = 1; i <= 10; i++) {
#if DEBUG
                Console.WriteLine($"Dame un número entre el {1} y {100} ({n}) [Intento {i}]: ");
#else
                Console.WriteLine($"Dame un numero entre el {1} y {100} [Intento {i}]: ");
#endif
                var cad = Console.ReadLine().ToLower();
                if (cad == "fin") break;
                try {
                    var n2 = int.Parse(cad);
                    if (n2 == n) {
                        Console.WriteLine("Acertaste :)");
                        return;
                    }
                    Console.WriteLine(n2 < n ? "No llegas" : "Te pasas");
                } catch (Exception) {
                    Console.WriteLine($"No es un número válido.");
                }
            }
            Console.WriteLine("\nOoooh! No has podido. :(\n\n");
        }
    }
}
