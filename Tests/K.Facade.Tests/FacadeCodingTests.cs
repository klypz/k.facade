using IdentityModel;
using K.Facade.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace K.Facade.Tests
{
    [TestClass]
    public class FacadeCodingTests
    {
        public FacadeCodingTests()
        {
            var userSign = new UserSign();
            userSign.SignIn("user_instantiated", "password");
            DomainFactory.Mapper.Map(map =>
                map.Add<IUserSign, UserSign>()
                .Add<IUserSign>(userSign, "INST")
            );

        }

        [TestMethod]
        public void GetInstanceTest()
        {
            IUserSign sig = DomainFactory.GetInstance<IUserSign>();

            Assert.IsNotNull(sig, "Not Mapped");
        }

        [TestMethod]
        public void ExecuteMethodTest()
        {
            IUserSign sig = DomainFactory.GetInstance<IUserSign>();
            Assert.IsNotNull(sig, "Not Mapped");
            var resultSignIn = sig.SignIn("user_name", "user_password");
            Assert.IsNotNull(resultSignIn, "Not working method [SignIn]");
        }

        [TestMethod]
        public void InstanceMappingTest()
        {
            var instantiated = DomainFactory.GetInstance<IUserSign>("INST");
            Assert.AreEqual(instantiated.UserName, "user_instantiated", "Mapping instantiated not working");
        }
    }
}
