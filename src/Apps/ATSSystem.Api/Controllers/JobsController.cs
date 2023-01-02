using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ATSSystem.Application.Jobs.Commands.Create;
using ATSSystem.Application.Jobs.Commands.Delete;
using ATSSystem.Application.Jobs.Commands.Update;
using ATSSystem.Application.Jobs.Queries.GetJobs;
using ATSSystem.Application.Jobs.Queries.GetJobsById;
using ATSSystem.Application.Common.Models;
using ATSSystem.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ATSSystem.Api.Controllers
{
    /// <summary>
    /// Candidates
    /// </summary>
    public class JobsController : BaseApiController
    {
        /// <summary>
        /// Get all candidates
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<JobsDto>>>> GetAllJobs(CancellationToken cancellationToken)
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(new GetAllJobsQuery(), cancellationToken));
        }

        /// <summary>
        /// Get candidate by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<JobsDto>>> GetCandidateById(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetJobByIdQuery { JobId = id }, cancellationToken));
        }

        /// <summary>
        /// Create candidate
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<JobsDto>>> Create(CreateJobCommand command, CancellationToken cancellationToken)
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
        public async Task<ActionResult<ServiceResult<JobsDto>>> Update(UpdateJobCommand command, CancellationToken cancellationToken)
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
        public async Task<ActionResult<ServiceResult<JobsDto>>> Delete(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteJobCommand { Id = id }, cancellationToken));
        }
    }
}