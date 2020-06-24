using System;

namespace Juegos {
	/// <summary>
	/// Enumeración con los posibles colores de las piezas: Blanco y Negro.
	/// </summary>
	public enum Color {
		Blanco,
		Negro
	}

	/// <summary>
	///  Excepción que se inicia cuando no se cumplen las reglas del juego. 
	/// </summary>
	public class JuegoException : Exception {
		/// <summary>
		///  Inicializa una nueva instancia de la clase Ajedrez.JuegoException con un mensaje de error especificado.
		/// </summary>
		/// <param name="msg">Mensaje que describe el error.</param>
		public JuegoException(String msg):base(msg) {}
	}
}