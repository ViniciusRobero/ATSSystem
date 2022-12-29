using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Application.Candidates.Commands.Create;
using ATSSystem.Application.Candidates.Commands.Delete;
using ATSSystem.Application.Candidates.Commands.Update;
using ATSSystem.Application.Candidates.Queries.GetCandidates;
using ATSSystem.Application.Candidates.Queries.GetCandidateById;
using ATSSystem.Application.Common.Models;
using ATSSystem.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ATSSystem.Api.Controllers
{
    /// <summary>
    /// Candidates
    /// </summary>
    public class CandidatesController : BaseApiController
    {
        /// <summary>
        /// Get all candidates
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<CandidatesDto>>>> GetAllCandidates(CancellationToken cancellationToken)
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(new GetAllCandidatesQuery(), cancellationToken));
        }

        /// <summary>
        /// Get candidate by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<CandidatesDto>>> GetCandidateById(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCandidateByIdQuery { CandidateId = id }, cancellationToken));
        }

        /// <summary>
        /// Create candidate
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<CandidatesDto>>> Create(CreateCandidateCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Update candidate
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<ServiceResult<CandidatesDto>>> Update(UpdateCandidateCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Delete candidate by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResult<CandidatesDto>>> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteCandidateCommand { Id = id }, cancellationToken));
        }
    }
}