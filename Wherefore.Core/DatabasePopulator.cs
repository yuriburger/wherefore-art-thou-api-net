using Wherefore.Core.Entities;
using Wherefore.Core.Interfaces;
using System.Linq;

namespace Wherefore.Core
{
    public static class DatabasePopulator
    {
        public static int PopulateDatabase(IRepository candidateRepository)
        {
            if (candidateRepository.List<Candidate>().Count() >= 5) return 0;

            candidateRepository.Add(new Candidate
            {
                Name = "Ty",
                Avatar = "/assets/ty-profile.png"
            }); 
            candidateRepository.Add(new Candidate
            {
                Name = "Romeo",
                Avatar = "/assets/romeo-profile.png"
            });
            candidateRepository.Add(new Candidate
            {
                Name = "Mercutio",
                Avatar = "/assets/mercutio-profile.png"
            });

            return candidateRepository.List<Candidate>().Count;
        }
    }
}
