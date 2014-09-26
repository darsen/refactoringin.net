using System;
using System.Collections.Generic;

namespace RentAWheel.Data
{
    public interface IData<Persisted>
    {
        void Delete(Persisted persisted);
        IList<Persisted> GetAll();
        void Insert(Persisted persisted);
        void Update(Persisted persisted);
    }
}   
