using FacadeTeste;
using K.Facade.Contracts;
using K.Facade.Tests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace K.Facade.Tests
{
    [TestClass]
    public class MapperConfigTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IInterface config2 = Substitute.For<IInterface>();
            IMappingConfig config = new MappingConfig();

            var result = config.ConfigAssembly(new string[2] { "K.Facade.Tests", "FacadeTeste" });

            var n = result.GetInstance<IInterface>();
            var m = result.GetInstance<IInterface>("M");
        }

        [TestMethod]
        public void GlobalTest()
        {
            IInterface obj = Substitute.For<IInterface>();

            Factory.Config(cfg =>
            {
                cfg.Map<IInterface, PInterface>();
                cfg.Map<IInterface>("M", obj);
            });

            var n = Factory.GetInstance<IInterface>();
            var m = Factory.GetInstance<IInterface>("M");
        }


        [TestMethod]
        public void SubstituteTest()
        {
            Factory.Config(cfg =>
            {
                cfg.Map<IInterface, PInterface>();
                cfg.Map<IInterface>("M", new MInterface());
            });

            var n = Factory.GetInstance<IInterface>();
            var m = Factory.GetInstance<IInterface>("M");
        }
    }



    
}
