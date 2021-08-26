using Dapper;
using MetricsManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsManager.Client.Repositories
{
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public void Create(RamMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("INSERT INTO rammetrics(AgentId, Value, Time) VALUES (@AgentId, @Value, @Time)",
                    new
                    {
                        item.AgentId,
                        item.Value,
                        item.Time
                    });
            }
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("DELETE FROM rammetrics WHERE Id=@Id",
                    new
                    {
                        Id = id
                    });
            }
        }

        public IList<RamMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<RamMetric>("SELECT * FROM rammetrics").ToList();
            }
        }

        public IList<RamMetric> GetAllOfAgent(int agentId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<RamMetric>("SELECT * FROM rammetrics WHERE AgentId=@AgentId",
                    new
                    {
                        AgentId = agentId
                    }).ToList();
            }
        }

        public RamMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.QuerySingle<RamMetric>("SELECT * FROM rammetrics WHERE Id=@Id",
                    new
                    {
                        Id = id
                    });
            }
        }

        public IList<RamMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<RamMetric>("SELECT * FROM rammetrics WHERE @FromTime <= Time AND Time <= @ToTime",
                    new
                    {
                        FromTime = fromTime,
                        ToTime = toTime
                    }).ToList();
            }
        }

        public IList<RamMetric> GetByTimePeriodOfAgent(TimeSpan fromTime, TimeSpan toTime, int agentId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<RamMetric>("SELECT * FROM rammetrics WHERE @FromTime <= Time AND Time <= @ToTime AND AgentId=@AgentId",
                    new
                    {
                        FromTime = fromTime,
                        ToTime = toTime,
                        AgentId = agentId
                    }).ToList();
            }
        }

        public void Update(RamMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("UPDATE rammetrics SET Value = @Value, Time = @Time WHERE Id = @Id",
                    new
                    {
                        Value = item.Value,
                        Time = item.Time,
                        Id = item.Id
                    });
            }
        }
    }
}
