using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectQueue myQueue = new ObjectQueue();
            for (int i = 1; i < 51; i++)
            {
                myQueue.Enqueue(i);
                Console.WriteLine(myQueue.Length);

            }

            object num = myQueue.Dequeue();
            Console.WriteLine(num);
            myQueue.Enqueue("Love");
            myQueue.Enqueue("You");
            object str = myQueue.Dequeue();
            Console.WriteLine(myQueue.Length);

        }
    }
    class ObjectQueue
    {
        private int _capacity;

        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }
        
        private int _frontIndex;
        public int FrontIndex
        {
            get { return _frontIndex;}
            set { _frontIndex = value;}
        }
        private int length;
        public int Length
        {
            get { return length;}
            set {length = value;}
        }

        public int BackIndex 
        {
            get { return (FrontIndex + Length) % Capacity ;}
        }
       
        //private Object[] _items;
        //protected Object[] Items
        //{
        //    get {return _items;}
        //    set { _items = value;}
        //}

        public Object[] Items;

        public ObjectQueue()
        {

            Capacity = 10;
            Items = new Object[Capacity];
        }

        public ObjectQueue(int capacity)
        {
            Capacity = capacity;
            Items = new Object[Capacity];
        }
        public void Enqueue(Object e)
        {
            if (Length == Capacity)
            {
                IncreaseCapacity();
            }
            
                Items[BackIndex] = e;
                Length++;
        }

        public object Dequeue()
        {
            if (Length == 0)
            {
                return "Queue is empty";
            }
            else
            {
                Object e = Items[FrontIndex];
                Items[FrontIndex++] = default(Object);
                Length--;
                return e;

            }
        }

        protected int IncreaseCapacity()
        {
            this.Capacity *= 2;
            Object[] tempItems = new Object[Capacity];
            for (int i = 0; i < Length; i++)
            {
                tempItems[i] = Items[i];
            }
            this.Items = tempItems;
            return Capacity;
        }
    }
}
