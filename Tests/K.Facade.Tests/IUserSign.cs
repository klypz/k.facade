using System.Security.Principal;

namespace K.Facade.Tests
{
    public interface IUserSign
    {
        string UserName { get; }

        GenericIdentity SignIn(string userName, string password);
        bool SignIn(GenericIdentity identity);
    }
}
