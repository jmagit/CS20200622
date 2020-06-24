using System;
using System.Collections.Generic;
using System.Text;

namespace EjerciciosCurso {
    class AdivinaElNumero {
        public const byte MAX_INTENTOS = 10;
        public const byte NUMERO_INICIAL = 1;
        public const byte NUMERO_FINAL = 100;
        public static void Jugar() {
            var objetivo = new Random().Next(NUMERO_INICIAL, NUMERO_FINAL);
            Console.WriteLine("Adivina que número he pensado:");
            for (var intento = 1; intento <= MAX_INTENTOS; intento++) {
#if DEBUG
                Console.WriteLine($"Dame un número entre el {NUMERO_INICIAL} y {NUMERO_FINAL} ({objetivo}) [Intento {intento}]: ");
#else
                Console.WriteLine($"Dame un numero entre el {NUMERO_INICIAL} y {NUMERO_FINAL} [Intento {i}]: ");
#endif
                var leido = Console.ReadLine().ToLower();
                if (leido == "fin") break;
                try {
                    var número = int.Parse(leido);
                    if (número == objetivo) {
                        Console.WriteLine("Acertaste :)");
                        return;
                    }
                    Console.WriteLine(número < objetivo ? "No llegas" : "Te pasas");
                } catch (Exception) {
                    Console.WriteLine($"No es un número válido.");
                }
            }
            Console.WriteLine("\nOoooh! No has podido. :(\n\n");
        }
    }
}
