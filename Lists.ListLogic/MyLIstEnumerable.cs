using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lists.ListLogic
{
    class MyLIstEnumerable : IEnumerator
    {
        private Node _data;
        private Node _pos = null;
        public MyLIstEnumerable(Node data)
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
