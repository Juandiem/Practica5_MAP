using System;
using NUnit.Framework;
using Listas;
using System.Collections.Generic;

namespace Test
{
    [TestFixture]
    public class TestLista
    {
        int lim = 30, rep = 2;
        [Test]
        public void NumElemsListaVacia()
        {
            //Arrange
            Lista unaLista = new Lista();
            //Act
            int numElemsLista = unaLista.NumElems();
            //Assert
            Assert.That(numElemsLista,
                        Is.EqualTo(0),
                        "ERROR: NumElems no devuelve 0 con lista vacía");
        }

        [Test]
        public void NumElemsListaAxB()
        {
            //Arrange
            Lista lista = new Lista(lim, rep);
            //Act
            int numElemsLista = lista.NumElems();
            //Assert
            Assert.That(numElemsLista,
                        Is.EqualTo(lim * rep),
                        "ERROR: NumElems no ha devuelto la cantidad de elementos correctamente");
        }

        [Test]
        public void InsertaFinInt()
        {
            //Arrange
            int e = 25;
            Lista lista = new Lista(lim, rep);
            //Act
            lista.InsertaFinal(e);
            //Assert
            Assert.That(e,
                        Is.EqualTo(lista.NEsimo(lim * rep)),
                        "ERROR: InsertaFin ha insertado el elemento " + e + " correctamente.");
        }


        [Test]
        public void EliminaElemExiste()
        {
            //Arrange
            int e = lim;
            Lista lista = new Lista(lim, rep);
            //Act
            lista.EliminaElto(e);
            //Assert
            Assert.That(e,
                        Is.Not.EqualTo(lista.NEsimo(lim - 1)),
                        "ERROR: EliminaElem no ha eliminado el elemento " + e + " que sí que se encontraba en la lista");
        }

        [Test]
        public void EliminaElemNoExiste()
        {
            //Arrange
            int e = lim + 1;
            Lista lista = new Lista(lim, rep);
            //Act
            bool result = lista.EliminaElto(e);
            //Assert

            Assert.That(result,
                        Is.False,
                        "ERROR: EliminaElem ha devuelto true con un elemento que no se encontraba en la lista como parámetro");
        }

        [Test]
        public void NEsimoDentroLimites()
        {
            //Arrange
            int n = lim;
            Lista lista = new Lista(lim, rep);
            //Act
            int nElem = lista.NEsimo(n);
            //Assert
            Assert.That(nElem,
                        Is.EqualTo(n % lim + 1),
                        "ERROR: NEsimo no ha devuelto el elemento " + n + " de la lista correctamente");
        }

        [Test]
        public void NEsimoFueraLimites()
        {
            //Arrange
            Lista lista = new Lista(lim, rep);
            //Act
            int n = lim*rep;
            //Assert
            Assert.That(() => { lista.NEsimo(n); },
                        Throws.Exception,
                        "ERROR: NEsimo no lanza excepción cuando se introduce un índice fuera de límites");
        }

        static void Main(string[] args)
        {
        }
    }
}
