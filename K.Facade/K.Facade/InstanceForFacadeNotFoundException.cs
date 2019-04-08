using System;

namespace K.Facade
{
    [Serializable]
    public class InstanceForFacadeNotFoundException : KFacadeException
    {
        public InstanceForFacadeNotFoundException(string name) : base($"Não há instancia mapeada para a fachada [{name}]")
        {

        }
    }
}