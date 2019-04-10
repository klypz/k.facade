using K.Facade.Base;
using System;

namespace K.Facade.Data
{

    [Serializable]
    public class RepositoryNotInheritedException : Exception
    {
        public RepositoryNotInheritedException(string classOrigin): base($"Classe [{classOrigin}] não herda da classe [Repository]") { }
    }

    public class RepositoryMapping : MappingConfig
    {
        private bool ObjectIsValid(object value)
        {
            if (value.GetType() != typeof(Type).GetType())
            {
                return value.GetType().IsSubclassOf(typeof(Repository));
            }
            else
            {
                return ((Type)value).IsSubclassOf(typeof(Repository));
            }
        }

        public override void Register(Type @interface, object value)
        {
            if (ObjectIsValid(value))
            {
                base.Register(@interface, value);
            }
            else
            {
                if (value.GetType() != typeof(Type).GetType())
                {

                    throw new RepositoryNotInheritedException(value.GetType().Name);
                }
                else
                {
                    throw new RepositoryNotInheritedException(((Type)value).Name);
                }
            }
        }
    }
}
