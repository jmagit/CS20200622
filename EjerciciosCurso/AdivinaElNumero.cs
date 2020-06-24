using System;
using System.Collections.Generic;
using System.Text;

namespace EjerciciosCurso {
    class AdivinaElNumero {
        public static void Jugar() {
            var objetivo = new Random().Next(0, 100);
            Console.WriteLine("Adivina que número he pensado:");
            for (var i = 1; i <= 10; i++) {
#if DEBUG
                Console.WriteLine($"Dame un número entre el 0 y 100 ({objetivo}) [Intento {i}]: ");
#else
                Console.WriteLine($"Dame un numero entre el 0 y 100 [Intento {i}]: ");
#endif
                var leido = Console.ReadLine().ToLower();
                if (leido == "fin") break;
                try {
                    var num = int.Parse(leido);
                    if (num == objetivo) {
                        Console.WriteLine("Acertaste :)");
                        return;
                    } else
                        Console.WriteLine(num < objetivo ? "No llegas" : "Te pasas");
                } catch (Exception e) {
                    Console.WriteLine($"No es un número válido.");
                }
            }
            Console.WriteLine("\nOoooh! No has podido. :(\n\n");
        }
    }
}
