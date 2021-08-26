using Dapper;
using MetricsManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsManager.Client.Repositories
{
    public class NetMetricsRepository : INetMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public void Create(NetMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("INSERT INTO netmetrics(AgentId, ValueDownload, ValueUpload, Time) VALUES (@AgentId, @ValueDownload, @ValueUpload, @Time)",
                    new
                    {
                        item.AgentId,
                        item.ValueDownload,
                        item.ValueUpload,
                        item.Time
                    });
            }
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("DELETE FROM netmetrics WHERE Id=@Id",
                    new
                    {
                        Id = id
                    });
            }
        }

        public IList<NetMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<NetMetric>("SELECT * FROM netmetrics").ToList();
            }
        }

        public IList<NetMetric> GetAllOfAgent(int agentId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<NetMetric>("SELECT * FROM netmetrics WHERE AgentId=@AgentId",
                    new
                    {
                        AgentId = agentId
                    }).ToList();
            }
        }

        public NetMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.QuerySingle<NetMetric>("SELECT * FROM netmetrics WHERE Id=@Id",
                    new
                    {
                        Id = id
                    });
            }
        }

        public IList<NetMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<NetMetric>("SELECT * FROM netmetrics WHERE @FromTime <= Time AND Time <= @ToTime",
                    new
                    {
                        FromTime = fromTime,
                        ToTime = toTime
                    }).ToList();
            }
        }

        public IList<NetMetric> GetByTimePeriodOfAgent(TimeSpan fromTime, TimeSpan toTime, int agentId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<NetMetric>("SELECT * FROM netmetrics WHERE @FromTime <= Time AND Time <= @ToTime AND AgentId=@AgentId",
                    new
                    {
                        FromTime = fromTime,
                        ToTime = toTime,
                        AgentId = agentId
                    }).ToList();
            }
        }

        public void Update(NetMetric item)
        {
            throw new NotImplementedException();
        }
    }
}
