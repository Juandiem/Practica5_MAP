using System;
using NUnit.Framework;
using Listas;
using System.Collections.Generic;
using WallE;

namespace Test
{
    [TestFixture]
    public class TestMap
    {
        [Test]
        public void GetMovesNoConections()
        {
            //Arrange
            Map map = new Map(7, 3);
            //Act
            map.CreateTestMap();
            string moves = map.GetMoves(6);
            //Assert
            Assert.That(moves,
                Is.EqualTo(""),
                "ERROR: GetMoves no devuelve un string vacío cuando no hay movimientos disponibles");
        }

        [Test]
        public void GetMovesConections()
        {
            //Arrange
            Map map = new Map(7, 3);
            //Act
            map.CreateTestMap();
            string moves = map.GetMoves(0);
            //Assert
            Assert.That(moves,
                Is.EqualTo("North: ZonaD\nSouth: ZonaB\nWest: ZonaC\n"),
                "ERROR: GetMoves no devuelve el string con los movimientos correctamente");
        }

        [Test]
        public void GetPlaceInfo()
        {
            //Arrange
            Map map = new Map(7, 3);
            //Act
            map.CreateTestMap();
            string info = map.GetPlaceInfo(0);
            //Assert
            Assert.That(info,
                Is.EqualTo("Esta es la Zona A"),
                "ERROR: GetPlaceInfo no devuelve el string descripción correctamente");
        }

        [Test]
        public void GetPlaceNoInfo()
        {
            //Arrange
            Map map = new Map(7, 3);
            //Act
            map.CreateTestMap();
            string info = map.GetPlaceInfo(6);
            //Assert
            Assert.That(info,
                Is.EqualTo(""),
                "ERROR: GetPlaceInfo no devuelve un string vacío cuando no hay descripción");
        }

        [Test]
        public void GetItemsPlace()
        {
            //Arrange
            Map map = new Map(7, 3);
            //Act
            map.CreateTestMap();
            string items = map.GetItemsPlace(0);
            //Assert
            Assert.That(items,
                Is.EqualTo("0 News Periódico\n1 Scrap Chatarra\n"),
                "ERROR: GetItemsPlace no devuelve el string de los objetos correctamente");
        }

        [Test]
        public void GetItemsPlaceNoItems()
        {
            //Arrange
            Map map = new Map(7, 3);
            //Act
            map.CreateTestMap();
            string items = map.GetItemsPlace(2);
            //Assert
            Assert.That(items,
                Is.EqualTo("There is no garbage\n"),
                "ERROR: GetItemsPlace no devuelve There is no garbage cuando no hay objetos en el lugar");
        }

        [Test]
        public void PickItemPlace()
        {
            //Arrange
            Map map = new Map(7, 3);
            //Act
            map.CreateTestMap();
            string items = map.GetItemsPlace(0);
            map.PickItemPlace(0, 0);
            //Assert
            Assert.That(items,
                Is.Not.EqualTo(map.GetItemsPlace(0)),
                "ERROR: PickItemPlace no borra el objeto del lugar correctamente");
        }

        [Test]
        public void PickItemPlaceNoItem()
        {
            //Arrange
            Map map = new Map(7, 3);
            //Act
            map.CreateTestMap();
            string items = map.GetItemsPlace(0);
            map.PickItemPlace(0, 2);
            //Assert
            Assert.That(items,
                Is.EqualTo(map.GetItemsPlace(0)),
                "ERROR: PickItemPlace borra el objeto del lugar cuando no debería");
        }

        [Test]
        public void DropItemPlace()
        {
            //Arrange
            Map map = new Map(7, 3);
            //Act
            map.CreateTestMap();
            string items = map.GetItemsPlace(0);
            map.DropItemPlace(0, 2);
            //Assert
            Assert.That(items,
                Is.Not.EqualTo(map.GetItemsPlace(0)),
                "ERROR: DropItemPlace no añade el objeto al lugar correctamente");
        }

