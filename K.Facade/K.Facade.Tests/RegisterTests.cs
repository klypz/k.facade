using LayerFacade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;

namespace K.Facade.Tests
{
    [SetFacade(typeof(IPeople), "DAQUI")]
    internal class People2 : IPeople
    {
        public List<object> GetList()
        {
            throw new System.NotImplementedException();
        }

        public void Salvar(object entity)
        {
            throw new System.NotImplementedException();
        }
    }

    [TestClass]
    public class RegisterTests
    {
        [TestMethod]
        public void RegisterGlobalTest()
        {
            ICustomer customer = Substitute.For<ICustomer>();

            Factory.Config.ConfigAll();

            Factory.Config.Config(a =>
            {
                a.Register("CUSTT", customer);
            });

            var tst = Factory.GetInstance<ICustomer>("CUSTT");
            var peop2 = Factory.GetInstance<IPeople>("DAQUI");
            Assert.AreEqual(customer, tst);
            Assert.IsInstanceOfType(peop2, typeof(IPeople));
            Assert.ThrowsException<InstanceForFacadeNotFoundException>(() =>
            {
                Factory.GetInstance<IPeople>("NAOEXISTE");
            });

        }

        [TestMethod]
        public void RegisterLocalTest()
        {
            ICustomer customer = Substitute.For<ICustomer>();
            RegisterConfig registerConfig = new RegisterConfig();
            registerConfig.Config(a =>
            {
                a.Register("CUSTT", customer);
                a.Register<IPeople, People2>();
            });
            var fac = registerConfig.Factory;
        }
    }
}
