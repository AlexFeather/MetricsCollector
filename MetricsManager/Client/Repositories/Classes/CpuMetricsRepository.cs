using Dapper;
using MetricsManager.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsManager.Client.Repositories
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public void Create(CpuMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("INSERT INTO cpumetics(AgentId, Value, Time) VALUES (@AgentId, @Value, @Time)",
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
                connection.Execute("DELETE FROM cpumetrics WHERE Id=@Id",
                    new
                    {
                        Id = id
                    });
            }
        }

        public IList<CpuMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<CpuMetric>("SELECT * FROM cpumetrics").ToList();
            }
        }

        public IList<CpuMetric> GetAllOfAgent(int agentId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<CpuMetric>("SELECT * FROM cpumetrics WHERE AgentId=@AgentId",
                    new
                    {
                        AgentId = agentId
                    }).ToList();
            }

        }

        public CpuMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.QuerySingle<CpuMetric>("SELECT * FROM cpumetrics WHERE Id=@Id",
                    new
                    {
                        Id = id
                    });
            }
        }

        public IList<CpuMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<CpuMetric>("SELECT * FROM cpumetrics WHERE @FromTime <= Time AND Time <= @ToTime",
                    new 
                    {
                        FromTime = fromTime,
                        ToTime = toTime
                    }).ToList();
            }
        }

        public IList<CpuMetric> GetByTimePeriodOfAgent(TimeSpan fromTime, TimeSpan toTime, int agentId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<CpuMetric>("SELECT * FROM cpumetrics WHERE @FromTime <= Time AND Time <= @ToTime AND AgentId=@AgentId",
                    new 
                    {
                    FromTime = fromTime,
                    ToTime = toTime,
                    AgentId = agentId
                    }).ToList();
            }
        }

        public void Update(CpuMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("UPDATE netmetrics SET Value = @Value, Time = @Time WHERE Id = @Id",
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
