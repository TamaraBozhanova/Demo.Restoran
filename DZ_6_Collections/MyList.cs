using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    public class MyList<T> : IList<T>, IEnumerator<T>
    {
        #region fields
        private T[] _arr;
        private int _count;
        private int _currentPos;
        #endregion

        #region properties and indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count) throw new ArgumentOutOfRangeException();
                return _arr[index];
            }
            set
            {
                if (index < 0 || index >= _count) throw new ArgumentOutOfRangeException();
                _arr[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public T Current
        {
            get
            {
                return _arr[_currentPos];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        #endregion

        #region ctors
        public MyList(int capacity = 10)
        {
            _arr = new T[capacity];
            _count = 0;
            _currentPos = -1;
        }
        public MyList(ICollection source)
        {
            _arr = new T[_count = source.Count];
            source.CopyTo(_arr, 0);
            _currentPos = -1;
        }
        #endregion

        public void Add(T val)
        {
            if (_count == _arr.Length)
            {
                T[] tmp = new T[_arr.Length * 2];
                for (int i = 0; i < _arr.Length; ++i)
                {
                    tmp[i] = _arr[i];
                }
                _arr = tmp;
            }
            _arr[_count++] = val;
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(T val)
        {
            foreach (T x in this)
            {
                if (x.Equals(val))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < _count; ++i)
            {
                array[arrayIndex++] = _arr[i];
            }
        }


        public int IndexOf(T val)
        {
            for (int i = 0; i < _count; ++i)
            {
                if (val.Equals(_arr[i]))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T val)
        {
            if (index < 0 || index > _count)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                for (int i = _count; i > index; i--)
                {
                    _arr[i] = _arr[i - 1];
                }
                _arr[index] = val;
                _count++;
            }
        }

        public bool Remove(T val)
        {
            Boolean isExist = false;
            for (int i = 0; i < _count; i++)
            {
                if (_arr[i].Equals(val))
                {
                    isExist = true;
                }
                if (isExist)
                {
                    _arr[i] = _arr[i + 1];
                }
            }
            if (isExist)
            {
                _count--;
            }
            return isExist;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < _count; i++)
            {
                _arr[i] = _arr[i + 1];
            }
            _count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            ++_currentPos;
            return _currentPos < _count;
        }

        public void Reset()
        {
            _currentPos = -1;
        }

        public void Dispose()
        {
            Reset();
        }
    }
}
