using System;
using System.Data.Common;

namespace K.Facade.Data
{
    public static class RepositoryFactory
    {
        private static RepositoryConfig config = null;
        public static RepositoryConfig Config
        {
            get
            {
                if (config == null)
                {
                    config = new RepositoryConfig();
                }
                return config;
            }
        }
        public static T GetInstance<T>(Repository repository) where T : IDisposable
        {
            return config.Factory.GetInstance<T>(repository);
        }
        public static T GetInstance<T>(DbConnection dbConnection) where T : IDisposable
        {
            return config.Factory.GetInstance<T>(dbConnection);
        }
        public static T GetInstance<T>(DbConnection dbConnection, bool isOwner) where T: IDisposable
        {
            return config.Factory.GetInstance<T>(dbConnection, isOwner);
        }
    }
}
