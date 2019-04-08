using System;

namespace K.Facade.Data
{
    [Serializable]
    public class RepositoryAlreadyHasAnOpenTransaction : RepositoryException
    {
        public RepositoryAlreadyHasAnOpenTransaction(string @class) : base($"Repository [{@class}] already has an open transaction")
        {
        }
    }
}