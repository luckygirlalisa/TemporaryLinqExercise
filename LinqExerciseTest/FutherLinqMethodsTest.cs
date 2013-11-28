using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace LinqExerciseTest
{
    [TestFixture]
    public class FutherLinqMethodsTest
    {
        private List<string> digits;

        [Test]
        public void should_return_special_member_with_take_and_skip()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var specialThreeDigits = digits.Skip(2).Take(3);

            Assert.That(specialThreeDigits.First(), Is.EqualTo("two"));
            Assert.That(specialThreeDigits.Count(), Is.EqualTo(3));

            foreach (var specialThreeDigit in specialThreeDigits)
            {
                Console.WriteLine(specialThreeDigit);
            }
        }

        [Test]
        public void should_return_all_members_that_satisfy_rules_with_takeWhile()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var digitsLongerThanThreeWithTakeWhile = digits.TakeWhile(d => d.Length > 3);
            var digitsLongerThanFourWithWhere = digits.Where(d => d.Length > 3);   

            Print<string>.PrintSequence(digitsLongerThanThreeWithTakeWhile);
            Console.WriteLine("\n");
            Print<string>.PrintSequence(digitsLongerThanFourWithWhere);
        }

        [Test]
        public void should_order_sequence_by_orderby()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var orderedDigitsByLetter = digits.OrderBy(d => d);
            var orderedDigitsByLength = digits.OrderBy(d => d.Length);

            Assert.That(orderedDigitsByLetter.First(), Is.EqualTo("eight"));
            Assert.That(orderedDigitsByLength.First(), Is.EqualTo("one"));

            foreach (var orderedDigits in orderedDigitsByLetter)
            {
                Console.WriteLine(orderedDigits);
            }

            foreach (var orderedDigits in orderedDigitsByLength)
            {
                Console.WriteLine(orderedDigits);
            }
        }

        [Test]
        public void should_order_by_letter_do_not_ignore_case()
        {
            string[] words = {"aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry"};

            var sortedWords = words.OrderBy(a => a, new CaseInsensitiveComparer());
            foreach (var digit in sortedWords)
            {
                Console.WriteLine(digit);
            }
        }

        [Test]
        public void should_order_by_orderByDescending()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var orderedByDecending = digits.OrderByDescending(d => d.Length);

            foreach (var digit in orderedByDecending)
            {
                Console.WriteLine(digit);
            }
        }

        [Test]
        public void should_order_firstly_by_length_and_secondly_alphabetically()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var orderedDigit = digits.OrderBy(d => d.Length).ThenBy(d => d);

            var orderedDigit1 = from d in digits
                                orderby d.Length, d
                                select d;

            foreach (var digit in orderedDigit)
            {
                Console.WriteLine(digit);
            }
        }

        [Test]
        public void should_order_firstly_by_length_and_secondly_alphabetically_descendingly()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var orderedDigit = digits.OrderByDescending(d => d.Length).ThenByDescending(d => d);

            var orderedDigit1 = from d in digits
                                orderby d.Length descending , d descending 
                                select d;

            foreach (var digit in orderedDigit)
            {
                Console.WriteLine(digit);
            }
        }

        [Test]
        public void should_reverse_members_of_list_with_reverse()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var reversedList = digits.ToArray().Reverse();
            digits.Reverse();

            Print<string>.PrintSequence(reversedList);
            Console.WriteLine("\n");
            Print<string>.PrintSequence(digits);
        }

        [Test]
        public void should_group_list_with_group_by()
        {
            string[] words = {"chimpanzee", "abacus", "banana", "apple", "cheese" };

            var wordGroups =
                from w in words
                group w by w[0] into g
                select new { FirstLetter = g.Key, Words = g };

            var wordGroupsWithLinq = words.GroupBy(w => w[0])
                                    .Select( w => new { FirstLetter = w.Key, Words = w, Count = w.Count()});

            foreach (var g in wordGroupsWithLinq)
            {
                Console.WriteLine("Words start with '{0}':", g.FirstLetter);
                Console.WriteLine("The count of Words start with '{0}' is {1}", g.FirstLetter, g.Count);
                foreach (var w in g.Words)
                {
                    Console.WriteLine(w);
                }
            }
        }

        [Test]
        public void should_group_members_with_typeOf()
        {
            object[] numbers = { null, 1.12, "two", 3, "four", 5, 's', 7.0 };

            var doubles = numbers.OfType<double>();

            Console.WriteLine("Numbers stored as doubles:");
            
            Print<double>.PrintSequence(doubles);
        }

        [Test]
        public void should_remove_duplicate_members_with_distinct()
        {
            int[] numbers = {1, 3, 2, 3, 2, 4, 1};
            var distinctNumbers = numbers.Distinct();

            Print<int>.PrintSequence(distinctNumbers);
        }

        [Test]
        public void should_unite_two_list_with_distinct_members_by_union()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] num = { "1", "2", "3", "zero", "one", "two"};
            var unitedNum = digits.Union(num);
            
            Print<string>.PrintSequence(unitedNum);
        }

        [Test]
        public void should_get_the_common_members_in_two_array_with_intersect()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] num = { "1", "2", "3", "zero", "one", "two" };
            var commonMembers = digits.Intersect(num);

            Print<string>.PrintSequence(commonMembers);
        }

        [Test]
        public void should_get_members_in_one_sequence_but_not_in_another_with_except()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] num = { "1", "2", "3", "zero", "one", "two" };
            var specialMembers = digits.Except(num);

            Print<string>.PrintSequence(specialMembers);
        }

        [Test]
        public void should_get_members_in_two_sequences_with_duplicates_by_concat()
        {
            string[] num = { "1", "2", "3", "zero", "one", "two" };
            var allMembers = digits.Concat(num);

            Print<string>.PrintSequence(allMembers);
        }


        [Test]
        public void should_be_able_to_convert_Inumerable_to_array_and_list()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var selectedDigits = digits.Where(x => x.Length > 2);

            var selectedArray = selectedDigits.ToArray();
            Assert.IsInstanceOf<string []>(selectedArray);
           
            var selectedList = selectedDigits.ToList();
            Assert.IsInstanceOf<List<string>>(selectedList);
        }

        [Test]
        public void should_be_able_to_convert_Inumerable_to_dictionary()
        {
            var people = new []
                {
                    new  {Age = 18, Name = "Kimi"},
                    new  {Age = 20, Name = "Sendy"},
                    new  {Age = 18, Name = "Shiling"}
                };
            var selectedPeople = people.ToDictionary(p => p.Name);
            
            Console.WriteLine(selectedPeople["Kimi"]);
        }

        [Test]
        public void should_generate_sequence_with_range()
        {
            var rangedSequence = Enumerable.Range(10, 10);

            Print<int>.PrintSequence(rangedSequence);
        }

        [Test]
        public void should_generate_sequence_with_repeat()
        {
            var repeatedSequence = Enumerable.Repeat("ten", 10);

            Print<string>.PrintSequence(repeatedSequence);
        }

        [Test]
        public void should_return_if_any_of_the_members_in_the_sequence_match_rule_with_any()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            bool selectedDigits = digits.Any(d => d.Contains("i"));

            Console.WriteLine("There is one digit contains 'i': {0}", selectedDigits);
        }

        [Test]
        public void should_return_if_all_the_members_in_the_sequence_match_rule_with_all()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            bool onlyOdd = digits.All(d => d.Length % 2 == 1);

            Console.WriteLine("The length of all the digits are odd numbers: {0}", onlyOdd); 
        }

        [Test]
        public void should_return_bool_to_judge_if_one_sequence_equal_another_with_SequenceEqual()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var nums = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var isDigitsTotallyEqualToNums = digits.SequenceEqual(nums);
            Assert.True(isDigitsTotallyEqualToNums);
        }

        [Test]
        public void should_return_the_min_and_max_length_of_digits_with_min_and_max()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var minLengthDigits = digits.Min(d => d.Length);
            var maxLengthDigits = digits.Max(d => d.Length);
            var averageLengthDigits = digits.Average(d => d.Length);

            Assert.That(minLengthDigits, Is.EqualTo(3));
            Assert.That(maxLengthDigits, Is.EqualTo(5));
            Assert.That(averageLengthDigits, Is.EqualTo(4.0));
        }

        [Test]
        public void should_get_the_sum_of_int_list_with_Sum()
        {
            var numbers = Enumerable.Range(1, 100);
            var sum = numbers.Sum();

            Assert.That(sum, Is.EqualTo(5050));
        }

        [Test]
        public void should_get_multiple_value_with_aggregate()
        {
            string[] elements = {"I", "am", "a", "developer"};
            string sentence = elements.Aggregate((runningElement, next) => runningElement + " " + next);

            Console.WriteLine(sentence);
        }

        [Test]
        public void should_prove_the_query_excution_be_defered()
        {
            int[] nums = {1, 3, 2, 4};
            
            int i = 0;
            var query = nums.Select( n => ++ i);
            foreach (var q in query)
            {
                Console.WriteLine("q = {0}, i = {1}", q, i);
            }

            Console.WriteLine("\n");

            int j = 0;
            var query1 = nums.Select(n => ++j).ToList();
            foreach (var q1 in query1)
            {
                Console.WriteLine("q= {0}, i = {1}", q1, j);
            }
        }

        [Test]
        public void should_be_able_to_reuse_query_because_of_the_referred_excution()
        {
            int[] nums = {1, 2, 3, 4};

            var query = nums.Where(n => n < 3);

            foreach (var q in query)
            {
                Console.WriteLine(q);
            }
            Console.WriteLine("\n");

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = -nums[i];
            }

            foreach (var q in query)
            {
                Console.WriteLine(q);
            }
        }

        [Test]
        public void should_join_two_sequence_with_join()
        {
            digits = new List<string> { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] num = { "1", "2", "3", "zero", "one", "two" };
            
            var joinedNum = digits.Join(num, d => d, n => n, (d, n) => d);

            var joinedNum1 = from d in digits
                             join n in num
                             on d equals n 
                             select d;

            Print<string>.PrintSequence(joinedNum);
            Print<string>.PrintSequence(joinedNum1);
        }

//        private static void PrintSequence(IEnumerable<string> allMembers)
//        {
//            foreach (var allMember in allMembers)
//            {
//                Console.WriteLine(allMember);
//            }
//        }
    }

    public class Print<T>
    {
        public static void PrintSequence(IEnumerable<T> sequence)
        {
            foreach (var member in sequence)
            {
                Console.WriteLine(member);
            }
        }
    }

    public class CaseInsensitiveComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.Ordinal);
        }
    }
}
