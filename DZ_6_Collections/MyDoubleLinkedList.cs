using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCollection
{
    /// <summary>
    /// Demo class impliments LinkedList
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    public class MyLinkedList<T> : IList<T>, IEnumerator<T>
    {
        #region inner classes
        private class ListItem
        {
            public T _value;
            public ListItem _next;
            public ListItem _previous;

            public ListItem(T value, ListItem next = null, ListItem previous = null)
            {
                _value = value;
                _next = next;
                _previous = previous;
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
        public MyLinkedList()
        {
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="array">for initialization initial data</param>
        public MyLinkedList(IEnumerable<T> array)
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
                new ListItem(val)._next = _head;
                _head._previous = new ListItem(val);
                _head = new ListItem(val);
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
                _tail =_tail._next = new ListItem(val,null, _tail);
                ++_counter;
            }
        }
        /// <summary>
        /// Delete all elements from collection
        /// </summary>
        public void Clear()
        {
            _counter = 0;
            _head = _tail = null;
        }
        /// <summary>
        /// Определяет, входит ли элемент в коллекцию
        /// </summary>
        /// <param name="val">Generic type,  value</param>
        /// <returns></returns>
        public bool Contains(T val)
        {
           
            ListItem current = _head;
            while (current != null)
            {
                if (current._value.Equals(val))
                {
                    return true;
                }
              current = current._next;
            }
            return false;
        }
        /// <summary>
        /// Копирует все элементы текущего одномерного массива в заданный одномерный 
        /// массив начиная с указанного индекса в массиве назначения. 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex">Отсчитываемый от нуля индекс в массиве array,
        /// указывающий начало копирования.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {        
            ListItem current = _head;
            while (current != null)
            {
                array[arrayIndex++] = current._value;
                current = current._next;
            }
        }
        /// <summary>
        /// Возвращает индекс с отсчетом от нуля первого вхождения указанного символа 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Inserts an element into the List<T> at the specified index.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="val"></param>
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
            item._next = new ListItem(val);
            new ListItem(val)._previous = item;
            new ListItem(val)._next = GetItem(index);
            ++_counter;
        }
        /// <summary>
        /// Удаляет первое вхождение указанного объекта из коллекции List<T>.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool Remove(T val)
        {
            if (_head == null) return false;
            if (_head._value.Equals(val))
            {
                _head = _head._next;
                --_counter;
                return true;
            }
            ListItem item = _head;
            while (item._next != null)
            {
                if (val.Equals(item._value))
                {
                    break;
                }
                item = item._next;
            }
            if (item == null) return false;
            item._previous._next = item._next;
            item._next._previous = item._previous;
            --_counter;
            return true;
        }

        /// <summary>
        /// Удаляет элемент списка List<T> с указанным индексом.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (index >= _counter || index < 0)
                throw new ArgumentOutOfRangeException();

            ListItem item = GetItem(index);

            if (item != _head) item._previous._next = item._next;
            else _head = _head._next;
            if (item != _tail) item._next._previous = item._previous;
            else _tail = _tail._previous;

            --_counter;
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
