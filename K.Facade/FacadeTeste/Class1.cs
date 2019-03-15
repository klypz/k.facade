using K.Facade;
using System;

namespace FacadeTeste
{
    public interface IInterface
    {
        string Name { get; set; }
    }

    public interface IInterface2
    {
        string Name { get; set; }
    }

    [SetFacade(typeof(IInterface))]
    public class PInterface : IInterface
    {
        public string Name { get; set; } = "Interface";
    }

    [SetFacade(typeof(IInterface), "M")]
    public class MInterface : IInterface
    {
        public string Name { get; set; } = "M Interface";
    }

    [SetFacade(typeof(IInterface), "M2")]
    public class M2Interface : IInterface
    {
        public string Name { get; set; } = "M2 Interface";
    }
}
