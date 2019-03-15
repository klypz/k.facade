using System;

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
        public static T GetInterface<T>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Obtém uma instancia referente a interface
        /// </summary>
        /// <typeparam name="T">Interface a ser instanciada</typeparam>
        /// <param name="target">Variação do mapeamento da interface</param>
        /// <returns>Instancia baseada em interface</returns>
        public static T GetInterface<T>(string target)
        {
            throw new NotImplementedException();
        }
    }

    class Register
    {
        public Type Interface { get; set; }
        public string Target { get; set; }
        public object Value { get; set; }

        public Register(Type @interface, object value)
        {

        }

        public Register(Type @interface, object value, string target)
        {

        }
    }
}
