//using System.Threading.Tasks;
//using ATSSystem.Application.Candidates.Queries.GetCandidates;
//using ATSSystem.Domain.Entities;
//using FluentAssertions;
//using NUnit.Framework;
//using static ATSSystem.Application.IntegrationTests.Testing;

//namespace ATSSystem.Application.IntegrationTests.Candidates.Queries
//{
//    public class GetAllCandidatesTests : TestBase
//    {
//        [Test]
//        public async Task ShouldReturnAllCandidates()
//        {
            
//            await AddAsync(new Candidate
//            {
//                Name = "Manisa",
//            });

//            var query = new GetAllCandidatesQuery();

//            var result = await SendAsync(query);

//            result.Should().NotBeNull();
//            result.Succeeded.Should().BeTrue();
//            result.Data.Count.Should().BeGreaterThan(0);
//        }
//    }
//}