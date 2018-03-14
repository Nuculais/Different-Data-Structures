using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heap
{
    public class MinHeap<T> where T : IComparable<T>
    {

        private T[] Heapen;

        int heapSize = 0;

        public MinHeap(int heapSize)
        {
            Heapen = new T[heapSize];
        }
        private void shiftUp(int index)
        {
            int parentIndex;
            T tmp;
            if (index != 0)
            {
                parentIndex = parentNode(index);
                if (Heapen[parentIndex].CompareTo(Heapen[index]) > 0)
                {
                    tmp = Heapen[parentIndex];
                    Heapen[parentIndex] = Heapen[index];
                    Heapen[index] = tmp;
                    shiftUp(parentIndex);
                }
            }
        }

        private int parentNode(int Index)
        {
            return (Index - 1) / 2;
        }
        public void Add(T item)
        {
            if (heapSize == Heapen.Length)
            {
                return;
            }

            else
            {
                heapSize++;
                Heapen[heapSize - 1] = item;
                shiftUp(heapSize - 1);
            }
           
        }
        
        public T[] Items
        {
            get { return Heapen; }
        }

        public bool Remove(T item)
        {
            var index = Array.IndexOf(Heapen, item);         
            int v = 2 * index + 1;
            int h = 2 * index + 2;

            //Om värdet som skall tas bort ej finns
            if (index < 0)
            {
                return false;
            }

            heapSize = heapSize - 1;
            Heapen[index] = Heapen[heapSize];
            Heapen[heapSize] = default(T);

            while (v < heapSize && Heapen[index].CompareTo(Heapen[v]) > 0 || h < heapSize && Heapen[index].CompareTo(Heapen[h]) > 0)
            {
                //Vilken barnnod som skall ersätta den borttagna
                if (Heapen[v].CompareTo(Heapen[h]) < 0)
                {
                    T temp = Heapen[index];
                    Heapen[index] = Heapen[v];
                    Heapen[v] = temp;
                    index = v;
                }
                else
                {
                    T tmp = Heapen[h];
                    Heapen[h] = Heapen[index];
                    Heapen[index] = tmp;
                    index = h;
                }
            }

            return true;
        }

        /// <summary>
        /// Metod som jämför om ett objekt är större än ett annat objekt.
        /// </summary>
        private bool Larger(IComparable<T> first, T second)
        {
            return first.CompareTo(second) > 0;
        }

        public override string ToString()
        {
            string resultat = "";
            foreach (T value in Heapen)
            {
                if (!value.Equals(default(T)))
                {
                    resultat += value + ", ";
                }

            }
            return resultat;
        }
    }
}
