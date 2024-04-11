using AutoMapper;
using CLINICAL.Application.DTOS.Analysis.Response;
using CLINICAL.Application.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetALLQuery
{
    public class GetAllAnalysisHandler : IRequestHandler<GetALLAnalysisQuery, BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>>
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;

        public GetAllAnalysisHandler(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>> Handle(GetALLAnalysisQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllAnalysisResponseDto>>();

            try
            {
                var analysis = await _analysisRepository.ListAnalysis();

                if (analysis is not null)
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<IEnumerable<GetAllAnalysisResponseDto>>(analysis);
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;   
            }

            return response;
        }
    }
}
