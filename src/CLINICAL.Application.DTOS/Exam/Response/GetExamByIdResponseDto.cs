using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.DTOS.Exam.Response
{
    public class GetExamByIdResponseDto
    {
        public int ExamId { get; set; }
        public string? Name { get; set; }
        public int? AnalysisId { get; set; }
    }
}
