using System;
using System.Data.Common;
using System.Data.SqlClient;
using K.Facade.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace K.Facade.Data.Test
{
	public interface IRepoTest : IRepository
	{
		void processes();
	}

	class RepoTest : IRepoTest
	{
		public DbConnection Connection { get; set; }

		public DbTransaction Transaction { get; set; }

		public void processes()
		{
			throw new NotImplementedException();
		}
	}
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			RepositoryConfiguration.GetConnection = delegate () { return new SqlConnection(); };
			FacadeFactory.Repository.Map.Map(a =>
			{
				a.Add<IRepoTest, RepoTest>();
			});

			FacadeFactory

			var t = FacadeFactory.Repository.GetInstance<IRepoTest>();
		}
	}
}
