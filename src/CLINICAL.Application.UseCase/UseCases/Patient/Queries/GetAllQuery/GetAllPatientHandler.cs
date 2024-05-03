using CLINICAL.Application.DTOS.Patient.Response;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constantes;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCases.Patient.Queries.GetAllQuery
{
    public class GetAllPatientHandler : IRequestHandler<GetAllPatientQuery, BaseResponse<IEnumerable<GetAllPatientResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllPatientResponseDto>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllPatientResponseDto>>();

            try
            {
                var patient = await _unitOfWork.Patient.GetAllPatients(StoredProcedures.uspPatientList);

                if (patient is not null)
                {
                    response.IsSuccess = true;
                    response.Data = patient;
                    response.Message = GlobalMessage.MESSAGE_QUERY;
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
