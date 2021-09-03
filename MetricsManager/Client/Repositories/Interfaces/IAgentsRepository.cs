using MetricsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Client.Repositories
{
    public interface IAgentsRepository
    {
        public void Create(Uri agentAdress);

        public void Update(AgentInfo agentInfo);

        public void Delete(int id);

        public IList<AgentInfo> GetList();
    }
}
