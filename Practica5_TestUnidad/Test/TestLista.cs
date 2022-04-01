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
        public void NumElemsListaVacía()
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
        public void NumElems()
        {
            //Arrange
            lim = 3; rep = 2;
            Lista lista = new Lista(lim, rep);
            //Act
            int numElemsLista = lista.NumElems();
            //Assert
            Assert.That(numElemsLista,
                        Is.EqualTo(lim * rep),
                        "ERROR: Lista no ha podido devolver la cantidad de elementos en ella");
        }

        [Test]
        public void InsertaFin()
        {
            //Arrange
            int e = 25;
            Lista lista = new Lista(lim, rep);
            //Act
            lista.InsertaFin(e);
            //Assert
            Assert.That(e,
                        Is.EqualTo(lista.NEsimo(lim * rep)),
                        "ERROR: Lista no ha podido insertar el elemento " + e);
        }


        [Test]
        public void EliminaElem()
        {
            //Arrange
            int e = lim;
            Lista lista = new Lista(lim, rep);
            //Act
            lista.EliminaElem(e);
            //Assert

            Assert.That(e,
                        Is.Not.EqualTo(lista.NEsimo(lim - 1)),
                        "ERROR: Lista no ha podido eliminar el elemento" + e + "por que no existe o no se ha encontrado");
        }

        [Test]
        public void NEsimo()
        {
            //Arrange
            int n = lim;
            Lista lista = new Lista(lim, rep);
            //Act
            int nElem = lista.NEsimo(n);
            //Assert
            Assert.That(nElem,
                        Is.EqualTo(n % lim + 1),
                        "ERROR: Lista no ha podido devolver el elemento " + n + "lista");
        }

        static void Main(string[] args)
        {
        }
    }
}
