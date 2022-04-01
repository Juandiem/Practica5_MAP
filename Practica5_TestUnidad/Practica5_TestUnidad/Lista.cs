using System;

namespace Listas {
	/// <summary>
	/// Lista para guardar números enteros. 
	/// Se han de implementar todos los métodos que aquí aparecen
	/// </summary>
	public class Lista {

		/// <summary>
        /// Constructora de la lista. 
        /// Construye una lista sin elementos
        /// </summary>
		public Lista() {
		}

		/// <summary>
		/// Número de elementos de la lista
		/// </summary>
		/// <returns>Devuelve el número de elementos (0 si es vacía)</returns>
		public int NumElems() {
			return 0;
		}

		/// <summary>
		/// Elemento que ocupa la posición n-ésima en la lista
		/// </summary>
		/// <param name="n">Posición del elemento a recuperar dentro de la lista</param>
		/// <returns>El elemento en la posición n</returns>
		/// <exception cref="System.Exception">Lanza una excepción en caso de que no exista la posición</exception>
		public int NEsimo(int n)
		{
			return 0;
		}

		/// <summary>
		/// Comprueba si un elemento está en la lista
		/// </summary>
		/// <param name="e">Elemento buscado</param>
		/// <returns>True si el elemento está en la lista; false en otro caso</returns>
		public bool Esta(int e)
		{
			return false;
		}

		/// <summary>
		/// Inserta un elemento al final de la lista
		/// </summary>
		/// <param name="x">Elemento a insertar en la lista</param>
		public void InsertaFin(int x) {
		}

		/// <summary>
		/// Elimina la primera aparición de un elemento en la lista
		/// </summary>
		/// <param name="x">Elemento a eliminar</param>
		public void EliminaElem(int x) {
		}
	}
}

