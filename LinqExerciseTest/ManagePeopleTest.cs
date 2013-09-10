using System.Collections.Generic;
using LinqExercise;
using NUnit.Framework;

namespace LinqExerciseTest
{
    class ManagePeopleTest
    {
        private List<Person> people;
        private ManagePeople managePeople;
        private Person person1;
        private Person person2;

        [SetUp]
        public void Init()
        {
            person1 = new Person { Name = "Xiaohong", Age = 26 };
            person2 = new Person { Name = "Xiaohong", Age = 28 };

            people = new List<Person>
                {
                    new Person {Name = "Xiao", Age = 20 },
                    person1,
                    new Person {Name = "Lily", Age = 23 },
                    person2
                };
            managePeople = new ManagePeople();
        }

        [Test]
        public void Should_get_first_person_with_name_length_larger_than_5_with_Find()
        {
            var findedPeople = managePeople.FindPeopleWithNameLengthLargerThanFive(people);

            Assert.NotNull(findedPeople);
            Assert.That(findedPeople, Is.EqualTo(person1));
        }

        [Test]
        public void Should_get_first_person_with_age_larger_than_25_with_FirstOrDefault()
        {
            var firstPersonOlderThan25 = managePeople.FindFirstPeopleOlderThan25(people);
            Assert.That(firstPersonOlderThan25, Is.EqualTo(person1));
        }

        [Test]
        public void Should_get_people_list_with_age_larger_than_25_with_Count()
        {
            var findedPersonNum = managePeople.FindCountApplyRules(people);
            Assert.That(findedPersonNum, Is.EqualTo(2));
        }

        [Test]
        public void Should_find_person_list_older_than_25_with_Where()
        {
            var findedPeople = managePeople.FindPersonListOlderThan25(people);
            var expectedPeople = new List<Person> { person1, person2 };
            Assert.That(findedPeople, Is.EqualTo(expectedPeople));
        }

        [Test] 
        public void should_get_age_list_of_people_with_select()
        {
            var people = new List<Person> {new Person {Age = 10}, new Person {Age = 20}};
            var ageOfPeople = managePeople.GetTheAge(people);
            var expectedAgeOfPeople = new List<int> {10, 20};
            Assert.That(ageOfPeople, Is.EqualTo(expectedAgeOfPeople));

            var modifiedAgeOfPeople = managePeople.MultipleAgeOf(people);
            var expectedMultipleAgeOfPeople = new List<int> {20, 40};
            Assert.That(modifiedAgeOfPeople, Is.EqualTo(expectedMultipleAgeOfPeople));
        }

        [Test]
        public void Should_get_upper_case_and_lower_case_of_list_with_select()
        {
            var people = new List<Person> {new Person {Name = "Xiaofeng"}, new Person {Name = "XiaoHong"}};
            var nameOfPeople = managePeople.GetNameOf(people);
            var upperCaseName = managePeople.GetUpperCaseName(nameOfPeople);
            Assert.That(upperCaseName[0], Is.EqualTo("XIAOFENG"));
        }

    }
}
