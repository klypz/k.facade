using System;

namespace K.Facade
{
    [Serializable]
    public class FacadeNotImplementedException : Exception
    {
        public FacadeNotImplementedException(string name1, string name2) : base($"Fachada [{name1}] não implementada em [{name2}].")
        {
        }
    }
}