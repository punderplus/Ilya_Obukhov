using NUnit.Framework;
using System;

namespace ClassLibrary1
{
    [TestFixture]
    public class Workshop1
    {
        [Test]
        public void fizzBuzz()
        {
            String actual = checkDivision(15);
            Assert.AreEqual("Fizz Buzz", actual);
        }
        [Test]
        public void buzz()
        {
            String actual = checkDivision(6);
            Assert.AreEqual("Buzz", actual);
        }
        [Test]
        public void fizz()
        {
            String actual = checkDivision(10);
            Assert.AreEqual("Fizz", actual);
        }
        [Test]
        public void nonFizzBuzz()
        {
            String actual = checkDivision(7);
            Assert.AreEqual(null, actual);
        }
        public String checkDivision(int a)
        {
            if (a % 3 == 0 && a % 5 == 0)
            {
                return "Fizz Buzz";
            }
            if(a % 3 == 0)
            {
                return "Buzz";
            }
            if(a % 5 == 0)
            {
                return "Fizz";
            }
            return null;
        }

        [Test]
        
        public void checkDefault()
        {
            String actual = parseStr("#a#bc#d");
            Assert.AreEqual("bd", actual);
        }
        [Test]
        public void checkDoubleResh()
        {
            String actual = parseStr("#####a#bc#d");
            Assert.AreEqual("bd", actual);
        }

        [Test]
        public void checkDouble()
        {
            String actual = parseStr("a#bc#dftasd#p#r#t");
            Assert.AreEqual("bdftast", actual);
        }
        [Test]
        public void checkEmpty()
        {
            String actual = parseStr("");
            Assert.AreEqual("", actual);
        }
        public String parseStr(String input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[0] == '#')
                {
                    input = input.Remove(0, 1);
                    i--;
                    continue;
                }
                if (input[i] == '#')
                {
                    input = input.Remove(i - 1, 2);
                    i--;
                }
            }
            return input;
        }
    }
    [TestFixture]
    public class Workshop2
    {

        [Test]
        public void thursday()
        {
            DateTime day = new DateTime(2022, 5, 2);
            Assert.AreEqual("08.05.2022", sunday(day));
        }

        [Test]
        public void todayIsSunday()
        {
            DateTime day = new DateTime(2022, 4, 10);
            Assert.AreEqual("17.04.2022", sunday(day));
        }

        public string sunday(DateTime day)
        {
            day = day.AddDays(1);
            while (day.DayOfWeek != DayOfWeek.Sunday)
            {
                day = day.AddDays(1);
            }
            return day.ToString("dd.MM.yyyy");
        }
    }
}
