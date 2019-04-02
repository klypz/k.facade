using K.Facade.Base;

namespace K.Facade
{
    /// <summary>
    /// <para>Responsável por gerenciar as fachadas registradas no ambiente global</para>
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Obtém uma instancia referente a interface
        /// </summary>
        /// <typeparam name="T">Interface a ser instanciada</typeparam>
        /// <returns>Instancia baseada em interface</returns>
        public static T GetInstance<T>()
        {
            return (T)MappingConfig.GetRegister(typeof(T));
        }

        /// <summary>
        /// Obtém uma instancia referente a interface
        /// </summary>
        /// <typeparam name="T">Interface a ser instanciada</typeparam>
        /// <param name="target">Variação do mapeamento da interface</param>
        /// <returns>Instancia baseada em interface</returns>
        public static T GetInstance<T>(string target)
        {
            return (T)MappingConfig.GetRegister(typeof(T), target);
        }

        static MappingConfig MappingConfig { get; set; } = new MappingConfig();

        /// <summary>
        /// Registra facade no ambiente global.
        /// </summary>
        public static RegisterConfig Config { get; private set; } = new RegisterConfig(MappingConfig);
    }
}
