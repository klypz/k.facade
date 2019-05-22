using FacadeTeste;
using K.Essential;
using K.Essential.Quick;
using LayerFacade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;

namespace K.Facade.Tests
{
    [TestClass]
    public class SubstituteTests
    {
        [TestMethod]
        [TestCategory("Register")]
        public void RegisterGlobalTest()
        {
            ICustomer customer = Substitute.For<ICustomer>();

            __Factory.Config.ConfigAll();
            __Factory.Config.Config(cfg =>
            {
                cfg.Register<IMaintenance<object>>("TEST", customer);
            });

            Assert.IsInstanceOfType(__Factory.GetInstance<IPeople>(), typeof(IPeople));
            Assert.IsInstanceOfType(__Factory.GetInstance<ICustomer>("2"), typeof(Customer2));
            Assert.IsInstanceOfType(__Factory.GetInstance<IMaintenance<object>>("2"), typeof(Customer2));

            Guid id = Guid.NewGuid();
            var result = new Result<object>(ResultType.Empty);
            customer.Get(id).Returns(result);

            Assert.IsInstanceOfType(__Factory.GetInstance<IMaintenance<object>>("TEST"), typeof(ICustomer));
            Assert.AreEqual(__Factory.GetInstance<IMaintenance<object>>("TEST").Get(id), result);
        }
    }
}
