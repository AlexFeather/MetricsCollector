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
                connection.Execute("INSERT INTO netmetrics(ValueDownload, ValueUpload, Time) VALUES(@ValueDownload, @ValueUpload, @Time)",
                    new
                    {
                        ValueDownload = item.ValueDownload,
                        ValueUpload = item.ValueUpload,
                        Time = item.Time
                    });
            }
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("DELETE FROM netmetrics WHERE Id = @Id",
                    new
                    {
                        Id = id
                    });
            }
        }

        public void Update(NetMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("UPDATE netmetrics SET ValueDownload = @ValueDownload, ValueUpload = @ValueUpload, Time = @Time WHERE Id=@Id;",
                    new
                    {
                        Time = item.Time,
                        ValueDownload = item.ValueDownload,
                        ValueUpload = item.ValueUpload,
                        Id = item.Id
                    });
            }
        }

        public IList<NetMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<NetMetric>("SELECT Id, ValueDownload, ValueUpload, Time FROM netmetrics").ToList();
            }
        }

        public IList<NetMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<NetMetric>("SELECT Id, ValueDownload, ValueUpload, Time FROM netmetrics WHERE @fromTime <= Time AND Time <= @toTime",
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
                return connection.QuerySingle<NetMetric>("SELECT Id, ValueDownload, ValueUpload, Time FROM netmetrics WHERE Id=@Id",
                    new 
                    {
                    Id = id
                    });
            }
        }
    }
}
