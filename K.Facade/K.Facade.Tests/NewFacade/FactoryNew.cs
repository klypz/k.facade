using K.Facade.Base;
using System;

namespace K.Facade.Tests.NewFacade
{
    public abstract class Repo
    {

    }

    public interface IUseRepo
    {

    }

    internal class UseRepo : Repo, IUseRepo
    {

    }

    public static class Ini
    {
        public static void Start(RegisterConfig registerConfig)
        {
            registerConfig.Config(a => a.Register<IUseRepo, UseRepo>());
        }
    }

    public class MappingFacade : MappingConfig
    {
        public override void Register(Type @interface, object value)
        {
            if (value.GetType() == typeof(Type).GetType())
            {
                if (((Type)value).BaseType == typeof(Repo))
                {
                    base.Register(@interface, value);
                }
            }
        }
    }

    public class RepoRegister: RegisterConfig
    {
        public RepoRegister():base(new MappingFacade())
        {

        }
    }
}
