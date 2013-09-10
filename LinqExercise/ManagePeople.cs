using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    public class ManagePeople
    {
        //Find in list with Find/First/FirstOrDefault/Where
        public Person FindPeopleWithNameLengthLargerThanFive(List<Person> people)
        {
            return people.Find(p => p.Name.Length > 5);
        }

        public Person FindFirstPeopleOlderThan25(List<Person> people)
        {
            return people.FirstOrDefault(p => p.Age > 25);
        }

        public List<Person> FindPersonListOlderThan25(List<Person> people)
        {
            return people.Where(p => p.Age > 25).ToList();
        }

        public int FindCountApplyRules(List<Person> people)
        {
            return people.Count(p => p.Age > 25);
        }

        //modify elements in list and creat a new list with select
        public List<int> GetTheAge(List<Person> people)
        {
            return people.Select(p => p.Age).ToList();
        }

        public List<int> MultipleAgeOf(List<Person> people)
        {
            return people.Select(p => p.Age*2).ToList();
        }
    }
}

