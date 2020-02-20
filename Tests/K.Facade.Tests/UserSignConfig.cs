using K.Facade.Domain;
using System.Security.Principal;

namespace K.Facade.Tests
{
    [SetFacade(typeof(IUserSign), "Config")]
    class UserSignConfig : IUserSign
    {
        public string UserName { get; set; }

        public GenericIdentity SignIn(string userName, string password)
        {
            UserName = userName + ": Config";

            return new GenericIdentity(UserName, "password");
        }

        public bool SignIn(GenericIdentity identity)
        {
            return false;
        }
    }
}
