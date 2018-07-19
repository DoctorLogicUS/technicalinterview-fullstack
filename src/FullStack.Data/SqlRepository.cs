using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FullStack.Data
{
    public class SqlRepository<T> : IRepository<T>
    {
        private readonly string _connectionString;
        private readonly string _typeName;

        public SqlRepository(string connectionString)
        {
            _connectionString = connectionString;
            _typeName = typeof(T).Name;
        }

        public virtual async Task<int> Create(T values)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    DynamicParameters parameters = ValuesToParameters(values);

                    int id = await conn.ExecuteAsync($"crud.{_typeName}_Create", parameters, commandType: CommandType.StoredProcedure);
                    return id;
                }
            }
            catch (Exception)
            {
                // logging would go here
                return 0;
            }
        }

        public virtual async Task<bool> Delete(int id)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var parameters = new DynamicParameters();

                    parameters.Add($"{_typeName}Id", id);

                    await conn.ExecuteAsync($"crud.{_typeName}_Delete", parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception)
            {
                // logging would go here
                return false;
            }
        }

        public virtual async Task<T> Get(int id)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var parameters = new DynamicParameters();

                    parameters.Add($"{_typeName}Id", id);

                    T item = await conn.QuerySingleAsync<T>($"crud.{_typeName}_Read", parameters, commandType: CommandType.StoredProcedure);
                    return item;
                }
            }
            catch (Exception)
            {
                // logging would go here
                return default(T);
            }
        }

        public virtual async Task<IEnumerable<T>> List(IDictionary<string, object> filters)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    var parameters = new DynamicParameters();

                    foreach (var filter in filters ?? new Dictionary<string, object>())
                    {
                        parameters.Add(filter.Key, filter.Value);
                    }

                    IEnumerable<T> items = await conn.QueryAsync<T>($"crud.{_typeName}_Read", parameters, commandType: CommandType.StoredProcedure);
                    return items;
                }
            }
            catch (Exception)
            {
                // logging would go here
                return Enumerable.Empty<T>();
            }
        }

        public virtual async Task<bool> Update(int id, T values)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    DynamicParameters parameters = ValuesToParameters(values);

                    // add the primary key parameter
                    parameters.Add($"{_typeName}Id", id);

                    await conn.ExecuteAsync($"crud.{_typeName}_Update", parameters, commandType: CommandType.StoredProcedure);
                    return true;
                }
            }
            catch (Exception)
            {
                // logging would go here
                return false;
            }
        }

        protected IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        protected virtual DynamicParameters ValuesToParameters(T values)
        {
            return new DynamicParameters(values);
        }
    }
}