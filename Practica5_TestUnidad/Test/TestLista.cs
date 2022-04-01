using System;
using NUnit.Framework;
using Listas;

namespace Test
{
    [TestFixture]
    public class TestLista
    {
        [Test]
        public void NumElemsListaVacía()
        {
            //Arrange
            Lista unaLista = new Lista(3,2);
            //Act
            int numElemsLista = unaLista.NumElems();
            //Assert
            Assert.That(numElemsLista,
                        Is.EqualTo(0),
                        "ERROR: NumElems no devuelve 0 con lista vacía");
        }


        static void Main(string[] args)
        {
            Lista unaLista = new Lista(3, 2);
        }
    }
}
