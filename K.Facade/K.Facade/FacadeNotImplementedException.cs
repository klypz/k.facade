using System;

namespace K.Facade
{
    [Serializable]
    public class FacadeNotImplementedException : Exception
    {
        public FacadeNotImplementedException(string facade, string @ref) : base($"Fachada [{facade}] não implementada em [{@ref}].")
        {
        }
    }
}