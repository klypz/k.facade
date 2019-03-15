using System;

namespace K.Facade
{
    public interface IMappingConfig
    {
        void Register(Type @interface, object value);
        void Register(Type @interface, string target, object value);
        void Register<T>(string target, T value);
        void Register<T>(T value);
        void Register<T, TValue>() where TValue: T, new();
        void Register<T, TValue>(string target) where TValue: T, new();
    }
}