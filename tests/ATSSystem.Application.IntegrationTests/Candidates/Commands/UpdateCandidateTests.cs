using System;
using System.Threading.Tasks;
using ATSSystem.Application.Candidates.Commands.Create;
using ATSSystem.Application.Candidates.Commands.Update;
using ATSSystem.Application.Common.Exceptions;
using ATSSystem.Domain.Entities;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using static ATSSystem.Application.IntegrationTests.Testing;

namespace ATSSystem.Application.IntegrationTests.Candidates.Commands
{
    public class UpdateCandidateTests : TestBase
    {
        [Test]
        public void ShouldRequireValidCandidateId()
        {
            var command = new UpdateCandidateCommand
            {
                Id = 99,
                Name = "Kayseri"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldRequireUniqueName()
        {
            
            var candidate = await SendAsync(new CreateCandidateCommand("Jaqueline", "15433645656"));

            await SendAsync(new CreateCandidateCommand("Diniz", "1546545645656"));

            var command = new UpdateCandidateCommand
            {
                Id = candidate.Data.Id,
                Name = "Denizli"
            };

            FluentActions.Invoking(() =>
                    SendAsync(command))
                .Should().ThrowAsync<ValidationException>().Where(ex => ex.Errors.ContainsKey("Name")).Result
                .And.Errors["Name"].Should().Contain("The specified candidate already exists. If you just want to activate the candidate leave the name field blank!");
        }

        [Test]
        public async Task ShouldUpdateCandidate()
        {
            var result = await SendAsync(new CreateCandidateCommand("Geremias", "1546545645656"));

            var command = new UpdateCandidateCommand
            {
                Id = result.Data.Id,
                Name = "Jones"
            };

            await SendAsync(command);

            var candidate = await FindAsync<Candidate>(result.Data.Id);

            candidate.Name.Should().Be(command.Name);
        }
    }
}
