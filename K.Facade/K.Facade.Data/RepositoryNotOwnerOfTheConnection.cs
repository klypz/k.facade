using System;

namespace K.Facade.Data
{
    [Serializable]
    public class RepositoryNotOwnerOfTheConnection : RepositoryException
    {
        public RepositoryNotOwnerOfTheConnection(string @class): base($"Repository [{@class}] is not the owner of the connection")
        {
        }

    }
}