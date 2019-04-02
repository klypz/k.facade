using FacadeTeste;
using K.Essential.Quick;
using LayerFacade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace K.Facade.Tests
{
    [TestClass]
    public class RegisterTests
    {
        [TestMethod]
        [TestCategory("Register")]
        public void RegisterGlobalTest()
        {
            Factory.Config.ConfigAll();

            Assert.IsInstanceOfType(Factory.GetInstance<IPeople>(), typeof(IPeople));
            Assert.IsInstanceOfType(Factory.GetInstance<ICustomer>("2"), typeof(Customer2));
            Assert.IsInstanceOfType(Factory.GetInstance<IMaintenance<object>>("2"), typeof(Customer2));
        }

        [TestMethod]
        [TestCategory("Register")]
        public void RegisterLocalTest()
        {
            RegisterConfig registerConfig = new RegisterConfig();
            registerConfig.ConfigAll();

            IFactory factory = registerConfig.Factory;

            Assert.IsInstanceOfType(factory.GetInstance<IPeople>(), typeof(IPeople));
            Assert.IsInstanceOfType(factory.GetInstance<ICustomer>("2"), typeof(Customer2));
            Assert.IsInstanceOfType(factory.GetInstance<IMaintenance<object>>("2"), typeof(Customer2));
        }

        [TestMethod]
        [TestCategory("Register")]
        public void RegisterManualLocalTests()
        {
            RegisterConfig registerConfig = new RegisterConfig();
            registerConfig.Config(cfg =>
            {
                cfg.Register<ICustomer, Customer2>();
                cfg.Register<IMaintenance<object>, Customer2>();
            });

            var t = registerConfig.Factory.GetInstance<ICustomer>((object)"Renato");

            IFactory factory = registerConfig.Factory;

            Assert.ThrowsException<InstanceForFacadeNotFoundException>(() => factory.GetInstance<IPeople>());
            Assert.ThrowsException<InstanceForFacadeNotFoundException>(() => factory.GetInstance<ICustomer>("2"));
            Assert.IsInstanceOfType(factory.GetInstance<IMaintenance<object>>(), typeof(Customer2));
        }
    }
}
