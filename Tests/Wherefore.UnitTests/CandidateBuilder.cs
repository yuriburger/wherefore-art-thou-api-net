using Wherefore.Core.Entities;

namespace Wherefore.UnitTests
{
    // Learn more about test builders:
    // https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    public class CandidateBuilder
    {
        private Candidate _candidate = new Candidate();

        public CandidateBuilder Id(int id)
        {
            _candidate.Id = id;
            return this;
        }

        public CandidateBuilder Name(string name)
        {
            _candidate.Name = name;
            return this;
        }

        public CandidateBuilder Avatar(string avatar)
        {
            _candidate.Avatar = avatar;
            return this;
        }

        public CandidateBuilder WithDefaultValues()
        {
            _candidate = new Candidate() 
            { 
                Id = 1, 
                Name = "Ty", 
                Avatar = "/assets/tybalt-profile.png", 
                Props = "short-tempered;ambitious" 
            };

            return this;
        }

        public Candidate Build() => _candidate;
    }
}
