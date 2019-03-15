using System.Collections.Generic;

namespace LayerFacade
{
    public interface ICustomer
    {
        List<object> GetList();

        void SetPeople(object client, object people);
    }
}
