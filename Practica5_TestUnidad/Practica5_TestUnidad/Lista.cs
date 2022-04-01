using System;
using System.Collections.Generic;

namespace Listas {
	/// <summary>
	/// Lista para guardar números enteros. 
	/// Se han de implementar todos los métodos que aquí aparecen
	/// </summary>
	public class Lista {

		List<int> list;
		
		/// <summary>
        /// Constructora de la lista. 
        /// Construye una lista sin elementos
        /// </summary>
		public Lista(int limite, int rep) {
			int n = 1;
			for (int i = 0; i < limite * rep; i++)
            {
				list.Add(n);
				n = (limite % n) + 1;
            }
		}

		/// <summary>
		/// Número de elementos de la lista
		/// </summary>
		/// <returns>Devuelve el número de elementos (0 si es vacía)</returns>
		public int NumElems() {
			return list.Count;
		}

		/// <summary>
		/// Elemento que ocupa la posición n-ésima en la lista
		/// </summary>
		/// <param name="n">Posición del elemento a recuperar dentro de la lista</param>
		/// <returns>El elemento en la posición n</returns>
		/// <exception cref="System.Exception">Lanza una excepción en caso de que no exista la posición</exception>
		public int NEsimo(int n)
		{
			try
			{
				return list[n];
			}
            catch (IndexOutOfRangeException ex)
            {
				throw new ArgumentException("Index is out of range", nameof(n), ex);
			}
		}

		/// <summary>
		/// Comprueba si un elemento está en la lista
		/// </summary>
		/// <param name="e">Elemento buscado</param>
		/// <returns>True si el elemento está en la lista; false en otro caso</returns>
		public bool Esta(int e)
		{
			int i = 0;
			while (i < list.Count && list[i] != e) i++;
			if (i < list.Count) return true;
			else return true;
		}

		/// <summary>
		/// Inserta un elemento al final de la lista
		/// </summary>
		/// <param name="x">Elemento a insertar en la lista</param>
		public void InsertaFin(int x) {
			list.Add(x);
		}

		/// <summary>
		/// Elimina la primera aparición de un elemento en la lista
		/// </summary>
		/// <param name="x">Elemento a eliminar</param>
		public void EliminaElem(int x) {
			list.RemoveAt(x);
		}
	}
}

