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
			Assert.AreEqual('K', FirstNonRepeatingLetter("Kaalluupptt"));
		}
	}
	public class Task_3
	{
		public int digital_root(int input)
		{
			if (input < 10)
			{
				return input;
			}
			char[] strInput = input.ToString().ToCharArray();
			int sum = 0;
			for (int i = 0; i < strInput.Length; i++)
			{
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
	[TestFixture]
	public class Task_4
	{
		public int getPairs(List<int> inputList, int target)
		{
			int num = 0;
			for (int i = 0; i < inputList.Count; i++)
			{
				for (int j = i + 1; j < inputList.Count; j++)
				{
					if (inputList[i] + inputList[j] == target)
					{
						num++;
					}
				}
			}
			return num;
		}
		[Test]
		public void getPairs1()
		{
			Assert.AreEqual(4, getPairs(new List<int>() { 1, 3, 6, 2, 2, 0, 4, 5 }, 5));
		}
		[Test]
		public void getPairs2()
		{
			Assert.AreEqual(0, getPairs(new List<int>() { 1, 3, 0 }, 5));
		}
		[Test]
		public void getPairs3()
		{
			Assert.AreEqual(0, getPairs(new List<int>() { 3 }, 6));
		}
	}
	[TestFixture]
	public class Task_5
	{
		public string UpperAndSort(string guests)
		{
			try
			{
				string[] str = guests.Split(';');
				string[,] newStr = new string[str.Length, 2];
				for (int i = 0; i < str.Length; i++)
				{
					newStr[i, 0] = str[i].Split(':')[1];
					newStr[i, 1] = str[i].Split(':')[0];
					str[i] = newStr[i, 0] + ", " + newStr[i, 1];
				}
				Array.Sort<string>(str, new Comparison<string>((i1, i2) => i1.CompareTo(i2)));
				string result = ("(" + string.Join(")(", str) + ")").ToUpper();
				return result;
			}
			catch (IndexOutOfRangeException)
			{
				return "";
			}
		}
		[Test]
		public void UpperAndSortTest1()
		{
			String s = "Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
			String expected = "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)";
			Assert.AreEqual(expected, UpperAndSort(s));
		}
		[Test]
		public void UpperAndSortTest2()
		{
			String s = "               ";
			String expected = "";
			Assert.AreEqual(expected, UpperAndSort(s));
		}
	}
	[TestFixture]
	public class Task_Extra
	{
		public int nextBigger(int input)
		{
			char[] inputStr = input.ToString().ToCharArray();
			for (int i = inputStr.Length - 1; i > 0; i--)
			{
				if ((int)inputStr[i] > (int)inputStr[i - 1])
				{
					char tempswap = inputStr[i];
					inputStr[i] = inputStr[i - 1];
					inputStr[i - 1] = tempswap;
					break;
				}
			}
			int result = Int32.Parse(string.Join("", inputStr));
			return result != input ? result : -1;
		}
		[Test]
		public void nextBiggerTest1()
		{
			Assert.AreEqual(2071, nextBigger(2017));
		}
		[Test]
		public void nextBiggerTest2()
		{
			Assert.AreEqual(2202, nextBigger(2022));
		}
		[Test]
		public void nextBiggerTest3()
		{
			Assert.AreEqual(-1, nextBigger(9731));
		}
	}
	public class Extra_Task_2
	{

		public string IP_address(long k)
		{
			long fourth = k % 256;
			long third = (k - fourth) / 256 % 256;
			long second = (k - fourth - third) / (256 * 256) % 256;
			long first = (k - fourth - third - second) / (256 * 256 * 256) % 256;
			string[] str = { first.ToString(), 
							second.ToString(), 
							third.ToString(), 
							fourth.ToString() };


			return string.Join('.', str);
		}
		[Test]
		public void Test_IP1()
		{
			Assert.AreEqual("128.32.10.1", IP_address(2149583361));
		}

		[Test]
		public void Test_IP2()
		{
			Assert.AreEqual("0.0.0.32", IP_address(32));
		}
		[Test]
		public void Test_IP3()
		{
			Assert.AreEqual("0.0.0.0", IP_address(0));
		}
	}
}
