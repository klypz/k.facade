using System;

namespace K.Facade
{
    [Serializable]
    internal class InvalidFacadeMapException : Exception
    {
        public InvalidFacadeMapException(string message) : base(message)
        {
        }
    }
}