        [Test]
        public void MovePlace()
        {
            //Arrange
            Map map = new Map(7, 3);
            //Act
            map.CreateTestMap();
            int north = map.Move(0, Direction.North);
            int south = map.Move(0, Direction.South);
            int east = map.Move(3, Direction.East);
            int west = map.Move(0, Direction.West);

            //Assert
            Assert.That(north,
                Is.EqualTo(3),
                "ERROR: Move no devuelve el lugar correcto al moverte al norte");
            Assert.That(south,
                Is.EqualTo(1),
                "ERROR: Move no devuelve el lugar correcto al moverte al sur");
            Assert.That(east,
                Is.EqualTo(5),
                "ERROR: Move no devuelve el lugar correcto al moverte al este");
            Assert.That(west,
                Is.EqualTo(2),
                "ERROR: Move no devuelve el lugar correcto al moverte al oeste");

        }

        [Test]
        public void MoveNoPlace()
        {
            //Arrange
            Map map = new Map(7, 3);
            //Act
            map.CreateTestMap();
            int north = map.Move(6, Direction.North);
            int south = map.Move(6, Direction.South);
            int east = map.Move(6, Direction.East);
            int west = map.Move(6, Direction.West);

            //Assert
            Assert.That(north,
                Is.EqualTo(-1),
                "ERROR: Move no devuelve -1 cuando no puedes moverte al norte");
            Assert.That(south,
                Is.EqualTo(-1),
                "ERROR: Move no devuelve -1 cuando no puedes moverte al sur");
            Assert.That(east,
                Is.EqualTo(-1),
                "ERROR: Move no devuelve -1 cuando no puedes moverte al este");
            Assert.That(west,
                Is.EqualTo(-1),
                "ERROR: Move no devuelve -1 cuando no puedes moverte al oeste");
        }

        [Test]
        public void IsSpaceShip()
        {
            //Arrange
            Map map = new Map(7, 3);
            //Act
            map.CreateTestMap();
            bool spaceShip = map.isSpaceShip(4);
            //Assert
            Assert.That(spaceShip,
                Is.True,
                "ERROR: IsSpaceShip no devuelve true cuando estás en el lugar correcto");
        }

        [Test]
        public void IsNotSpaceShip()
        {
            //Arrange
            Map map = new Map(7, 3);
            //Act
            map.CreateTestMap();
            bool spaceShip = map.isSpaceShip(0);
            //Assert
            Assert.That(spaceShip,
                Is.False,
                "ERROR: IsSpaceShip devuelve true cuando no estás en el lugar correcto");
        }

        [Test]
        public void CreatePlace()
        {
            //Arrange
            Map map = new Map(1, 0);
            //Act
            map.TestCreatePlace("place 0 ZonaA noSpaceShip".Split());
            string name = map.GetPlaceName(0);
            bool spaceShip = map.isSpaceShip(0);
            //Assert
            Assert.That(spaceShip,
                Is.False,
                "ERROR: CreatePlace no crea la variable spaceShip correctamente");
            Assert.That(name,
                Is.EqualTo("ZonaA"),
                "ERROR: CreatePlace no crea la variable name correctamente");
        }

        [Test]
        public void CreateStreet()
        {
            //Arrange
            Map map = new Map(3, 0);
            //Act
            map.TestCreatePlace("place 0 ZonaA noSpaceShip".Split());
            map.TestCreatePlace("place 1 ZonaB noSpaceShip".Split());
            map.TestCreatePlace("place 2 ZonaC noSpaceShip".Split());
            map.TestCreateStreet("street 0 south 1".Split());
            map.TestCreateStreet("street 0 west 2".Split());
            string moves = map.GetMoves(0);
            //Assert
            Assert.That(moves,
                Is.EqualTo("South: ZonaB\nWest: ZonaC\n"),
                "ERROR: CreateStreet no crea las conexiones correctamente");
        }

        [Test]
        public void CreateItem()
        {
            //Arrange
            Map map = new Map(1, 2);
            //Act
            map.TestCreatePlace("place 0 ZonaA noSpaceShip".Split());
            map.TestCreateItem("garbage place 0 News Periódico".Split());
            map.TestCreateItem("garbage place 0 Scrap Chatarra".Split());
            string items = map.GetItemsPlace(0);
            //Assert
            Assert.That(items,
                Is.EqualTo("0 News Periódico\n1 Scrap Chatarra\n"),
                "ERROR: CreateItem no crea los objetos correctamente");
        }




    }
}
