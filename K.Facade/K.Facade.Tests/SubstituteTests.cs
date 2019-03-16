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

            Factory.Config.ConfigAll();
            Factory.Config.Config(cfg =>
            {
                cfg.Register<IMaintenance<object>>("TEST", customer);
            });

            Assert.IsInstanceOfType(Factory.GetInstance<IPeople>(), typeof(IPeople));
            Assert.IsInstanceOfType(Factory.GetInstance<ICustomer>("2"), typeof(Customer2));
            Assert.IsInstanceOfType(Factory.GetInstance<IMaintenance<object>>("2"), typeof(Customer2));

            Guid id = Guid.NewGuid();
            var result = new Result<object>(ResultType.Empty);
            customer.Get(id).Returns(result);

            Assert.IsInstanceOfType(Factory.GetInstance<IMaintenance<object>>("TEST"), typeof(ICustomer));
            Assert.AreEqual(Factory.GetInstance<IMaintenance<object>>("TEST").Get(id), result);
        }
    }
}
