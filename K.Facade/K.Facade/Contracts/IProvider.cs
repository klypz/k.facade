using System;

namespace K.Facade.Contracts
{
    /// <summary>
    /// Responsável por manter o mapeamento de facade
    /// </summary>
    public interface IProvider
    {
        bool Has(Type type, string target);
        Type Get(Type type, string target);
        Type Get(Type type);
        bool Has(Type type);
    }
}
