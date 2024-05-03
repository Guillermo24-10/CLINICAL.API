using CLINICAL.Application.DTOS.Exam.Response;
using CLINICAL.Application.Interfaces.Interfaces;
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
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private readonly ApplicationDbContext _context;

        public ExamRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storeProcedure)
        {
            using (var con = _context.CreateConnection)
            {
                var exams = await con.QueryAsync<GetAllExamResponseDto>(storeProcedure, commandType: CommandType.StoredProcedure);
                
                return exams;
            }
        }
    }
}
