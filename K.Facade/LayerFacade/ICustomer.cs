using K.Essential.Quick;
using System.Collections.Generic;

namespace LayerFacade
{
    public interface ICustomer: IMaintenance<object>
    {
        List<object> GetList();

        void SetPeople(object client, object people);
    }
}
