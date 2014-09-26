using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;

namespace RentAWheel.Data
{
    public class LinqData<Persisted> : 
        AbstractData<Persisted>, 
        IData<Persisted> where Persisted : class
    {

        private Table<Persisted> entities;

        private ConnectionStringSettings settings;

        private DataContext context;

        public LinqData(ConnectionStringSettings settings)
            : base(settings)
        {
            this.settings = settings;            
        }
      
        public DataContext Context
        {
            get 
            {
                return context;
            }
            set
            {
                context = value;
                entities = Context.GetTable<Persisted>();
            }
        }     

        public void Delete(Persisted persisted)
        {
            entities.DeleteOnSubmit(persisted);
            Context.SubmitChanges();
        }

        public IList<Persisted> GetAll()
        {
            entities = Context.GetTable<Persisted>();
            var allPersistedes =
                  from queried in entities
                  select queried;
            return allPersistedes.ToList<Persisted>();
        }

        public void Insert(Persisted persisted)
        {
            entities.InsertOnSubmit(persisted);
            Context.SubmitChanges();
        }

        public void Update(Persisted persisted)
        {
            Context.SubmitChanges();
        }

        public IQueryable<Persisted> Queryable
        {
            get {
                return entities;
            }
        }
    }
}
