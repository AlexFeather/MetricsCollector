using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client.Repositories
{
    public interface IRepository<T> where T: class
    {
        IList<T> GetAll();

        IList<T> GetAllOfAgent(int agentId);

        IList<T> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime);

        IList<T> GetByTimePeriodOfAgent(TimeSpan fromTime, TimeSpan toTime, int agentId);

        T GetById(int id);

        void Create(T item);

        void Update(T item);

        void Delete(int id);
    }
}
