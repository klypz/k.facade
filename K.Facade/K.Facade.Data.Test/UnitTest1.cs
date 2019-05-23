using System;
using System.Data.Common;
using System.Data.SqlClient;
using K.Facade.Data.Repository;
using K.Facade.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace K.Facade.Data.Test
{
	public interface IRepoTest : IRepository
	{
		void processes();
	}

	[SetRepository(typeof(IRepoTest))]
	class RepoTest : IRepoTest
	{
		public DbConnection Connection { get; set; }

		public DbTransaction Transaction { get; set; }

		public void processes()
		{
			throw new NotImplementedException();
		}
	}

	public interface IRepoTest2
	{
		void processes();
	}

	[SetFacade(typeof(IRepoTest2))]
	class RepoTest2 : IRepoTest2
	{
		public void processes()
		{
			throw new NotImplementedException();
		}
	}

	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void MyTestMethod()
		{
			RepositoryConfiguration.GetConnection = delegate () { return new SqlConnection(); };
			RepositoryFactory.Mapper.LoadMapping();
			DomainFactory.Mapper.LoadMapping();
			var t = RepositoryFactory.GetInstance<IRepoTest>();
			var t2 = DomainFactory.GetInstance<IRepoTest2>();
		}

		[TestMethod]
		public void TestMethod1()
		{
			RepositoryConfiguration.GetConnection = delegate () { return new SqlConnection(); };
			RepositoryFactory.Mapper.Map(a =>
			{
				a.Add<IRepoTest, RepoTest>();
			});

			var t = RepositoryFactory.GetInstance<IRepoTest>();
		}
	}
}
