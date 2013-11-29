using System;
using System.Collections.Generic;
using System.Linq;
using LinqExercise;
using NUnit.Framework;

namespace LinqExerciseTest
{
    internal class PeopleTest
    {
        private List<Person> people;
        private readonly Person person1 = new Person {Name = "XiaoMing", Age = 20};
        private readonly Person person2 = new Person {Name = "Lily", Age = 23};

        [SetUp]
        public void Init()
        {
            people = new List<Person> {person1, person2};
        }

        #region find, first, firstOrDefault, elementAt. Find one element methods test
       
        [Test]
        public void Should_get_first_person_with_name_length_larger_than_5_with_Find()
        {
            var findedPeople = people.Find(p => p.Name.Length > 5);

            Assert.That(findedPeople, Is.EqualTo(person1));
        }

        [Test]
        public void should_throw_exception_when_there_is_no_matched_element_in_objects_with_First()
        {
            Assert.Throws<InvalidOperationException>(MethodThatThrows);
        }

        private void MethodThatThrows()
        {
            new List<Person>().First(p => p.Age > 20);
        }

        [Test]
        public void Should_get_first_person_with_age_larger_than_20_with_FirstOrDefault()
        {
            var firstPersonOlderThan20 = people.FirstOrDefault(p => p.Age > 20);
            Assert.That(firstPersonOlderThan20, Is.EqualTo(person2));
        }

        [Test]
        public void Should_return_null_when_there_is_no_matched_element_in_objects_with_FirstOrDefault()
        {
            var firstPersonOlderThan20 = new List<Person>().FirstOrDefault(p => p.Age > 20);
            Assert.Null(firstPersonOlderThan20);
        }

        [Test]
        public void should_return_null_when_there_is_no_matched_element_in_string_list_with_FirstOrDefault()
        {
            var sourceStringList = new List<string>();
            var result = sourceStringList.FirstOrDefault(s => s.Length > 0);
            Assert.Null(result);
        }

        [Test]
        public void should_return_empty_char_when_there_is_no_matched_element_in_char_list_with_FirstOrDefault()
        {
            var sourceStringList = new List<char>();
            var result = sourceStringList.FirstOrDefault(x => x == '1');
            Console.WriteLine("default char: " + result);
            Assert.That(result, Is.EqualTo('\0'));
        }

