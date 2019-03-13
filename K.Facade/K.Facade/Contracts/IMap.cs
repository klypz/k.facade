using System;

namespace K.Facade.Contracts
{
    /// <summary>
    /// Responsável por mapear as facades
    /// </summary>
    public interface IMap
    {
        void Map<TInterface, TClass>() where TClass : TInterface, new();
        void Map<TInterface, TClass>(string target) where TClass : TInterface, new();
        void Map<TInterface>(TInterface @object);
        void Map<TInterface>(string target, TInterface @object);

        void Map(Type @interface, Type f);
        void Map(Type @interface, string target, Type f);
        void Map(Type @interface, object f);
        void Map(Type @interface, string target, object f);
    }
}
