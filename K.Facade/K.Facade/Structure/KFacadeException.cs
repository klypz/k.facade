using System;
using System.Runtime.Serialization;

namespace K.Facade.Structure
{
	public class KFacadeException : Exception
    {
        public KFacadeException()
        {
        }

        public KFacadeException(string message) : base(message)
        {
        }

        public KFacadeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected KFacadeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
