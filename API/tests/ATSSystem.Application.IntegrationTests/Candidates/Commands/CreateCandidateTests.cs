//using System;
//using System.Threading.Tasks;
//using ATSSystem.Application.Candidates.Commands.Create;
//using ATSSystem.Application.Common.Exceptions;
//using ATSSystem.Domain.Entities;
//using FluentAssertions;
//using FluentAssertions.Extensions;
//using NUnit.Framework;
//using static ATSSystem.Application.IntegrationTests.Testing;

//namespace ATSSystem.Application.IntegrationTests.Candidates.Commands
//{
//    public class CreateCandidateTests : TestBase
//    {
//        [Test]
//        public void ShouldRequireMinimumFields()
//        {
//            var command = new CreateCandidateCommand("Norman", "343434343", DateTime.Now, "Teste", "Senior", "Developer");

//            FluentActions.Invoking(() =>
//                SendAsync(command)).Should().ThrowAsync<ValidationException>();

//        }

//        [Test]
//        public async Task ShouldRequireUniqueName()
//        {
            
//            await SendAsync(new CreateCandidateCommand("Norman123", "23123123", DateTime.Now, "Teste2", "Senior", "Developer"));

//            var command = new CreateCandidateCommand("Norman2", "123213214424", DateTime.Now, "Teste2", "Junior", "Developer");

//            await FluentActions.Invoking(() =>
//                SendAsync(command)).Should().ThrowAsync<ValidationException>();
//        }

//        [Test]
//        public async Task ShouldCreateCandidate()
//        {

//            var command = new CreateCandidateCommand("Geremias", "343434343", DateTime.Now, "Teste", "Senior", "Developer");

//            var result = await SendAsync(command);

//            var list = await FindAsync<Candidate>(result.Data.Id);

//            list.Should().NotBeNull();
//            list.Name.Should().Be(command.Name);
//            list.Document.Should().Be(command.Document);
//        }
//    }
//}
