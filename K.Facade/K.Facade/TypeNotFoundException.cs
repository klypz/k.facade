using System;

namespace K.Facade
{
    /// <summary>
    /// <para>Quando uma interface não é encontrada no mapeamento</para>
    /// </summary>
    [Serializable]
    public class TypeNotFoundException : Exception
    {
        /// <summary>
        /// <para>Quando uma interface não é encontrada no mapeamento</para>
        /// </summary>
        /// <param name="interfaceType">Nome da interface não encontrada</param>
        public TypeNotFoundException(string interfaceType) : base($"No reference to interface [{interfaceType}]")
        {
        }
    }
}
