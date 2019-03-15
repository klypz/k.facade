using K.Facade;
using LayerFacade;
using System;
using System.Collections.Generic;

namespace FacadeTeste
{
    [SetFacade(typeof(ICustomer))]
    class Cutomer : ICustomer
    {
        public List<object> GetList()
        {
            throw new NotImplementedException();
        }

        public void SetPeople(object client, object people)
        {
            throw new NotImplementedException();
        }
    }
}
