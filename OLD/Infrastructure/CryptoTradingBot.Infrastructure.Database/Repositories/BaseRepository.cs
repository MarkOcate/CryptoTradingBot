using CryptoTradingBot.Infrastructure.Database.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoTradingBot.Core.Interfaces;
using Dapper;

namespace CryptoTradingBot.Infrastructure.Database.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T>
    {
        protected readonly IDatabaseService _databaseService;
        private readonly string _tableName;

        protected BaseRepository(IDatabaseService databaseService, string tableName)
        {
            _databaseService = databaseService;
            _tableName = tableName;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using var connection = _databaseService.CreateConnection();
            return await connection.QueryAsync<T>($"SELECT * FROM {_tableName}");
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using var connection = _databaseService.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<T>($"SELECT * FROM {_tableName} WHERE Id = @Id", new { Id = id });
        }

        public async Task<int> AddAsync(T entity)
        {
            using var connection = _databaseService.CreateConnection();
            return await connection.ExecuteAsync($"INSERT INTO {_tableName} VALUES (@Entity)", entity);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            using var connection = _databaseService.CreateConnection();
            return await connection.ExecuteAsync($"UPDATE {_tableName} SET @Entity WHERE Id = @Id", entity);
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = _databaseService.CreateConnection();
            return await connection.ExecuteAsync($"DELETE FROM {_tableName} WHERE Id = @Id", new { Id = id });
        }
    }
}
