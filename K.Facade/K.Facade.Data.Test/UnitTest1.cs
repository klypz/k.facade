using System;
using System.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace K.Facade.Data.Test
{
    public interface ITeste : IDisposable
    {

    }

    class DInhRepository : Repository
    {
        public DInhRepository(Repository repository) : base(repository)
        {
        }

        public DInhRepository(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public DInhRepository(DbTransaction dbTransaction) : base(dbTransaction)
        {
        }

        public DInhRepository(DbConnection dbConnection, bool isOwner) : base(dbConnection, isOwner)
        {
        }
    }

    [SetRepository(typeof(ITeste))]
    class Teste : DInhRepository, ITeste
    {
        public Teste(Repository repository) : base(repository)
        {
        }

        public Teste(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public Teste(DbTransaction dbTransaction) : base(dbTransaction)
        {
        }

        public Teste(DbConnection dbConnection, bool isOwner) : base(dbConnection, isOwner)
        {
        }
    }

    [SetRepository(typeof(ITeste), "renato")]
    public class TesteRenato : Repository, ITeste
    {
        public TesteRenato(Repository repository) : base(repository)
        {
        }

        public TesteRenato(DbConnection dbConnection) : base(dbConnection)
        {
        }

        public TesteRenato(DbTransaction dbTransaction) : base(dbTransaction)
        {
        }

        public TesteRenato(DbConnection dbConnection, bool isOwner) : base(dbConnection, isOwner)
        {
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RepositoryFactory.Config.ConfigAll();
        }
    }
}
