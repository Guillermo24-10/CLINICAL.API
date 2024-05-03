using CLINICAL.Application.DTOS.Patient.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using Dapper;
using System.Data;

namespace CLINICAL.Persistence.Repositories
{
    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetAllPatientResponseDto>> GetAllPatients(string storedProcedures)
        {
            var connection = _context.CreateConnection;
            var patients = await connection.QueryAsync<GetAllPatientResponseDto>(storedProcedures, commandType: CommandType.StoredProcedure);
            return patients;
        }
    }
}
