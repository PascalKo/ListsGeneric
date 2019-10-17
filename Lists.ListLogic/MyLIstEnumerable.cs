using System;
using System.Collections;
using System.Collections.Generic;


namespace Lists.ListLogic
{
    class MyLIstEnumerable<T> : IEnumerator<T>
    {
        private Node<T> _data;
        private Node<T> _pos = null;
        public MyLIstEnumerable(Node<T> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
            _data = data;
        }

        public T Current
        {
            get
            {
                if (_pos == null)
                {
                    throw new InvalidOperationException();
                }
                else
                {
                    return _pos.DataObject;
                }

            }
        }

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            bool isValid = true;
            if (_pos == null)
            {
                _pos = _data;

            }
            else if (_pos.Next != null)
            {
                _pos = _pos.Next;
            }
            else
            {
                isValid = false;
            }

            return isValid;

        }

        public void Reset()
        {
            _pos =null;
        }
    }
}
