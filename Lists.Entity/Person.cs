using System;
using System.Collections;

namespace Lists.Entity
{
    public class Person : IComparable
    {
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public int Age { get; set; }

        public int CompareTo(object obj)
        {
            var person = obj as Person;
            if (person == null)
            {
                throw new ArgumentException("Illigaler Typ");
            }
            return LastName.CompareTo(person.LastName);
        }

        public static IComparer ComparePersonOnAgeAscanding()
        {
            return new PersonSortAgeDec();
        }

        public static IComparer ComparePersonOnFirstNameAscandig()
        {
            return new PersonSortFirstnameAce();
        }

        public override string ToString()
        {
            return $"{LastName} {FirstName}";
        }
    }
}
