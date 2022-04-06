using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WallE;

namespace Test
{
    [TestFixture]
    public class TestWallE
    {
        [Test]
        public void ContructoraWallE()
        {
            //Arrange
            WallE.WallE wallE = new WallE.WallE();
            //Act
            //Assert
            Assert.That(wallE.GetPosition(),
                        Is.EqualTo(0),
                        "ERROR: WallE no empieza en la posición inicial asignada");
            Assert.That(wallE.getNumItems(),
                       Is.EqualTo(0),
                       "ERROR: WallE no empieza con una lista vacía");
        }

        [Test]
        public void MoveWallE()
        {
            //Arrange
            WallE.Map map = new WallE.Map(7,3);
            WallE.WallE wallE = new WallE.WallE();
            //Act
            map.CreateTestMap();
            wallE.Move(map, WallE.Direction.North);
            wallE.Move(map, WallE.Direction.East);
            //Assert
            Assert.That(wallE.GetPosition(),
                        Is.EqualTo(5),
                        "ERROR: WallE no se encuentra en la posición a la que se ha movido");
        }

        [Test]
        public void PickItemWallE()
        {
            //Arrange
            WallE.Map map = new WallE.Map(7, 3);
            WallE.WallE wallE = new WallE.WallE();
            //Act
            map.CreateTestMap();
            wallE.PickItem(map, 1);
            //Assert
            Assert.That(wallE.getItemNameInBag(map,0),
                       Is.EqualTo("Scrap"),
                       "ERROR: WallE no ha cogido el objeto asignado del lugar");
            Assert.That(wallE.getNumItems(),
                       Is.Not.EqualTo(0),
                       "ERROR: WallE no ha cogido correctamente el objeto");
        }

        [Test]
        public void DropItemWallE()
        {
            //Arrange
            WallE.Map map = new WallE.Map(7, 3);
            WallE.WallE wallE = new WallE.WallE();
            //Act
            map.CreateTestMap();
            wallE.PickItem(map, 0);
            wallE.DropItem(map, 0);
            //Assert
            Assert.That(map.getItemNameInPlace(wallE.GetPosition(),1),
                       Is.EqualTo("News"),
                       "ERROR: WallE no ha soltado el objeto asignado en el lugar");
            Assert.That(wallE.getNumItems(),
                       Is.EqualTo(0),
                       "ERROR: WallE tiene aún el objeto");
        }

        [Test]
        public void BagWallEVacia()
        {
            //Arrange
            WallE.Map map = new WallE.Map(7, 3);
            WallE.WallE wallE = new WallE.WallE();
            //Act
            map.CreateTestMap();
            wallE.PickItem(map, 0);
            wallE.DropItem(map, 0);
            //Assert
            Assert.That(wallE.Bag(map),
                       Is.EqualTo("There is nothing in the bag \n"),
                       "ERROR: WallE no tiene objetos en la bolsa pero no aparece como vacía");
        }

        [Test]
        public void BagWallENoVacia()
        {
            //Arrange
            WallE.Map map = new WallE.Map(7, 3);
            WallE.WallE wallE = new WallE.WallE();
            //Act
            map.CreateTestMap();
            wallE.PickItem(map, 0);
            wallE.PickItem(map, 1);
            //Assert
            Assert.That(wallE.Bag(map),
                       Is.Not.EqualTo("There is nothing in the bag \n"),
                       "ERROR: WallE tiene objetos en la bolsa pero aparece como vacía");
        }

        [Test]
        public void AtSpaceShipWallE()
        {
            //Arrange
            WallE.Map map = new WallE.Map(7, 3);
            WallE.WallE wallE = new WallE.WallE();
            //Act
            map.CreateTestMap();
            wallE.Move(map, WallE.Direction.South);
            wallE.Move(map, WallE.Direction.East);
            //Assert
            Assert.That(map.isSpaceShip(wallE.GetPosition()),
                        Is.True,
                        "ERROR: WallE no se encuentra en la nave a pesar de estar en el mismo lugar");
        }

        [Test]
        public void NotAtSpaceShipWallE()
        {
            //Arrange
            WallE.Map map = new WallE.Map(7, 3);
            WallE.WallE wallE = new WallE.WallE();
            //Act
            map.CreateTestMap();
            wallE.Move(map, WallE.Direction.North);
            //Assert
            Assert.That(map.isSpaceShip(wallE.GetPosition()),
                        Is.False,
                        "ERROR: WallE no se encuentra en la nave sin embargo devuelve que si");
        }
    }
}
