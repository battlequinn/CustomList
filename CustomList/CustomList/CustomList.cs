using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> : IEnumerable
    
    {
        public T[] items;
        public int size;
        private T[] openArray = new T[0];

        public CustomList()
        {
            items = openArray;
            size = 0;
        }
        public CustomList(int size)
        {
            if (size < 0)
            {
                throw new System.ArgumentOutOfRangeException("Cannot have a negative list capacity.");
            }
            else
            {
                items = openArray;
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return items[i];
            }
        }
        public string ToString()
        {
            string convertedItem = "";
            for (int i = 0; i < size; i++)
            {
                if (i < size-1)
                {
                    convertedItem += (items[i].ToString() + ", ");
                }else
                {
                    convertedItem += items[i].ToString();
                }
            }
            return convertedItem;
        }
        public void Add(T item)
        {
            if(size == items.Length)
            {
                T[] tempArray = new T[size+1];
                for(int i = 0; i < size; i++)
                {
                    tempArray[i] = items[i];
                }
                tempArray[size] = item;
                size++;
                items = tempArray;
            }
        }
        public void Remove(T item)
        {

            if (item != null)
            {
                bool leftovers = false;
                T[] tempArray = new T[size - 1];
                for (int i = 0; i < size; i++)
                {
                    if ((!EqualityComparer<T>.Default.Equals(items[i], item)) && leftovers == false)
                    {
                        tempArray[i] = items[i];
                    }
                    else if (i != size - 1)
                    {
                        tempArray[i] = items[i + 1];
                        leftovers = true;
                    }
                }
                size--;
                items = tempArray;
            }
        }
    }
}
