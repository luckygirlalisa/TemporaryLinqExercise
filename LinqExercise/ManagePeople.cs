using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    public class ManagePeople
    {
        public Person FindPeopleWithNameLengthLargerThanFive(List<Person> people)
        {
            return people.Find(p => p.Name.Length > 5);
        }

        public int FindCountApplyRules(List<Person> people)
        {
            return people.Count(p => p.Age > 25);
        }

        public Person FindFirstPeopleOlderThan25(List<Person> people)
        {
            return people.FirstOrDefault(p => p.Age > 25);
        }

        public List<Person> FindPersonListOlderThan25(List<Person> people)
        {
            return people.Where(p => p.Age > 25).ToList();
        }
//
//        public List<Person> FindPersonListOlderThan25WithSelect(List<Person> people)
//        {
//            return people.Select(p => p.Age > 25).ToList();
//        }
    }
}
