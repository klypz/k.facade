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
            MappingConfig config = new MappingConfig();

            var result = config.Config(cfg =>
            {
                cfg.Map<IInterface, PInterface>();
                cfg.Map<IInterface>("M", new MInterface());
            });

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
