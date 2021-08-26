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

        public void Update();

        public void Delete();

        public IList<AgentInfo> GetList();
    }
}
