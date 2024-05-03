using AutoMapper;
using CLINICAL.Application.DTOS.Patient.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constantes;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetByIdQuery
{
    public class GetPatientByIdHandler : IRequestHandler<GetPatientByIdQuery, BaseResponse<GetPatientByIdResponseDto>>
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public GetPatientByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetPatientByIdResponseDto>> Handle(GetPatientByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetPatientByIdResponseDto>();

            try
            {
                var patient = await _unitOfWork.Patient.GetByIdAsync(StoredProcedures.uspPatientById, request);

                if (patient == null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetPatientByIdResponseDto>(patient);
                response.Message = GlobalMessage.MESSAGE_QUERY;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
