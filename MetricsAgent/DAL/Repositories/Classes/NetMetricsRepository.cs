using Dapper;
using MetricsAgent.DAL;
using MetricsAgent.Models.Metrics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.Models.Repositories
{
    public class NetMetricsRepository : INetMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public NetMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }


        public void Create(NetMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("INSERT INTO netmetrics(value, time) VALUES(@value, @time)",
                    new
                    {
                        value = item.Value,
                        time = item.Time
                    });
            }
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("DELETE FROM netmetrics WHERE id = @id",
                    new
                    {
                        id
                    });
            }
        }

        public void Update(NetMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("UPDATE netmetrics SET value = @value, time = @time WHERE id=@id;",
                    new
                    {
                        time = item.Time,
                        value = item.Value,
                        id = item.Id
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

        public IList<NetMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<NetMetric>("SELECT * FROM netmetrics WHERE @fromTime <= Time <= @toTime",
                    new
                    {
                        fromTime,
                        toTime
                    }).ToList();
            }
        }

        public NetMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.QuerySingle<NetMetric>("SELECT * FROM netmetrics WHERE id=@id",
                    new 
                    {
                    id
                    });
            }
        }
    }
}
