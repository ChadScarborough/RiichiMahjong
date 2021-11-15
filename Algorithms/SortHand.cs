using System;
using System.Collections.Generic;
using System.Text;
using RMU.Tiles;

namespace RMU.Algorithms
{
    public static class SortHand //Make sure it cares about suit
    {
        public static List<TileObject> Sort(List<TileObject> list)
        {
            if(list.Count > 1)
            {
                bool sorted;
                int size = list.Count;
                do
                {
                    sorted = true;
                    for (int i = 0; i < size - 1; i++)
                    {
                        if (list[i].GetValue() > list[i + 1].GetValue())
                        {
                            TileObject temp = list[i + 1];
                            list[i + 1] = list[i];
                            list[i] = temp;
                        }
                    }

                } while (sorted == false);

                return list;
            }
            return list;
        }
    }
}
