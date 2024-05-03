using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetALLQuery;
using CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CLINICAL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListAnalysis()
        {
            var response = await _mediator.Send(new GetALLAnalysisQuery());

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> AnalysisById(int id)
        {
            var response = await _mediator.Send(new GetAnalysisByIdQuery() { AnalysisId = id});

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> AnalysisRegister([FromBody] CreateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<ActionResult> AnalysisEdit([FromBody] UpdateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HttpDelete("Remove/{id:int}")]
        public async Task<IActionResult> AnalysisRemove(int id)
        {
            var response = await _mediator.Send(new DeleteAnalysisCommand () { AnalysisId = id });

            return Ok(response);    
        }

        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeState([FromBody] ChangeStateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
