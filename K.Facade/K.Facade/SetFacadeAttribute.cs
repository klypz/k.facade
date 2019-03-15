using System;

namespace K.Facade
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class SetFacadeAttribute : Attribute
    {
        private readonly Type facade;
        private readonly string target;

        public Type Facade => facade;
        public string Target => target;

        public SetFacadeAttribute(Type facade)
        {
            this.facade = facade;
        }

        public SetFacadeAttribute(Type facade, string target) : this(facade)
        {
            this.target = target;
        }
    }
}
