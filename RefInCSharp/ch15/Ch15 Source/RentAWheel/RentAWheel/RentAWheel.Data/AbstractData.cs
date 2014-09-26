using System.Configuration;

namespace RentAWheel.Data
{
    public abstract class AbstractData<Persisted>        
    {
        public AbstractData(ConnectionStringSettings settings)
        {
            ConnectionStringSettings = settings;
        }

        public virtual ConnectionStringSettings ConnectionStringSettings
        {
            get;
            private set;
        }

    }
}
