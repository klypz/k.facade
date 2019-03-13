using System;
using System.Collections.Generic;
using System.Text;

namespace K.Facade
{
    /// <summary>
    /// Define uma classe como padrão de uma interface (facade)
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class SetFacadeAttribute : Attribute
    {
        public Type Interface { get; private set; }

        public string Target { get; private set; } = null;

        /// <summary>
        /// Define uma classe como padrão de uma interface (facade)
        /// </summary>
        /// <param name="interface">Interface facade</param>
        public SetFacadeAttribute(Type @interface)
        {
            Interface = @interface;
        }

        /// <summary>
        /// Define uma classe como padrão de uma interface (facade)
        /// </summary>
        /// <param name="interface">Interface facade</param>
        /// <param name="target">Alvo para alternativa de uma facade</param>
        public SetFacadeAttribute(Type @interface, string target) : this(@interface)
        {
            Target = target;
        }
    }
}
