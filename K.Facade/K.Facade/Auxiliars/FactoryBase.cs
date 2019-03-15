using K.Facade.Auxiliars;

namespace K.Facade.Auxiliars
{
    internal sealed class FactoryBase : IFactory
    {
        private MappingConfig mappingConfig = null;

        public IMappingConfig MappingConfig { get { return mappingConfig; } }

        internal FactoryBase(MappingConfig mappingConfig)
        {
            this.mappingConfig = mappingConfig;
        }

        /// <summary>
        /// Obtém uma instancia referente a interface
        /// </summary>
        /// <typeparam name="T">Interface a ser instanciada</typeparam>
        /// <returns>Instancia baseada em interface</returns>
        public T GetInstance<T>()
        {
            return (T)mappingConfig.GetRegister(typeof(T));
        }

        /// <summary>
        /// Obtém uma instancia referente a interface
        /// </summary>
        /// <typeparam name="T">Interface a ser instanciada</typeparam>
        /// <param name="target">Variação do mapeamento da interface</param>
        /// <returns>Instancia baseada em interface</returns>
        public T GetInstance<T>(string target)
        {
            return (T)mappingConfig.GetRegister(typeof(T), target);
        }
    }
}
