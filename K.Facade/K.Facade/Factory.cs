using K.Facade.Auxiliars;
using System;
using System.Reflection;

namespace K.Facade
{
    //public static class Note
    //{
    //    public static string Version
    //    {
    //        get
    //        {
    //            AssemblyVersionAttribute.
    //        }
    //    }
    //}
    /// <summary>
    /// <para>Responsável por gerenciar as fachadas registradas no ambiente global</para>
    /// </summary>
    public static class Factory
    {
        public static Version Version { get; private set; } = new Version(0, 0, 3, 4);
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

        public static RegisterConfig Config { get; private set; } = new RegisterConfig(MappingConfig);
    }
}
