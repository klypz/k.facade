namespace K.Facade
{
    /// <summary>
    /// <para>Factory para obtenção de facade registrada</para>
    /// <para>Deve ser obtida na instancia do objeto RegisterConfig</para>
    /// </summary>
    public interface IFactory
    {
        // <summary>
        /// Obtém uma instancia referente a interface
        /// </summary>
        /// <typeparam name="T">Interface a ser instanciada</typeparam>
        /// <returns>Instancia baseada em interface</returns>
        T GetInstance<T>();

        /// <summary>
        /// Obtém uma instancia referente a interface
        /// </summary>
        /// <typeparam name="T">Interface a ser instanciada</typeparam>
        /// <param name="target">Variação do mapeamento da interface</param>
        /// <returns>Instancia baseada em interface</returns>
        T GetInstance<T>(string target);

        // <summary>
        /// Obtém uma instancia referente a interface
        /// </summary>
        /// <typeparam name="T">Interface a ser instanciada</typeparam>
        /// <returns>Instancia baseada em interface</returns>
        T GetInstance<T>(params object[] constructor);

        /// <summary>
        /// Obtém uma instancia referente a interface
        /// </summary>
        /// <typeparam name="T">Interface a ser instanciada</typeparam>
        /// <param name="target">Variação do mapeamento da interface</param>
        /// <returns>Instancia baseada em interface</returns>
        T GetInstance<T>(string target, params object[] constructor);
    }
}