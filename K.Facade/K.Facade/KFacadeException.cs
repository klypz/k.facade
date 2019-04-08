using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace K.Facade
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
