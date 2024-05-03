using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;

namespace CLINICAL.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _contenxt;
        public IGenericRepository<Analysis> Analysis { get; }

        public IExamRepository Exam {  get; }

        public IPatientRepository Patient { get; }

        public UnitOfWork(IGenericRepository<Analysis> analysis, ApplicationDbContext contenxt)
        {
            Analysis = analysis;
            _contenxt = contenxt;
            Exam = new ExamRepository(_contenxt);
            Patient = new PatientRepository(_contenxt);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
