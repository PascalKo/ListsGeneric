using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lists.ListLogic
{
    class MyLIstEnumerable<T> : IEnumerator
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

        public object Current
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
