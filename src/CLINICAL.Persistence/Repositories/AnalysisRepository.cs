using CLINICAL.Application.Interfaces;
using CLINICAL.Domain.Entities;
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
    public class AnalysisRepository : IAnalysisRepository
    {
        private readonly ApplicationDbContext _context;

        public AnalysisRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Analysis> AnalysisById(int id)
        {
            using (var connection = _context.CreateConnection)
            {
                var query = "uspAnalysisById";
                var parameters = new DynamicParameters();
                parameters.Add("@AnalysisId", id);

                var analysis = await connection
                    .QuerySingleOrDefaultAsync<Analysis>(query, param: parameters, commandType: CommandType.StoredProcedure);

                return analysis!;
            }
        }

        public async Task<bool> AnalysisEdit(Analysis analysis)
        {
            using (var connection = _context.CreateConnection)
            {
                var query = "uspAnalysisEdit";
                var parameters = new DynamicParameters();
                parameters.Add("@AnalysisId", analysis.AnalysisId);
                parameters.Add("@Name", analysis.Name);

                var recordAffected = await connection
                    .ExecuteAsync(query,param: parameters, commandType: CommandType.StoredProcedure);

                return recordAffected > 0;
            }
        }

        public async Task<bool> AnalysisRegister(Analysis analysis)
        {
            using (var connection = _context.CreateConnection)
            {
                var query = "uspAnalysisRegister";
                var parameters = new DynamicParameters();
                parameters.Add("@Name", analysis.Name);
                parameters.Add("@State", 1);
                parameters.Add("@AuditCreateDate", DateTime.Now);

                var recordAffected = await connection
                    .ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);

                return recordAffected > 0;
            }
        }

        public async Task<IEnumerable<Analysis>> ListAnalysis()
        {
            using (var connection = _context.CreateConnection)
            {
                var query = "uspAnalysisList";

                var analysis = await connection.QueryAsync<Analysis>(query, commandType: CommandType.StoredProcedure);

                return analysis;
            }
        }
    }
}
