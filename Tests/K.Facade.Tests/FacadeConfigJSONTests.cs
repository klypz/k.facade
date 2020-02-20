using K.Facade.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace K.Facade.Tests
{
    [TestClass]
    public class FacadeConfigJSONTests
    {
        public FacadeConfigJSONTests()
        {
            DomainFactory.Mapper.LoadMapping();
        }

        [TestMethod]
        public void MappingTest()
        {
            var a = DomainFactory.GetInstance<IUserSign>("Config");
            var login = a.SignIn("test_mappgin", "password");
            Assert.IsNotNull(a, "LoadMapping not working");
            Assert.AreEqual(a.UserName, "test_mappgin: Config", "LoadMapping invalid refer");
            Assert.AreEqual(a.UserName, login.Name, "Ops... Error");
        }
    }
}
