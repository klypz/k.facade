using System.Security.Principal;

namespace K.Facade.Tests
{
    public class UserSign : IUserSign
    {
        public string UserName { get; set; }

        public GenericIdentity SignIn(string userName, string password)
        {
            UserName = userName;

            return new GenericIdentity(userName, "DB");
        }

        public bool SignIn(GenericIdentity identity)
        {
            return true;
        }
    }
}
