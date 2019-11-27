using Wherefore.Core.Entities;
using Wherefore.Core.Events;
using System.Linq;
using Xunit;

namespace Wherefore.UnitTests.Core.Entities
{
    public class CandidateMarkMatched
    {
        [Fact]
        public void SetsIsMatchedToTrue()
        {
            var item = new CandidateBuilder()
                .WithDefaultValues()
                .Build();

            item.MarkMatched();

            Assert.True(item.IsMatched);
        }

        [Fact]
        public void RaisesCandidateMatchedEvent()
        {
            var item = new CandidateBuilder().Build();

            item.MarkMatched();

            Assert.Single(item.Events);
            Assert.IsType<CandidateMatchedEvent>(item.Events.First());
        }
    }
}
