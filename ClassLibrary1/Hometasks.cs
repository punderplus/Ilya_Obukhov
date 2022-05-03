using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
	[TestFixture]
	public class Task_1
	{
		public List<object> GetIntegersFromList(List<object> mixedList)
		{
			List<object> numbersOnly = new List<object>();
			for (int i = 0; i < mixedList.Count; i++)
			{
				if (mixedList[i].GetType() == typeof(int))
				{
					numbersOnly.Add(mixedList[i]);
				}
			}
			return numbersOnly;
		}
		[Test]
		public void GetIntegersFromListTest1()
		{
			List<object> expected = new List<object>() { 1, 2 };
			List<object> actual = GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b' });
			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void GetIntegersFromListTest2()
		{
			List<object> expected = new List<object>() { 1, 2, 0, 15 };
			List<object> actual = GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b', 0, 15 });
			Assert.AreEqual(expected, actual);
		}
		[Test]
		public void GetIntegersFromListTest3()
		{
			List<object> expected = new List<object>() { 1, 2, 231 };
			List<object> actual = GetIntegersFromList(new List<object>() { 1, 2, 'a', 'b', "aasf", '1', "123", 231 });
			Assert.AreEqual(expected, actual);
		}
	}
	[TestFixture]
	public class Task_2
	{
		public char FirstNonRepeatingLetter(string str)
		{
			string stringHelper = str;
			str = str.ToLower();
			for (int i = 0; i < str.Length - 1; i++)
			{
				if (!((str.Substring(0, i) + str.Substring(i + 1)).Contains(str[i])))
				{
					return stringHelper[i];
				}
			}
			return ' ';
		}
		[Test]
		public void FirstNonRepeatingLetter1()
		{
			Assert.AreEqual('T', FirstNonRepeatingLetter("sTreSS"));
		}
		[Test]
		public void FirstNonRepeatingLetter2()
		{
			Assert.AreEqual(' ', FirstNonRepeatingLetter("sTreSSret"));
		}
		[Test]
		public void FirstNonRepeatingLetter3()
		{
			Assert.AreEqual('Z', FirstNonRepeatingLetter("Zaalluuppaa"));
		}
	}
	public class Task_3
	{
		public int digital_root(int input)
		{
			if(input < 10)
            {
				return input;
			}
			char[] strInput = input.ToString().ToCharArray();
			int sum = 0;
			for(int i = 0; i < strInput.Length; i++)
            {
				Console.WriteLine(strInput[i]);
				sum += Int32.Parse((strInput[i].ToString()));
			}
			return digital_root(sum);
		}
		[Test]
		public void digital_root1()
		{
			Assert.AreEqual(7, digital_root(16));
		}
		[Test]
		public void digital_root2()
		{
			Assert.AreEqual(6, digital_root(942));
		}
		[Test]
		public void digital_root3()
		{
			Assert.AreEqual(6, digital_root(132189));
		}
		[Test]
		public void digital_root4()
		{
			Assert.AreEqual(2, digital_root(493193));
		}
		[Test]
		public void digital_root5()
		{
			Assert.AreEqual(0, digital_root(0));
		}
	}
}