        [Test]
        public void should_return_0_when_there_is_no_matched_element_in_int_list_with_FirstOrDefault()
        {
            var sourceIntList = new List<int>();
            var result = sourceIntList.FirstOrDefault(s => s > 10);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void should_get_special_element_with_index_by_elementAt()
        {
            var nums = new List<string> {"zero", "one", "two", "three", "four"};
            var secondNumber = nums.ElementAt(1);

            Assert.That(secondNumber, Is.EqualTo("one"));
        }

        #endregion

        #region count
        [Test]
        public void Should_get_people_list_with_age_larger_than_20_with_Count()
        {
            var findedPersonNum = people.Count(p => p.Age > 20);
            Assert.That(findedPersonNum, Is.EqualTo(1));
        }

        #endregion

        #region where, takeWhile
        [Test]
        public void Should_find_person_list_older_than_20_with_Where()
        {
            var findedPeople = people.Where(p => p.Age > 20).ToList();
            var expectedPeople = new List<Person> {person2};
            Assert.That(findedPeople, Is.EqualTo(expectedPeople));
        }

        [Test]
        public void should_return_all_members_that_satisfy_rules_with_takeWhile()
        {
            var digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var digitsLongerThanThreeWithTakeWhile = digits.TakeWhile(d => d.Length > 3);
            var digitsLongerThanFourWithWhere = digits.Where(d => d.Length > 3);

            Print<string>.PrintSequence(digitsLongerThanThreeWithTakeWhile);
            Console.WriteLine("\n");
            Print<string>.PrintSequence(digitsLongerThanFourWithWhere);
        }

        #endregion

        #region select

        [Test]
        public void should_get_age_list_of_people_with_select()
        {
            var people = new List<Person> { new Person { Age = 10 }, new Person { Age = 20 } };
            var expectedAgeOfPeople = new List<int> { 10, 20 };

            var ageOfPeople = people.Select(p => p.Age).ToList();

            Assert.That(ageOfPeople, Is.EqualTo(expectedAgeOfPeople));
        }

        [Test]
        public void should_be_able_to_modify_age_of_people_with_select()
        {
            var modifiedAgeOfPeople = people.Select(p => p.Age * 2).ToList();
            var expectedMultipleAgeOfPeople = new List<int> { 20, 40 };

            Assert.That(modifiedAgeOfPeople, Is.EqualTo(expectedMultipleAgeOfPeople));
            foreach (var i in people)
            {
                Console.WriteLine(i.Age);
            }
        }

        [Test]
        public void Should_get_upper_case_name_list_with_select()
        {
            var people = new List<Person> {new Person {Name = "Xiaofeng"}, new Person {Name = "XiaoHong"}};
            var upperCaseName = people.Select(n =>n.Name.ToUpper()).ToList();
            Assert.That(upperCaseName.First(), Is.EqualTo("XIAOFENG"));
        }

        [Test]
        public void Should_get_people_with_upper_case_name_using_select()
        {
            var people = new List<Person> {new Person {Name = "xiaoxiao"}, new Person {Name = "dada"}};

            people.Select(p => UpperCaseName(p)).ToList();
            foreach (Person person in people)
            {
                UpperCaseName(person);
            }

            Assert.That(people[0].Name, Is.EqualTo("XIAOXIAO"));
        }

        private Person UpperCaseName(Person person)
        {
            person.Name = person.Name.ToUpper();
            return person;
        }

        #endregion

        #region index, anonymous type, select many
        [Test] //index
        public void should_return_list_with_two_parameters_using_where_or_select()
        {
            string[] nums = { "zero", "one", "two", "three", "four" };
            var resultNums = nums.Where((num, index) => num.Length > index);
            var result = nums.Select((num, index) => num.Length > index);

            Console.WriteLine(resultNums.First());
            Console.WriteLine(result.First());
        }

        [Test] //anonymous Type
        public void Should_get_upper_case_and_lower_case_pair_of_people_with_select()
        {
            var people = new List<Person> {new Person {Name = "xiaoxiao"}, new Person {Name = "dada"}};

            var nameCouple = people.Select(p => new {Upper = p.Name.ToUpper(), Lower = p.Name.ToLower()});

            Assert.That(nameCouple.First(), Is.EqualTo(new {Upper = "XIAOXIAO", Lower = "xiaoxiao"}));
        }

        [Test] //anonymous Type
        public void should_get_some_properties_of_type_and_get_a_new_type_with_select()
        {
            var people = new List<Person>
                {
                    new Person {Name = "xiaohong", Age = 20},
                    new Person {Name = "xiaolan", Age = 21}
                };

            var peopleInfos = people.Select(p => new {p.Name, MyAge = p.Age});

            Assert.That(peopleInfos.First(), Is.EqualTo(new {Name = "xiaohong", MyAge = 20}));
        }

        [Test] //select many
        public void should_return_the_second_level_members_with_selectMany()
        {
            var people = new List<Person>
                {
                    new Person {Pets = new List<string> {"puppy", "kitty"}},
                    new Person {Pets = new List<string> {"pig", "chicken"}}
                };

            var query = people.Select(p => p.Pets);

            foreach (List<string> pets in query)
            {
                foreach (string pet in pets)
                {
                    Console.WriteLine(pet);
                }
            }

            var query1 = people.SelectMany(p => p.Pets);

            foreach (var pet in query1)
            {
                Console.WriteLine(pet);
            }
        }

        #endregion

        #region not to talk about

        [Test]
        public void should_be_able_to_deal_with_two_array_with_linq()
        {
            int[] numbers = {0, 1, 2, 3, 4, 5, 6, 7, 8};
            int[] numbers1 = {1, 1, 1, 1, 1, 1, 1, 1, 1};
            string[] digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

            var selectedDigits = numbers.SelectMany(n => numbers1.Select(n1 => n1), (n, n1) => digits[n + n1]);

            Assert.That(selectedDigits.ToArray()[9], Is.EqualTo("two"));
            Assert.That(selectedDigits.Count(), Is.EqualTo(81));

            var selectedDigitsBySqlLinq = from num in numbers
                                          from num1 in numbers1
                                          select digits[num + num1];

            Assert.That(selectedDigitsBySqlLinq.ToArray()[9], Is.EqualTo("two"));
            Assert.That(selectedDigitsBySqlLinq.Count(), Is.EqualTo(81));
        }

        [Test]
        public void dealing_with_two_array_with_linq()
        {
            int[] numbers = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};
            string[] digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
                
            var selectedDigits = numbers.Where(n => n < 5).Select(d => digits[d]);
            Assert.That(selectedDigits.First(), Is.EqualTo("four"));
        }

        [Test]
        public void should_be_able_to_deal_with_multiple_array_with_linq()
        {
            int[] numbers = { 0, 0, 0, 0, 0, 0, 0, 0, 0};
            int[] numbers1 = {1, 1, 1, 1, 1, 1, 1, 1, 1};
            int[] numbers2 = {2, 2, 2, 2, 2, 2, 2, 2, 2};
            string[] digits = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

//            var selectedDigits = 
//                numbers.SelectMany(n => numbers1.SelectMany(n1 => numbers2.Where(n2 => n2 > n1)), (n, n1, n2) => digits[n + n1 + n2]);
//            Assert.That(selectedDigits.ToArray()[9], Is.EqualTo("two"));
//            Assert.That(selectedDigits.Count(), Is.EqualTo(81));

            var selectedDigitsBySqlLinq = from num in numbers
                                          from num1 in numbers1
                                          from num2 in numbers2
                                          select digits[num + num1 + num2];

            Assert.That(selectedDigitsBySqlLinq.ToArray()[9], Is.EqualTo("three"));
            Assert.That(selectedDigitsBySqlLinq.Count(), Is.EqualTo(9* 9 *9));
        }
        #endregion

       
    }
}