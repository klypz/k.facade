using System;

namespace K.Facade.Data
{
    /// <summary>
    /// Atributo de definição de repository padrão
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class SetRepositoryAttribute : Attribute
    {
        private readonly Type repository;
        private readonly string target;

        public Type Repository => repository;
        public Type Facade => Repository;
        public string Target => target;

        /// <summary>
        /// Atributo de definição de repository padrão
        /// </summary>
        /// <param name="repository">Interface repository mapeada</param>
        public SetRepositoryAttribute(Type repository)
        {
            this.repository = repository;
        }


        /// <summary>
        /// Atributo de definição de repository padrão
        /// </summary>
        /// <param name="repository">Interface repository mapeada</param>
        /// <param name="target">Especificar um alvo para que seja possível mais de uma representação para o mesmo repository</param>
        public SetRepositoryAttribute(Type repository, string target) : this(repository)
        {
            this.target = target;
        }
    }
}
