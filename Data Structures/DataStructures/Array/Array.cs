using System.Collections;

namespace Array
{
    public class Array<T> : IEnumerable<T>
    {
        private T[] _InnerArray;
        private int _Index = 0;
        public int Count => _Index;
        public int Capacity => _InnerArray.Length;

        public Array()
        {
            _InnerArray = new T[4];
        }
        public Array(params T[] init)
        {
            var newArray = new T[init.Length];
            System.Array.Copy(init, newArray, init.Length);
            _InnerArray = newArray;
        }

        private void DoubleArray(T[] array)
        {
            var newArray = new T[array.Length * 2];
            System.Array.Copy(array, newArray, array.Length);
            _InnerArray = newArray;
        }
        public void Add(T item)
        {
            if (_Index == _InnerArray.Length)
            {
                DoubleArray(_InnerArray);
            }
            //_InnerArray.Append(item);
            _InnerArray[_Index] = item;
            _Index++;
        }
        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
        public T GetItem(int position)
        {
            if (position < 0 || position >= _InnerArray.Length)
                throw new IndexOutOfRangeException();
            return _InnerArray[position];
        }
        public void SetItem(int position, T item)
        {
            if (position < 0 || position >= _InnerArray.Length)
                throw new IndexOutOfRangeException();
            _InnerArray[position] = item;
        }
        private void Swap(int p1, int p2)
        {
            var temp = _InnerArray[p1];
            _InnerArray[p1] = _InnerArray[p2];
            _InnerArray[p2] = temp;
        }
        public bool Remove(T item)
        {
            for (int i = 0; i < _InnerArray.Length; i++)
            {
                if (_InnerArray[i].Equals(item))
                {
                    _InnerArray[i] = default(T);
                    for (int j = i; j < _InnerArray.Length - 1; j++)
                    {
                        Swap(j, j + 1);
                    }

                    _Index--;
                    if (_Index == _InnerArray.Length / 2)
                        HalfList(_InnerArray);
                    return true;
                }
            }

            return false;
        }
        public void HalfList(T[] list)
        {
            var newList = new T[list.Length / 2];
            System.Array.Copy(list, newList, newList.Length);
            _InnerArray = newList;
        }
        public T RemoveItem(int position)
        {
            var item = GetItem(position);
            SetItem(position, default);
            for (int i = position; i < Count - 1; i++)
            {
                Swap(i, i + 1);
            }
            _Index--;
            if (_Index == _InnerArray.Length / 2)
            {
                var newArray = new T[_InnerArray.Length / 2];
                System.Array.Copy(_InnerArray, newArray, newArray.Length);
                _InnerArray = newArray;
            }
            return item;

        }
        public int Find(T item)
        {

            for (int i = 0; i < _InnerArray.Length; i++)
            {
                if (item.Equals(_InnerArray[i]))
                {
                    return i;
                }
                continue;
            }
            return -1;
        }
        public T[] Copy(int v1, int v2)
        {
            var newArray = new T[v2 - v1];
            int j = 0;
            for (int i = v1; i < v2; i++)
            {
                newArray[j] = GetItem(i);
                j++;
            }
            return newArray;
        }
        public T[] InterSect(IEnumerable<T> collection)
        {
            // throw new NotImplementedException();
            T[] newList = new T[_InnerArray.Length];
            int i = 0;
            foreach (T item in _InnerArray.Intersect(collection).ToList())
            {
                if (item != null)
                {
                    newList[i] = item;
                    i++;
                }
            }

            return newList;
        }
        public T[] Union(IEnumerable<T> collection)
        {
            // throw new NotImplementedException();
            T[] newList = new T[_InnerArray.Length + collection.Count()];
            int i = 0;
            foreach (T item in _InnerArray.Union(collection).ToList())
            {
                if (item != null)
                {
                    newList[i] = item;
                    i++;
                }
            }

            return newList;
        }
        public T[] Except(IEnumerable<T> collection)
        {
            // throw new NotImplementedException();
            T[] newList = new T[_InnerArray.Length];
            int i = 0;
            foreach (T item in _InnerArray.Except(collection).ToList())
            {
                if (item != null)
                {
                    newList[i] = item;
                    i++;
                }
            }

            return newList;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _InnerArray.Take(_Index).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}