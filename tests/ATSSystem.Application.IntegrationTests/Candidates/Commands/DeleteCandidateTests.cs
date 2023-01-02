using System;
using System.Threading.Tasks;
using ATSSystem.Application.Candidates.Commands.Create;
using ATSSystem.Application.Candidates.Commands.Delete;
using ATSSystem.Application.Common.Exceptions;
using ATSSystem.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using static ATSSystem.Application.IntegrationTests.Testing;

namespace ATSSystem.Application.IntegrationTests.Candidates.Commands
{
    public class DeleteCandidateTests : TestBase
    {
        [Test]
        public void ShouldRequireValidCandidateId()
        {
            var command = new DeleteCandidateCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteCandidate()
        {

            var candidate = await SendAsync(new CreateCandidateCommand("Jaqueline", "343434343", DateTime.Now, "Teste", "Senior", "Developer"));

            await SendAsync(new DeleteCandidateCommand
            {
                Id = candidate.Data.Id
            });

            var list = await FindAsync<Candidate>(candidate.Data.Id);

            list.Should().BeNull();
        }
    }
}
