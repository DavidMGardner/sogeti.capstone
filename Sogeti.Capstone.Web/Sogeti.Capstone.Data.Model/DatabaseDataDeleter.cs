using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sogeti.Capstone.Data.Model
{
    public class DatabaseDataDeleter
    {
        static readonly string[] _ignoredTables =
        {
            "sysdiagrams",
            "usd_AppliedDatabaseScript",
            "__MigrationHistory"
        };

        readonly DbContext _dbContext;
        readonly Lazy<string> deleteSql;

        public DatabaseDataDeleter(DbContext dbContext)
        {
            _dbContext = dbContext;
            deleteSql = new Lazy<string>(GetDeleteSql);
        }


        string GetDeleteSql()
        {
            var allTables = GetAllTables();

            var allRelationships = GetRelationships();

            var tablesToDelete = BuildTableList(allTables, allRelationships);

            return BuildTableSqlAutoIncrementReset(tablesToDelete);
        }

        public virtual void DeleteAllObjects()
        {
            var sql = deleteSql.Value;

            _dbContext.Database.ExecuteSqlCommand(sql);
        }

        static string BuildTableSql(IEnumerable<string> tablesToDelete)
        {
            return tablesToDelete.Aggregate(string.Empty, (current, tableName) => current + string.Format("delete from [{0}];", tableName));
        }

        static string BuildTableSqlAutoIncrementReset(IEnumerable<string> tablesToDelete)
        {
            string sql = tablesToDelete.Aggregate(string.Empty, (current, tableName) =>
                        current + string.Format("delete from [{0}];", tableName));
            sql += tablesToDelete.Aggregate(String.Empty, (current, tableName) =>
                current + string.Format(" DBCC CHECKIDENT ({0}, RESEED, 0);", tableName));
            return sql;
        }

        static string[] BuildTableList(ICollection<string> allTables, ICollection<Relationship> allRelationships)
        {
            var tablesToDelete = new List<string>();

            while (allTables.Any())
            {
                var leafTables = allTables.Except(allRelationships.Select(rel => rel.PrimaryKeyTable)).ToList();

                tablesToDelete.AddRange(leafTables);

                leafTables.ForEach(lt =>
                {
                    allTables.Remove(lt);
                    var relToRemove = allRelationships.Where(rel => rel.ForeignKeyTable == lt).ToList();
                    relToRemove.ForEach(toRemove => allRelationships.Remove(toRemove));
                });
            }

            return tablesToDelete.ToArray();
        }

        IList<Relationship> GetRelationships()
        {
            const string sql =
                @"select
	so_pk.name as PrimaryKeyTable
,   so_fk.name as ForeignKeyTable
from
	sysforeignkeys sfk
	  inner join sysobjects so_pk on sfk.rkeyid = so_pk.id
	  inner join sysobjects so_fk on sfk.fkeyid = so_fk.id
order by
	so_pk.name
,   so_fk.name";

            return _dbContext.Database.SqlQuery<Relationship>(sql).ToList();
        }

        IList<string> GetAllTables()
        {
            return _dbContext.Database.SqlQuery<string>("select name from sys.tables").Except(_ignoredTables).ToList();
        }

        class Relationship
        {
            public string ForeignKeyTable { get; set; }
            public string PrimaryKeyTable { get; set; }
        }
    }
}
