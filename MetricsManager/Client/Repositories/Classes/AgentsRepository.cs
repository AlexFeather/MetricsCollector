using Dapper;
using MetricsManager.Models;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MetricsManager.Client.Repositories
{
    public class AgentsRepository : IAgentsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public void Create(Uri agentAdress)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("INSERT INTO agents(AgentAdress) VALUES(@AgentAdress)",
                    new
                    {
                        AgentAdress = agentAdress.ToString()
                    });
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public IList<AgentInfo> GetList()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Query<AgentInfo>("SELECT * FROM agents").ToList();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
