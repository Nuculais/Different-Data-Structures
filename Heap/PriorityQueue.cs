using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heap
{
    public class PriorityQueue<TKey, TValue> where TKey : IComparable<TKey>
    {
        MinHeap<PriorityQueueNode<TKey, TValue>> Heapen = new MinHeap<PriorityQueueNode<TKey, TValue>>(50);


        //Tar bort ett element ur kön
        public void Dequeue()
        {           
            Heapen.Remove(Heapen.Items[0]);
            //for (int i = 0; i < queueHeap.Items.Length; i++)
            //{
            //    if (Equals(queueHeap.Items[i], item))
            //    {
            //        queueHeap.Remove(queueHeap.Items[i]);
            //    }
            //}
        }

        //Lägger till ett element i kön
        public void Enqueue(TValue item, TKey order)
        {
            PriorityQueueNode<TKey, TValue> Nod = new PriorityQueueNode<TKey, TValue>(item, order);
            Heapen.Add(Nod);
        }

        //Visar det första elementet i kön
        public TValue Peek()
        {
            return Heapen.Items[0].Item;
        }

        public override string ToString()
        {
            string Sträng = "";

            foreach (PriorityQueueNode<TKey, TValue> Nod in Heapen.Items)
            {
                if (Nod != null)
                {
                    Sträng += Nod.Item + "," + Nod.Priority + "  ";
                }

            }

            return Sträng;
        }
    }

    /// <summary>
    /// Typ som används för noderna i prioritetskön. En nod 
    /// innehåller både en prioritet samt ett generiskt värde.
    /// </summary>
    public class PriorityQueueNode<TKey, TValue> : IComparable<PriorityQueueNode<TKey, TValue>>
        where TKey : IComparable<TKey>
    {
        public TKey Priority { get; private set; }
        public TValue Item { get; private set; }

        public PriorityQueueNode(TValue item, TKey priority)
        {
            this.Priority = priority;
            this.Item = item;
        }

        public int CompareTo(PriorityQueueNode<TKey, TValue> other)
        {
            return Priority.CompareTo(other.Priority);
        }
    }
}
