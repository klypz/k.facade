using System;

namespace K.Facade.Structure
{
    [Serializable]
    public class FacadeNotImplementedException : KFacadeException
    {
        public FacadeNotImplementedException(string facade, string @ref) : base($"Fachada [{facade}] não implementada em [{@ref}].")
        {
        }
    }
}