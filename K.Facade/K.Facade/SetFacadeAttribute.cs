using System;

namespace K.Facade
{
    /// <summary>
    /// Atributo de definição de facade padrão
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class SetFacadeAttribute : Attribute
    {
        private readonly Type facade;
        private readonly string target;

        public Type Facade => facade;
        public string Target => target;

        /// <summary>
        /// Atributo de definição de facade padrão
        /// </summary>
        /// <param name="facade">Interface facade mapeada</param>
        public SetFacadeAttribute(Type facade)
        {
            this.facade = facade;
        }


        /// <summary>
        /// Atributo de definição de facade padrão
        /// </summary>
        /// <param name="facade">Interface facade mapeada</param>
        /// <param name="target">Especificar um alvo para que seja possível mais de uma representação para o mesmo facade</param>
        public SetFacadeAttribute(Type facade, string target) : this(facade)
        {
            this.target = target;
        }
    }
}
