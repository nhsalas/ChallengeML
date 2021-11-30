using Dapper;
using Data;
using Data.Repositories;
using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositories.MySQL
{
    public class BitacoraRepository : IBitacoraRepository
    {
        private MySQLConfiguration _connectionString;
        public BitacoraRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public void Add(Bitacora bitacora)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> InsertLog(Bitacora bitacora)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO challengedb.bitacora (datos) VALUES (@datos)";

            var result = await db.ExecuteAsync(sql, new { bitacora.datos });

            return result > 0;
        }

        public async Task<IEnumerable<Bitacora>> GetAllLogs()
        {
            var db = dbConnection();

            var sql = @"SELECT id, datos FROM challengedb.bitacora";

            return await db.QueryAsync<Bitacora>(sql, new { });
        }

        public IEnumerable<Bitacora> GetAll()
        {
            throw new NotImplementedException();
        }
        
    }
}
