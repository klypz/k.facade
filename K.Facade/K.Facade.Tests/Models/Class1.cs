using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K.Facade.Tests.Models
{
    public interface IInterface
    {
        string Name { get; set; }
    }

    public class PInterface : IInterface
    {
        public string Name { get; set; } = "Renato Moraes";
    }

    public class MInterface : IInterface
    {
        public string Name { get; set; } = "M Interface";
    }
}
