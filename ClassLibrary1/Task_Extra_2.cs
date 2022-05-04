using NUnit.Framework;

namespace ClassLibrary1
{
	[TestFixture]
	public class Task_Extra_2
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
		public void IP_address_Test_1()
		{
			Assert.AreEqual("128.32.10.1", IP_address(2149583361));
		}

		[Test]
		public void IP_address_Test_2()
		{
			Assert.AreEqual("0.0.0.32", IP_address(32));
		}
		[Test]
		public void IP_address_Test_3()
		{
			Assert.AreEqual("0.0.0.0", IP_address(0));
		}
	}
}
