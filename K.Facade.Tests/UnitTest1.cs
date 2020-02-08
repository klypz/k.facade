using System;
using K.Facade.Tests.NewFacade;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace K.Facade.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RepoRegister repoRegister = new RepoRegister();
            Ini.Start(repoRegister);

            var t = repoRegister.Factory.GetInstance<IUseRepo>();

        }
    }
}
