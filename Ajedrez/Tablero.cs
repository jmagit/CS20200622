using System;
using System.Collections.Generic;

namespace Juegos {
    /// <summary>
    /// Representa al Tablero del juego como contenedor de piezas.
    /// </summary>
    [Serializable()]
    public class Tablero : ICloneable {

        /// <summary>
        /// Matriz de 8x8 posiciones, que representa al tablero y permite almacenar las piezas del juego.
        /// </summary>
        private Pieza[,] piezas = new Pieza[8, 8];

        /// <summary>
        /// Obtiene o establece la pieza del tablero indicada por la fila y la columna.
        /// </summary>
        /// <param name="fila">Fila de la posición en el tablero.</param>
        /// <param name="columna">Columna de la posición en el tablero.</param>
        /// <value>Pieza en el tablero, nulo en caso de que no haya pieza.</value>
        /// <exception cref="IndexOutOfRangeException">Posición fuera del tablero.</exception>
        [System.Runtime.CompilerServices.IndexerName("Escaque")]
        public Pieza this[int fila, int columna] {
            get {
                if (!esValido(fila) || !esValido(columna))
                    throw new IndexOutOfRangeException("Posición fuera del tablero.");
                return piezas[fila - 1, columna - 1];
            }
            set {
                if (!esValido(fila) || !esValido(columna))
                    throw new IndexOutOfRangeException("Posición fuera del tablero.");
                piezas[fila - 1, columna - 1] = value;
            }
        }
        /// <summary>
        /// Obtiene o establece la pieza del tablero indicada por la posición.
        /// </summary>
        /// <param name="p">Posición en el tablero.</param>
        /// <value>Pieza en el tablero, nulo en caso de que no haya pieza.</value>
        [System.Runtime.CompilerServices.IndexerName("Escaque")]
        public Pieza this[Posicion p] {
            get {
                return this[p.Fila, p.Columna];
            }
            set {
                this[p.Fila, p.Columna] = value;
            }
        }

        /*

        /// <summary>
        /// Diccionario indexado por posiciones, que representa al tablero y permite almacenar las piezas del juego.
        /// </summary>
        private Dictionary<Posicion, Pieza> piezas = new Dictionary<Posicion, Pieza>(32);

        /// <summary>
        /// Obtiene o establece la pieza del tablero indicada por la fila y la columna.
        /// </summary>
        /// <param name="fila">Fila de la posición en el tablero.</param>
        /// <param name="columna">Columna de la posición en el tablero.</param>
        /// <value>Pieza en el tablero, nulo en caso de que no haya pieza.</value>
        /// <exception cref="IndexOutOfRangeException">Posición fuera del tablero.</exception>
        [System.Runtime.CompilerServices.IndexerName("Escaque")]
        public Pieza this[int fila, int columna] {
            get {
                if (!esValido(fila) || !esValido(columna))
                    throw new IndexOutOfRangeException("Posición fuera del tablero.");
                return this[new Posicion(fila, columna)];
            }
            set {
                if (!esValido(fila) || !esValido(columna))
                    throw new IndexOutOfRangeException("Posición fuera del tablero.");
                this[new Posicion(fila, columna)] = value;
            }
        }
        /// <summary>
        /// Obtiene o establece la pieza del tablero indicada por la posición.
        /// </summary>
        /// <param name="p">Posición en el tablero.</param>
        /// <value>Pieza en el tablero, nulo en caso de que no haya pieza.</value>
        [System.Runtime.CompilerServices.IndexerName("Escaque")]
        public Pieza this[Posicion p] {
            get {
                return piezas.ContainsKey(p) ? piezas[p] : null;
            }
            set {
                if (piezas.ContainsKey(p))
                    if (value == null)
                        piezas.Remove(p);
                    else
                        piezas[p] = value;
                else
                    piezas.Add(p, value);
            }
        }
         
       */

