using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Migrations
{
    [Migration(1)]
    public class FirstMigration : Migration
    {
        public override void Down()
        {
            Delete.Table("agents");
            Delete.Table("cpumetrics");
            Delete.Table("netmetrics");
            Delete.Table("rammerics")l
        }

        public override void Up()
        {
            Create.Table("agents")
                .WithColumn("AgentId").AsInt64().PrimaryKey().Identity()
                .WithColumn("AgentAdress").AsString();
            Create.Table("cpumetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("AgentId").AsInt64()
                .WithColumn("Time").AsInt64()
                .WithColumn("Value").AsInt32();
            Create.Table("netmetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("AgentId").AsInt64()
                .WithColumn("Time").AsInt64()
                .WithColumn("ValueUpload").AsInt32()
                .WithColumn("ValueDownload").AsInt32();
            Create.Table("rammetrics")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("AgentId").AsInt64()
                .WithColumn("Time").AsInt64()
                .WithColumn("Value").AsInt32();
        }
    }
}
