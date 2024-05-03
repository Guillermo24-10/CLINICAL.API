using CLINICAL.Application.DTOS.Exam.Response;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interfaces.Interfaces
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        Task<IEnumerable<GetAllExamResponseDto>> GetAllExams(string storeProcedure);
    }
}
