using System;

namespace K.Facade
{
    public class MappingConfig
    {
        public MappingConfig()
        {

        }

        

        public void RegisterCollection(Type @interface, string target, object value)
        {

        }

        public void RegisterCollection(Type @interface, object value)
        {

        }

        public void RegisterCollection<Type, objecto>(Type @interface, object value)
        {

        }
    }
    public class RegisterConfig
    {
        public void Config(Action<MappingConfig> action)
        {
            Config(a => a.RegisterCollection(
                
                
                ) );
        }
    }
}
