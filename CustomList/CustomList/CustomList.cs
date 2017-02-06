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
        public T[] items = new T[0];
        private int size = 0;

        public int Count { get { return size; } }

        public CustomList()
        {
        }
        public CustomList(int size)
        {
            if (size < 0)
            {
                throw new System.ArgumentOutOfRangeException("Cannot have a negative list capacity.");
            }
            else
            {
                size = items.Length;
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < size; i++)
            {
                yield return items[i];
            }
        }
        public override string ToString()
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
            bool exists = false;
            for(int i = 0; i < size; i++)
            {
                if(EqualityComparer<T>.Default.Equals(items[i], item))
                {
                    exists = true;
                }
            }
            if (exists == true)
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
        public static CustomList<T> operator +(CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> newCustomList = new CustomList<T>();
            for (int i = 0; i < listOne.items.Length; i++)
            {
                newCustomList.Add(listOne.items[i]);
            }
            for (int i = 0; i < listTwo.items.Length; i++)
            {
                newCustomList.Add(listTwo.items[i]);
            }
            return newCustomList;
        }
        public static CustomList<T> operator -(CustomList<T> listOne, CustomList<T> listTwo)
        {
            for (int i = 0; i < listTwo.items.Length; i++)
            {
                listOne.Remove(listTwo.items[i]);
            }
            return listOne;
        }
        public CustomList<T> Zip(CustomList<T> listOne)
        {
            CustomList<T> newCustomList = new CustomList<T>();
            CustomList<T> tempList = new CustomList<T>();
            for(int i = 0; i < size; i++)
            {
                tempList.Add(items[i]);
            }
            for(int i = size; i < 0 ; i--)
            {
                Remove(items[i]);
            }
            for (int i = 0; i < size; i++)
            {
                newCustomList.Add(tempList.items[i]);
                newCustomList.Add(listOne.items[i]);
            }
            return newCustomList;
        }
    }
}