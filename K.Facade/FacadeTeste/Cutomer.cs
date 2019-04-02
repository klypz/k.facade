using K.Essential;
using K.Essential.Quick;
using K.Facade;
using LayerFacade;
using System;
using System.Collections.Generic;

namespace FacadeTeste
{
    [SetFacade(typeof(ICustomer), "2")]
    [SetFacade(typeof(IMaintenance<object>), "2")]
    public class Customer2 : ICustomer
    {
        public Customer2()
        {

        }

        public Customer2(string teste)
        {

        }

        public int Delete(object entity)
        {
            throw new NotImplementedException();
        }

        public Result<object> Get(params object[] id)
        {
            throw new NotImplementedException();
        }

        public List<object> GetList()
        {
            throw new NotImplementedException();
        }

        public Result<object> Insert(object entity)
        {
            throw new NotImplementedException();
        }

        public void SetPeople(object client, object people)
        {
            throw new NotImplementedException();
        }

        public Result<object> Update(object entity)
        {
            throw new NotImplementedException();
        }
    }

    [SetFacade(typeof(ICustomer))]
    [SetFacade(typeof(IMaintenance<object>))]
    class Customer : ICustomer
    {
        public int Delete(object entity)
        {
            throw new NotImplementedException();
        }

        public Result<object> Get(params object[] id)
        {
            throw new NotImplementedException();
        }

        public List<object> GetList()
        {
            throw new NotImplementedException();
        }

        public Result<object> Insert(object entity)
        {
            throw new NotImplementedException();
        }

        public void SetPeople(object client, object people)
        {
            throw new NotImplementedException();
        }

        public Result<object> Update(object entity)
        {
            throw new NotImplementedException();
        }
    }
}
