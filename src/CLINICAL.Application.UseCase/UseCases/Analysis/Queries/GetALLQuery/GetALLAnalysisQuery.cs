using CLINICAL.Application.DTOS.Analysis.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetALLQuery
{
    public class GetALLAnalysisQuery : IRequest<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>
    {
    }
}
