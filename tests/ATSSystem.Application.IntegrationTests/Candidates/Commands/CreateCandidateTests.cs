using System;
using System.Threading.Tasks;
using ATSSystem.Application.Candidates.Commands.Create;
using ATSSystem.Application.Common.Exceptions;
using ATSSystem.Domain.Entities;
using FluentAssertions;
using FluentAssertions.Extensions;
using NUnit.Framework;
using static ATSSystem.Application.IntegrationTests.Testing;

namespace ATSSystem.Application.IntegrationTests.Candidates.Commands
{
    public class CreateCandidateTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateCandidateCommand("Norman", "343434343");

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();

        }

        [Test]
        public async Task ShouldRequireUniqueName()
        {
            
            await SendAsync(new CreateCandidateCommand( "Jaqueline", "1546545645656" ));

            var command = new CreateCandidateCommand( "Joaquim", "48855856465456");

            await FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateCandidate()
        {

            var command = new CreateCandidateCommand( "Geremias", "54454454545");

            var result = await SendAsync(command);

            var list = await FindAsync<Candidate>(result.Data.Id);

            list.Should().NotBeNull();
            list.Name.Should().Be(command.Name);
            list.Document.Should().Be(command.Document);
        }
    }
}
