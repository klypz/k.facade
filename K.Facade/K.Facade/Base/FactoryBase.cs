namespace K.Facade.Base
{
    public class FactoryBase : IFactory
    {
        private IMappingConfig mappingConfig = null;

        public IMappingConfig MappingConfig { get { return mappingConfig; } }

        internal FactoryBase(IMappingConfig mappingConfig)
        {
            this.mappingConfig = mappingConfig;
        }

        /// <summary>
        /// Obtém uma instancia referente a interface
        /// </summary>
        /// <typeparam name="T">Interface a ser instanciada</typeparam>
        /// <returns>Instancia baseada em interface</returns>
        public virtual T GetInstance<T>()
        {
            return (T)mappingConfig.GetRegister(typeof(T));
        }

        /// <summary>
        /// Obtém uma instancia referente a interface
        /// </summary>
        /// <typeparam name="T">Interface a ser instanciada</typeparam>
        /// <param name="target">Variação do mapeamento da interface</param>
        /// <returns>Instancia baseada em interface</returns>
        public virtual T GetInstance<T>(string target)
        {
            return (T)mappingConfig.GetRegister(typeof(T), target);
        }

        public virtual T GetInstance<T>(params object[] constructor)
        {
            return (T)mappingConfig.GetRegister(typeof(T), constructor);
        }

        public virtual T GetInstance<T>(string target, params object[] constructor)
        {
            return (T)mappingConfig.GetRegister(typeof(T), target, constructor);
        }
    }
}
