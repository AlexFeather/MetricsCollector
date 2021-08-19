using Dapper;
using MetricsAgent.Models.Metrics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.Models.Repositories
{
    public class RamMetricsRepository : IRamMetricsRepository
    {

        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public void Create(RamMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("INSERT INTO rammetrics(value, time) VALUES(@value, @time)",
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
                connection.Execute("DELETE FROM rammetrics WHERE id=@id",
                    new { id });
            }
        }

        public void Update(RamMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("UPDATE rammetrics SET value = @value, time = @time WHERE id=@id;",
                    new
                    {
                        id = item.Id,
                        time = item.Time,
                        value = item.Value
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

        public IList<RamMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<RamMetric>("SELECT * FROM rammetric WHERE @fromTime <= Time <= @toTime",
                    new 
                    {
                        fromTime,
                        toTime
                    }).ToList();
            }
        }

        public RamMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.QuerySingle<RamMetric>("SELECT * FROM rammetrics WHERE id=@id",
                    new { id });
            }
        }
    }
}
