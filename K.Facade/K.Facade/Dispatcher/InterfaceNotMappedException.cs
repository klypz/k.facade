using System;
using System.Runtime.Serialization;

namespace K.Facade.Dispatcher
{
	[Serializable]
	internal class InterfaceNotMappedException : Exception
	{
		private Type type;
		private string target;

		public InterfaceNotMappedException()
		{
		}

		public InterfaceNotMappedException(string message) : base(message)
		{
		}

		public InterfaceNotMappedException(Type type, string target)
		{
			this.type = type;
			this.target = target;
		}

		public InterfaceNotMappedException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InterfaceNotMappedException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}