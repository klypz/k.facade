using System;

namespace K.Facade
{
    public interface IMappingConfig
    {
        object GetRegister(Type type);
        object GetRegister(Type type, string target);
        object GetRegister(Type type, params object[] constructor);
        object GetRegister(Type type, string target, params object[] constructor);
        void Register(Type @interface, object value);
        void Register(Type @interface, string target, object value);
        void Register<T>(string target, T value);
        void Register<T>(T value);
        void Register<T, TValue>() where TValue: T, new();
        void Register<T, TValue>(string target) where TValue: T, new();
    }
}