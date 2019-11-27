using Wherefore.Core.Entities;
using Wherefore.UnitTests;
using System.Linq;
using Xunit;

namespace Wherefore.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {

        [Fact]
        public void AddsItemAndSetsId()
        {
            var repository = GetRepository();
            var item = new CandidateBuilder().Build();

            repository.Add(item);

            var newItem = repository.List<Candidate>().FirstOrDefault();

            Assert.Equal(item, newItem);
            Assert.True(newItem?.Id > 0);
        }
    }
}
