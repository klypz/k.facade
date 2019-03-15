using FacadeTeste;

namespace K.Facade.Tests.Models
{
    [SetFacade(typeof(IInterface2))]
    public class Interface : IInterface2
    {
        public string Name { get; set; } = "Interface2";
    }
}
