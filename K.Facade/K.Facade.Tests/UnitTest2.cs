using NSubstitute;
using K.Facade.Tests.NewFacade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace K.Facade.Tests
{
	[TestClass]
	public class UnitTest2
	{
		IUseRepo useRepo2;
		public UnitTest2()
		{
			useRepo2 = Substitute.For<IUseRepo>();
		}

		[TestMethod]
		public void TestMethod1()
		{
			FacadeFactory.Domain.Map.Map(a =>
			{
				a.Add<IUseRepo, UseRepo>();
			});
			FacadeFactory.Domain.Map.Map(a =>
			{
				a.Add<IUseRepo>(useRepo2, "sub");
			});

			IUseRepo useRepo = FacadeFactory.Domain.GetInstance<IUseRepo>();
			IUseRepo _useRepo2 = FacadeFactory.Domain.GetInstance<IUseRepo>("sub");
		}
	}
}
