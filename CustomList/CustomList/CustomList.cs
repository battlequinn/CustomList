using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T> : IEnumerable where T : IComparable
    {
        public T[] items = new T[0];
        private int size = 0;

        public int Count { get { return size; } }

        public CustomList()
        {
        }
        public CustomList(int size)
        {
        }
        public T this[int number]
        {
            get
            {
                if (number >= 0 && number < size)
                {
                    return items[number];
                }
                else
                {
                    throw new Exception("Index Out Of Range");
                }
            }
            set
            {
                if (number >= 0 && number < size)
                {
                    items[number] = value;
                }
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
            for (int i = 0; i < size; i++)
            {
                newCustomList.Add(items[i]);
                newCustomList.Add(listOne.items[i]);
            }
            return newCustomList;
        }
        public CustomList<T> Sort()
        {
            CustomList<T> newCustomList = new CustomList<T>();
            int i, j;
            for (i = 1; i < size; i++)
            {
                T item = items[i];
                int ins = 0;
                for (j = i - 1; j >= 0 && ins != 1;)
                {
                    int x = item.CompareTo(items[j]);
                    if (x < 0)
                    {
                        items[j + 1] = items[j];
                        j--;
                        items[j + 1] = item;
                    }
                    else ins = 1;
                }
            }
            for (int x = 0; x < size; x++)
            {
                newCustomList.Add(items[x]);
            }
            return newCustomList;
        }
    }
}