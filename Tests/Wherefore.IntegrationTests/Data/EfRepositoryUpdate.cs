using Wherefore.Core.Entities;
using Wherefore.UnitTests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Wherefore.IntegrationTests.Data
{
    public class EfRepositoryUpdate : BaseEfRepoTestFixture
    {
        [Fact]
        public void UpdatesItemAfterAddingIt()
        {
            // add an item
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var item = new CandidateBuilder().Name(initialName).Build();

            repository.Add(item);

            // detach the item so we get a different instance
            _dbContext.Entry(item).State = EntityState.Detached;

            // fetch the item and update its title
            var newItem = repository.List<Candidate>()
                .FirstOrDefault(i => i.Name == initialName);
            Assert.NotNull(newItem);
            Assert.NotSame(item, newItem);
            var newName = Guid.NewGuid().ToString();
            newItem.Name = newName;

            // Update the item
            repository.Update(newItem);
            var updatedItem = repository.List<Candidate>()
                .FirstOrDefault(i => i.Name == newName);

            Assert.NotNull(updatedItem);
            Assert.NotEqual(item.Name, updatedItem.Name);
            Assert.Equal(newItem.Id, updatedItem.Id);
        }
    }
}