        /// <summary>
        /// Verifica que la fila o columna se encuentra dentro del
        /// tablero. Valor entre 1 y 8.
        /// </summary>
        /// <param name="indice">Valor a verificar</param>
        /// <returns>true si es valido</returns>
        private bool esValido(int indice) {
            return 1 <= indice && indice <= 8;
        }
        /// <summary>
        /// Muestra si hay una pieza ocupando una posición del tablero indicada por la fila y la columna.
        /// </summary>
        /// <param name="fila">Fila de la posición en el tablero.</param>
        /// <param name="columna">Columna de la posición en el tablero.</param>
        /// <returns>Es true si hay pieza en el tablero; en caso contrario, es false.</returns>
        public bool HayPieza(int fila, int columna) {
            return this[fila, columna] != null;
        }

        /// <summary>
        /// Muestra si hay una pieza ocupando una posición del tablero.
        /// </summary>
        /// <param name="p">Posición en el tablero.</param>
        /// <returns>Es true si hay pieza en el tablero; en caso contrario, es false.</returns>
        public bool HayPieza(Posicion p) {
            return HayPieza(p.Fila, p.Columna);
        }

        /// <summary>
        /// Quita la pieza que ocupa la posición del tablero indicada por la fila y la columna.
        /// </summary>
        /// <param name="fila">Fila de la posición en el tablero.</param>
        /// <param name="columna">Columna de la posición en el tablero.</param>
        public void QuitaPieza(int fila, int columna) {
            if (this[fila, columna] is IDisposable)
                (this[fila, columna] as IDisposable).Dispose();
            this[fila, columna] = null;
        }

        /// <summary>
        /// Quita la pieza que ocupa la posición del tablero indicada por la fila y la columna.
        /// </summary>
        /// <param name="p">Posición en el tablero.</param>
        public void QuitaPieza(Posicion p) {
            QuitaPieza(p.Fila, p.Columna);
        }
        /// <summary>
        /// Mueve la pieza del tablero desde la posición inicial a la posición final indicada por el movimiento.
        /// </summary>
        /// <param name="m">Movimiento a realizar.</param>
        public void Mover(Movimiento m) {
            if (!HayPieza(m.PosicionInicial))
                throw new JuegoException("No hay pieza para mover.");
            if (HayPieza(m.PosicionFinal))
                QuitaPieza(m.PosicionFinal);
            this[m.PosicionFinal] = this[m.PosicionInicial];
            this[m.PosicionInicial] = null;
        }

        /// <summary>
        /// Indica si hay piezas en el tablero entre la posición inicial y la posición final indicada por el movimiento, sin incluir dichas posiciones.
        /// </summary>
        /// <param name="m">Movimiento a verificar.</param>
        /// <returns>Es true si hay piezas en la trayectoria; en caso contrario, es false.</returns>
        /// <exception cref="JuegoException">Genera la excepción si el movimiento no es horizontal, vertical o diagonal.</exception>
        public bool HayPiezaEntre(Movimiento m) {
            if (!m.esDiagonal() && !m.esHorizontal() && !m.esVertical())
                throw new JuegoException("El movimiento debe ser horizontal, vertical o diagonal para verificar si hay piezas entre la posición inicial y la posición final.");
            int dColum = m.DeltaColumna();
            int dFila = m.DeltaFila();
            Posicion pos = new Posicion(m.PosicionInicial.Fila + dFila,
                m.PosicionInicial.Columna + dColum);
            for (; pos != m.PosicionFinal; pos.Fila += dFila, pos.Columna += dColum)
                if (HayPieza(pos)) return true;
            return false;
        }
        /// <summary>
        /// Realiza una copia del tablero.
        /// </summary>
        /// <returns>Tablero copiado.</returns>
        public object Clone() {
            Tablero t = new Tablero();
            for (int i = 1; i <= 8; i++)
                for (int j = 1; j <= 8; j++)
                    t[i, j] = this[i, j];
            // Mejor
            // t.piezas = (Pieza[,])this.piezas.Clone();
            // Mal
            // t.piezas = this.piezas;

            return t;
            // Copia superficial 
            // return this.MemberwiseClone();
        }

        /// <summary>
        /// Método de clase para informar al interfaz gráfico 
        /// de que color es el escaque. 
        /// </summary>
        /// <param name="fila">Fila de la posición en el tablero.</param>
        /// <param name="columna">Columna de la posición en el tablero.</param>
        /// <returns>Color del escaque.</returns>
        public static Color ColorEscaque(int fila, int columna) {
            return (fila + columna) % 2 == 0 ? Color.Negro : Color.Blanco;
        }
    }
}
