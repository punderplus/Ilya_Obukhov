using NUnit.Framework;

namespace ClassLibrary1
{
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
		public void FirstNonRepeatingLetter_Test_1()
		{
			Assert.AreEqual('T', FirstNonRepeatingLetter("sTreSS"));
		}
		[Test]
		public void FirstNonRepeatingLetter_Test_2()
		{
			Assert.AreEqual(' ', FirstNonRepeatingLetter("sTreSSret"));
		}
		[Test]
		public void FirstNonRepeatingLetter_Test_3()
		{
			Assert.AreEqual('K', FirstNonRepeatingLetter("Kaalluupptt"));
		}
	}
}
