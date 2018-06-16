using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    public class MyOneLinkedList<T> : IList<T>, IEnumerator<T>
    {
        #region inner classes
        private class ListItem
        {
            public T _value;
            public ListItem _next;

            public ListItem(T value, ListItem next = null)
            {
                _value = value;
                _next = next;
            }
        }
        #endregion
        #region fields
        private ListItem _head = null;
        private ListItem _tail = null;
        private int _counter = 0;
        private ListItem _currentItem = null;
        #endregion
        #region ctors

        /// <summary>
        /// Default constructor
        /// </summary>
        public MyOneLinkedList()
        {
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array">for initialization initial data</param>
        public MyOneLinkedList(IEnumerable<T> array)
        {
            using (IEnumerator<T> e = array.GetEnumerator())
            {
                while (e.MoveNext())
                {
                    Add(e.Current);
                }
            }
        }
        #endregion
        #region properties and indexer
        public T this[int index]
        {
            get => GetItem(index)._value;
            set => GetItem(index)._value = value;
        }

        public int Count { get => _counter; }

        public bool IsReadOnly { get => false; }

        #endregion
        #region utilites
        private ListItem GetItem(int index)
        {
            if (index < 0 || index >= _counter) throw new ArgumentOutOfRangeException();
            ListItem item = _head;
            while (index-- > 0)
            {
                item = item._next;
            }
            return item;
        }
        #endregion
        #region methods

        /// <summary>
        /// Add to Head
        /// </summary>
        /// <param name="val">Generic type, additional value</param>
        public void AddHead(T val)
        {
            if (_tail == null && _head == null)
            {
                _head = _tail = new ListItem(val);
                _counter = 1;
            }
            else
            {
                _head = new ListItem(val, _head);
                ++_counter;
            }
        }
        /// <summary>
        /// Add to Tail
        /// </summary>
        /// <param name="val">Generic type, additional value</param>
        public void Add(T val)
        {
            if (_tail == null && _head == null)
            {
                _head = _tail = new ListItem(val);
                _counter = 1;
            }
            else
            {
                _tail = _tail._next = new ListItem(val);
                ++_counter;
            }
        }

        public void Clear()
        {
            _counter = 0;
            _head = _tail = null;
        }
        public bool Contains(T val)
        {
            using (IEnumerator<T> e = GetEnumerator())
            {
                while (e.MoveNext())
                {
                    if (e.Current.Equals(val))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            using (IEnumerator<T> e = GetEnumerator())
            {
                while (e.MoveNext())
                {
                    array[arrayIndex++] = e.Current;
                }
            }
        }
        public int IndexOf(T val)
        {
            ListItem item = _head;
            for (int i = 0; item != null; ++i, item = item._next)
            {
                if (item._value.Equals(val))
                {
                    return i;
                }
            }
            return -1;
        }
        public void Insert(int index, T val)
        {
            if (index == 0)
            {
                AddHead(val);
                return;
            }
            if (index == _counter)
            {
                Add(val);
                return;
            }
            ListItem item = GetItem(index - 1);
            item._next = new ListItem(val, item._next);
            ++_counter;
        }
        public bool Remove(T val)
        {
            ListItem previous = null;
            ListItem current = _head;
            while (current != null)
            {
                if (current._value.Equals(val))
                {
                    if (previous != null)
                    {
                        previous._next = current._next;
                        if (current._next == null)
                        {
                            _tail = previous;
                        }
                    }
                    else
                    {
                        _head = _head._next;
                        if (_head == null)
                        {
                            _tail = null;
                        }
                    }
                    _counter--;
                    return true;
                }
                previous = current;
                current = current._next;
            }
            return false;
           
        }

        public void RemoveAt(int index)
        {
            if (index >= _counter || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (index == 0)
            {
                _head = _head._next;
                _counter--;
            }
            else
            {
                ListItem previous = null;
                ListItem item = _head;
                int _index = 0;

                while (_index != index)
                {
                    previous = item;
                    item = item._next;
                    _index++;
                }

                previous._next = item._next;
                item = null;
                _counter--;
            }
               
        }
        
        #endregion

        #region IEnumerator 

        public T Current { get => _currentItem._value; }
        object IEnumerator.Current { get => Current; }

        public void Dispose()
        {
            Reset();
        }
        public void Reset()
        {
            _currentItem = null;
        }
        public bool MoveNext()
        {
            if (_currentItem == null)
            {
                _currentItem = _head;
            }
            else
            {
                _currentItem = _currentItem._next;
            }
            return _currentItem != null;
        }
        #endregion
        #region IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion


    }
}
