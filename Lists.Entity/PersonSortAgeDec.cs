using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lists.Entity
{
    public class PersonSortAgeDec : IComparer
    {
        public int Compare(object x, object y)
        {
            var left = x as Person;
            var right = y as Person;
            int result = 0;
            if (left == null)
            {
                throw new ArgumentException("Illigaler Typ!");
            }
            if (right == null)
            {
                throw new ArgumentException("Illigaler Typ!");
            }
            if (left.Age > right.Age)
            {
                result = -1;
            }
            else if (left.Age < right.Age)
            {
                result = 1;
            }
            return result;
        }
    }
}
