using AutoMapper;
using CLINICAL.Application.Interfaces.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constantes;
using CLINICAL.Utilities.HelpersExtensions;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisHandler : IRequestHandler<CreateAnalysisCommand, BaseResponse<bool>>
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly CreateAnalysisValidator _validacion;

        public CreateAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper, CreateAnalysisValidator validacion)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validacion = validacion;
        }

        public async Task<BaseResponse<bool>> Handle(CreateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                
                var analysis = _mapper.Map<Entity.Analysis>(request);
                var paremeters = analysis.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Analysis.ExecAsync(StoredProcedures.uspAnalysisRegister, paremeters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessage.MESSAGE_SAVE;
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
