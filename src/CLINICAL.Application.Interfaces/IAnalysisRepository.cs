using CLINICAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.Interfaces
{
    public interface IAnalysisRepository
    {
        Task<IEnumerable<Analysis>> ListAnalysis();
        Task<Analysis> AnalysisById(int id);
        Task<bool> AnalysisRegister(Analysis analysis);
        Task<bool> AnalysisEdit(Analysis analysis);
    }
}
