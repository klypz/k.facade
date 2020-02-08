using K.Facade.Domain;
using LayerFacade;
using System;
using System.Collections.Generic;

namespace FacadeTeste
{
	[SetFacade(typeof(IPeople))]
	class People : IPeople
    {
        public List<object> GetList()
        {
            throw new NotImplementedException();
        }

        public void Salvar(object entity)
        {
            throw new NotImplementedException();
        }
    }
}
