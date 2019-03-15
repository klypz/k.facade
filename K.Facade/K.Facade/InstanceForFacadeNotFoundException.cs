using System;

namespace K.Facade
{
    [Serializable]
    public class InstanceForFacadeNotFoundException : Exception
    {
        public InstanceForFacadeNotFoundException(string name) : base($"Não há instancia mapeada para a fachada [{name}]")
        {

        }
    }
}