using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Persistence.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext   _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExecAsync(string storeProcedure, object parameters)
        {
            using (var con = _context.CreateConnection)
            {
                var objParam = new DynamicParameters(parameters);
                var recordAffected = await con
                    .ExecuteAsync(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure);

                return recordAffected > 0;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(string storeProcedure)
        {
            using (var con = _context.CreateConnection)
            {
                return await con
                    .QueryAsync<T>(storeProcedure,commandType: CommandType.StoredProcedure);
            } 
        }

        public async Task<T> GetByIdAsync(string storeProcedure, object parameter)
        {
            using (var con = _context.CreateConnection)
            {
                var parameters = new DynamicParameters(parameter);
                return (await con
                    .QuerySingleOrDefaultAsync<T>(storeProcedure, param: parameters, commandType: CommandType.StoredProcedure))!;
            }
        }
    }
}
