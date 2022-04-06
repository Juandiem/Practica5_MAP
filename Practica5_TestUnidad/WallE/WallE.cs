using System;
using System.Collections.Generic;
using System.Text;
using Listas;

namespace WallE
{
    public class WallE
    {
        int pos; // posicion de Wall-e en el mapa
        Lista bag; // lista de ítems recogidos por wall-e
                   // (son índices a la lista de ítems del mapa)

        public WallE()
        {
            pos = 0;
            bag = new Lista();
        }
        public int GetPosition()
        {
            return pos;
        }
        public void Move(Map m,Direction dir)
        {
            pos = m.Move(pos, dir);
        }
        public void PickItem(Map m,int it)
        {
            m.PickItemPlace(pos,it);
            bag.InsertaFinal(it);
        }
        public void DropItem(Map m,int it)
        {
            bag.EliminaElto(it);
            m.DropItemPlace(pos, it);
        }
        public string Bag(Map m)
        {
            string b = "";
            int[] d = bag.Dados();
            for(int i = 0; i < d.Length; i++)
            {
                b += i + " " + m.ItemsString(d[i]) + "\n";
            }
            if (d.Length == 0)
            {
                b = "There is nothing in the bag \n";
            }
            return b;
        }

        public bool AtSpaceShip(Map map)
        {
            return map.isSpaceShip(pos);
        }
        public int NumItem(int n)    //devuelve el valor de item que esta en el bag ,si no existe devuelve un -1
        {
            return bag.Dado(n);
        }

        #region Test Map
        public int getNumItems()
        {
            return bag.NumElems();
        }

        public string getItemNameInBag(Map m,int i)
        {
            string item = "";
            int[] d = bag.Dados();
            if (i < d.Length)
                item = m.ItemName(d[i]);

            return item;
        }
        #endregion


    }
}
