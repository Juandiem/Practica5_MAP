using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WallE
{
    
    public enum Direction { North, South, East, West };
    class Map
    {
        // items basursa
        struct Item
        {
            public string name, description;
        }
        // lugares del mapa
        struct Place
        {
            public string name, description;
            public bool spaceShip;
            public int[] connections; // vector de 4 componentes
                                      // con el lugar al norte, sur, este y oeste
                                      // -1 si no hay conexión en esa dirección
            public Lista itemsInPlace; // lista de índices al vector ítems,
                                       // correspondientes a los ítems que hay en este lugar
        }
        Place[] places; // vector de lugares del mapa
        Item[] items; // vector de ítems que hay en el juego
        int nPlaces, nItems; // número de lugares y número de ítems
        public Map(int numPlaces, int numItems)
        {
            nPlaces = 0;
            nItems = 0;
            places = new Place[numPlaces];
            items = new Item[numItems];
        }
        public void ReadMap(string file)
        {
            StreamReader entrada = new StreamReader(file);
            while (!entrada.EndOfStream)
            {
                string f = entrada.ReadLine();
                string[] p = f.Split();
                if(p[0]== "place")
                {
                    CreatePlace(p);
                    places[int.Parse(p[1])].description= ReadDescription(entrada);
                }
                else if(p[0]== "street")
                {
                    CreateStreet(p);
                }
                else if(p[0]== "garbage")
                {
                    CreateItem(p);
                }

            }
        }
        private void CreatePlace(string[] p)
        {
            places[int.Parse(p[1])].name = p[2];
            places[int.Parse(p[1])].spaceShip = p[3]=="spaceShip";
            InitPlaceConnections(int.Parse(p[1]));
            places[int.Parse(p[1])].itemsInPlace = new Lista();
            nPlaces++;
        }
        private void CreateStreet(string[] p)
        {
            int d = dir(p[2]);
            places[int.Parse(p[1])].connections[d] = int.Parse(p[3]);
            places[int.Parse(p[3])].connections[dir2(d)] = int.Parse(p[1]);
        }
        private void CreateItem(string[] p)
        {
            items[nItems].name = p[3];
            items[nItems].description = "";
            for (int i = 4; i < p.Length; i++)
            {
                items[nItems].description += p[i];
            }
            places[int.Parse(p[2])].itemsInPlace.InsertaFinal(nItems);
            nItems++;
        }
        //leer la descripción de los lugares
        private string ReadDescription(StreamReader f)
        {
            string des="";
            string l = f.ReadLine();
            while (l!="")
            {
                des+= l+"\n";
                l = f.ReadLine();
            }
            return des;
        }
        //transforma un string de direccion a un numero (relacion establecido por el enum)
        public int dir(string d)
        {
            int x = -1;
            if (d == "north")
            {
                x = 0;
            }
            else if (d == "south")
            {
                x = 1;
            }
            else if (d == "east")
            {
                x = 2;
            }
            else if (d == "west")
            {
                x = 3;
            }
            return x;
        }
        //devuelve el int que indicar el direccion contraria que el direccion indicado por int d
        private int dir2(int d)
        {
            int x = -1;
            if (d == 0||d==1)
            {
                x = 1 - d;
            }
            else if (d == 2 || d == 3)
            {
                x = 5 - d;
            }
            return x;
        }
        private void InitPlaceConnections(int n)
        {
            places[n].connections = new int[4];
            for(int i = 0; i < places[n].connections.Length; i++)
            {
                places[n].connections[i] = -1;
            }
        }
        //devuelve toda la información del lugar indicado pl.
        public string GetPlaceInfo(int pl)
        {
            return places[pl].description;
        }
        //devuelve los movimientos posibles desde el lugar pl.
        public string GetMoves(int pl)
        {
            string moves = "";
            for(int i = 0; i < places[pl].connections.Length; i++)
            {
                if (places[pl].connections[i] != -1)
                {
                    moves += (Direction)i + ": " + places[places[pl].connections[i]].name + "\n";
                }
            }
            return moves;
        }

        public string GetPlaceName(int pos)
        {
            return places[pos].name;
        }
        // devuelve la información sobre los ítems que hay en el lugar pl
        public string GetItemsPlace(int pl)
        {
            string it = "";
            int[] d = places[pl].itemsInPlace.Dados();
            for (int i = 0; i <d.Length; i++)
            {
                it += i + " " + items[d[i]].name + " " + items[d[i]].description+"\n";
            }
            if (it == "")
            {
                it = "There is no garbage\n";
            }
            return it;
        }
        //elimina el ítem it del lugar pl
        public void PickItemPlace(int pl, int it)
        {
            places[pl].itemsInPlace.EliminaElto(it);
        }
        // deja el ítem it en el lugar pl
        public void DropItemPlace(int pl, int it)
        {
            places[pl].itemsInPlace.InsertaFinal(it);
        }
        //devuelve el lugar al que se llega desde el lugar pl avanzando en la dirección dir(-1 en caso de error)
        public int Move(int pl, Direction dir)
        {
            return places[pl].connections[(int)dir];
        }
        //comprueba si el lugar pl es la nave de WALL·E.
        public bool isSpaceShip(int pl)
        {
            return places[pl].spaceShip;
        }

        public string ItemsString(int n)
        {
            return items[n].name + ": " +'"'+ items[n].description+'"';
        }
        public int NumItem(int n,int pos)
        {
            return places[pos].itemsInPlace.Dado(n);
        }

    }

    
}
