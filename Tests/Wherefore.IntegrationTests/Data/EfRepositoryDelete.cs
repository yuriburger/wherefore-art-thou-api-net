using Wherefore.Core.Entities;
using Wherefore.UnitTests;
using System;
using Xunit;

namespace Wherefore.IntegrationTests.Data
{
    public class EfRepositoryDelete : BaseEfRepoTestFixture
    {
        [Fact]
        public void DeletesItemAfterAddingIt()
        {
            // add an item
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var item = new CandidateBuilder().Name(initialName).Build();
            repository.Add(item);

            // delete the item
            repository.Delete(item);

            // verify it's no longer there
            Assert.DoesNotContain(repository.List<Candidate>(),
                i => i.Name == initialName);
        }
    }
}
