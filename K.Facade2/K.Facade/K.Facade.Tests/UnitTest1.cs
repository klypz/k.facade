using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace K.Facade.Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			Factory.Domain.LoadMapping(); 
		}
	}
}
