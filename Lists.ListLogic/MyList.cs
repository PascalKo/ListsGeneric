using System;
using System.Collections;
using System.Collections.Generic;

namespace Lists.ListLogic
{
    /// <summary>
    /// Die Liste verwaltet beliebige Elemente und implementiert
    /// das IList-Interface und damit auch ICollection und IEnumerable
    /// </summary>
    public class MyList<T> : IList<T>
    {
        public MyList()
        {
        }

        Node<T> Head { get; set; }



        #region IList Members

        /// <summary>
        /// Ein neues Objekt wird in die Liste am Ende
        /// eingefügt. Etwaige Typinkompatiblitäten beim Vergleich werden
        /// nicht behandelt und lösen eine Exception aus.
        /// </summary>
        /// <param name="value">Einzufügender Datensatz</param>
        /// <returns>Index des Werts in der Liste</returns>
        public int Add(T value)
        {
            if (Head == null)
            {
                Head = new Node<T>(value);
            }
            else
            {
                Node<T> tmp = Head;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Next = new Node<T>(value);
            }
            return Count - 1;
        }

        /// <summary>
        /// Die Liste wird geleert. Die Elemente werden einfach ausgekettet.
        /// Der GC räumt dann schon auf.
        /// </summary>
        public void Clear()
        {
            Head = null;
        }

        /// <summary>
        /// Gibt es den gesuchten DataObject zumindest ein mal?
        /// </summary>
        /// <param name="value">gesuchter DataObject</param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return IndexOf(value) != -1;
        }

        /// <summary>
        /// Der DataObject wird gesucht und dessen Index wird zurückgegeben.
        /// </summary>
        /// <param name="value">gesuchter DataObject</param>
        /// <returns>Index oder -1, falls der DataObject nicht in der Liste ist</returns>
        public int IndexOf(T value)
        {
            Node<T> tmp = Head;


            for (int i = 0; i < Count; i++)
            {
                if (tmp.DataObject.Equals(value))
                {
                    return i;
                }
                tmp = tmp.Next;
            }
            return -1;

        }

        /// <summary>
        /// DataObject an bestimmter Position in Liste einfügen.
        /// Es ist auch erlaubt, einen DataObject hinter dem letzten Element
        /// (index == count) einzufügen.
        /// </summary>
        /// <param name="index">Einfügeposition</param>
        /// <param name="value">Einzufügender DataObject</param>
        public void Insert(int index, T value)
        {

            Node<T> newNode = new Node<T>(value);

            if (Head == null || (index == Count && index != 0))
            {
                Add(value);
            }
            else if (index == 0)
            {

                newNode.Next = Head;
                Head = newNode;
            }
            else if (index < Count && index > 0)
            {
                Node<T> tmp = Head;
                for (int i = 1; i < index; i++)
                {
                    tmp = tmp.Next;
                }

                newNode.Next = tmp.Next;
                tmp.Next = newNode;
            }
        }

        /// <summary>
        /// Wird nicht verwendet ==> Immer false
        /// </summary>
        public bool IsFixedSize
        {
            get { return false; }
        }

        /// <summary>
        /// Wird nicht verwendet ==> Immer false
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Ein DataObject wird aus der Liste entfernt, wenn es ihn 
        /// zumindest ein mal gibt.
        /// </summary>
        /// <param name="value">zu entfernender DataObject</param>
        public void Remove(T value)
        {
            if (Contains(value))
            {
                RemoveAt(IndexOf(value));
            }
        }

        /// <summary>
        /// Der DataObject an der Position Index wird entfernt.
        /// Gibt es die Position nicht, geschieht nichts.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            Node<T> tmp = Head;
            if (index < Count)
            {

                if (index == 0)
                {
                    Head = Head.Next;
                }
                else
                {
                    for (int i = 1; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }

                    tmp.Next = tmp.Next.Next;

                }
            }

        }

        /// <summary>
        /// Indexer zum Einfügen und Lesen von Werten an
        /// gesuchten Positionen.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return Head.DataObject;
                }
                else
                {
                    Node<T> tmp = Head;
                    for (int i = 0; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }
                    return tmp.DataObject;
                }
            }
            set
            {

                this.Insert(index, value);


            }
        }

        #endregion

        #region ICollection Members

        /// <summary>
        /// Werte in ein bereits angelegtes Array kopieren.
        /// Ist das übergebene Array zu klein, oder stimmt der
        /// Startindex nicht, geschieht nichts.
        /// </summary>
        /// <param name="array">Zielarray, existiert bereits</param>
        /// <param name="index">Startindex</param>
        public void CopyTo(Array array, int index)
        {

            Node<T> tmp = Head;
            if (array.Length < (Count - index))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array.SetValue(null, i);
                }
            }
            else
            {
                if (index != 0)
                {
                    for (int i = 0; i < index; i++)
                    {
                        tmp = tmp.Next;
                    }

                }


                for (index = 0; index < array.Length; index++)
                {
                    if (tmp == null)
                    {
                        array.SetValue(null, index);

                    }
                    else
                    {
                        array.SetValue(tmp.DataObject, index);
                        tmp = tmp.Next;
                    }
                }
            }
        }

        /// <summary>
        /// Die Anzahl von Elementen in der Liste wird immer 
        /// explizit gezählt und ist nicht redundant gespeichert.
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;
                if (Head != null)
                {
                    Node<T> tmp = Head;
                    count++;
                    while (tmp.Next != null)
                    {
                        tmp = tmp.Next;
                        count++;
                    }
                }
                return count;
            }
        }

        /// <summary>
        /// Multithreading wird nicht verwendet
        /// </summary>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Multithreading wird nicht verwendet
        /// </summary>
        public object SyncRoot
        {
            get { return null; }
        }

        #endregion

        public IEnumerator GetEnumerator()
        {

            return new MyLIstEnumerable<T>(Head);
        }

        void ICollection<T>.Add(T item)
        {
            this.Add(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.CopyTo(array, arrayIndex);
        }

        bool ICollection<T>.Remove(T item)
        {
            this.Remove(item);
            return Contains(item);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
           return new MyLIstEnumerable<T>(Head);
        }
    }
}
