using System;

namespace Juegos.Ajedrez {
    class AjedrezConsola {
        static void Main(string[] args) {
            var juego = new Juego();
            juego.Inicializar();
            juego.Promocion += new PromocionEventHandler(Juego_Promocion);
            do {
                string jugada;
                Console.Write("Juegan las " + (juego.Turno == Color.Blanco ?
                    "BLANCAS" : "NEGRAS"));
                Console.Write(". Dame movimiento (FIN para terminar): ");
                jugada = Console.ReadLine();
                if (jugada.ToUpper() == "FIN" || jugada.ToUpper() == "TABLAS")
                    break;
                try {
                    juego.Jugada(jugada);
                } catch (JuegoException ex) {
                    Console.WriteLine("ERROR: " + ex.Message);
                } catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    break;
                }
            } while (true);
        }
        #region Gestión de la promoción
        /// <summary>
        /// Controlador de eventos para la promoción de los peones.
        /// </summary>
        private static void Juego_Promocion(object sender, PromocionEventArgs e) {
            String cad;
            Console.Write("Dame tipo de pieza: ");
            cad = Console.ReadLine();
            switch (cad.ToLower()) {
                case "dama":
                    e.Pieza = new Dama((sender as Peon).Color);
                    break;
                case "alfil":
                    e.Pieza = new Alfil(e.Pieza.Color);
                    break;
                case "torre":
                    e.Pieza = new Torre((sender as Peon).Color);
                    break;
                case "caballo":
                    e.Pieza = new Caballo((sender as Peon).Color);
                    break;
                default:
                    throw new JuegoException("ERROR: El nombre de la pieza debe ser: Dama, Alfil, Torre o Caballo");
            }
        }
        #endregion
    }
}
