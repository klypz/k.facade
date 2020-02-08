using NSubstitute;
using K.Facade.Tests.NewFacade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using K.Facade.Domain;

namespace K.Facade.Tests
{
	[TestClass]
	public class UnitTest2
	{
		IUseRepo useRepo2;
		public UnitTest2()
		{
			useRepo2 = Substitute.For<IUseRepo>();
			useRepo2.Name.Returns("2");
		}

		[TestMethod]
		public void MyTestMethod()
		{
			DomainFactory.Mapper.LoadMapping();

		}

		[TestMethod]
		public void TestMethod1()
		{
			DomainFactory.Mapper.Map(a => a.Add<IUseRepo, UseRepo>().Add(useRepo2, "repo"));

			var usrDefault = DomainFactory.GetInstance<IUseRepo>();
			var usrSubst = DomainFactory.GetInstance<IUseRepo>("repo");
		}
	}
}
