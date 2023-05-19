using Array;
using Queue.Contract;


namespace Queue
{
    public class ArrayQueue<T> : IQueue<T>
    {
        private Array<T> InnerArray;
        public ArrayQueue()
        {
            InnerArray = new Array<T>();
        }
        public ArrayQueue(IEnumerable<T> collection) : this()
        {
            foreach (var item in collection)
            {
                Enqueue(item);
            }
        }
        public int Count => InnerArray.Count;

        public T Dequeue()
        {
            if (Count == 0)
                throw new Exception("The queue is empty!");
            var temp = InnerArray.RemoveItem(0);
            return temp;
        }

        public void Enqueue(T item)
        {
            InnerArray.Add(item);
        }

        public T Peek()
        {
            return Count == 0 ? default : InnerArray.GetItem(0);
        }
    }
}
