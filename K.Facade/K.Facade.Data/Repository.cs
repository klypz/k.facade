using System;
using System.Data;
using System.Data.Common;

namespace K.Facade.Data
{
    public abstract class Repository : IRepository, IDisposable
    {
        public DbConnection Connection { get; private set; }
        public DbTransaction Transaction { get; private set; }
        public bool IsOwner { get; private set; }

        public Repository(Repository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            Connection = repository.Connection;
            Transaction = repository.Transaction;
            IsOwner = false;
        }

        public Repository(DbConnection dbConnection)
        {
            Connection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
            IsOwner = true;
        }

        public Repository(DbConnection dbConnection, bool isOwner) : this(dbConnection)
        {
            IsOwner = isOwner;
        }

        public Repository(DbTransaction dbTransaction)
        {
            Transaction = dbTransaction ?? throw new ArgumentNullException(nameof(dbTransaction));
            Connection = Transaction.Connection;
            IsOwner = false;
        }

        public DbTransaction BeginTransaction()
        {
            if (IsOwner)
            {
                if (Transaction != null)
                {
                    throw new RepositoryAlreadyHasAnOpenTransaction(GetType().Name);
                }

                return Transaction = Connection.BeginTransaction();
            }

            throw new RepositoryNotOwnerOfTheConnection(GetType().Name);
        }

        public DbTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            if (IsOwner)
            {
                if (Transaction != null)
                {
                    throw new RepositoryAlreadyHasAnOpenTransaction(GetType().Name);
                }

                return Transaction = Connection.BeginTransaction(isolationLevel);
            }

            throw new RepositoryNotOwnerOfTheConnection(GetType().Name);
        }

        public void Dispose()
        {
            if (IsOwner)
            {
                Transaction?.Commit();
                if (Connection?.State == ConnectionState.Open)
                {
                    Connection.Close();
                }
            }
        }
    }
}
