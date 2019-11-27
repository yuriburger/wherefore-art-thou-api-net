using Wherefore.Core.Entities;
using Wherefore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Wherefore.WebApi
{
    public static class SeedData
    {
        public static readonly Candidate Candidate1 = new Candidate
        {
            Name = "Ty",    
            Avatar = "/assets/tybalt-profile.png",
            Props = "short-tempered;ambitious"
        };
        public static readonly Candidate Candidate2 = new Candidate
        {
            Name = "Romeo",
            Avatar = "/assets/romeo-profile.png",
            Props = "handsome;romantic" 
        };
        public static readonly Candidate Candidate3 = new Candidate
        {
            Name = "Mercutio",
            Avatar = "/assets/mercutio-profile.png",
            Props = "violent"
        };
        public static readonly Candidate Candidate4 = new Candidate
        {
            Name = "Benvo",
            Avatar = "/assets/benvolio-profile.png",
            Props = "strong"
        };
        public static readonly Candidate Candidate5 = new Candidate
        {
            Name = "The Fry",
            Avatar = "/assets/friar-profile.png",
            Props = "helpful"
        };
        public static readonly Candidate Candidate6 = new Candidate
        {
            Name = "The Count",
            Avatar = "/assets/paris-profile.png",
            Props = "wealthy"
        };
        public static readonly Candidate Candidate7 = new Candidate
        {
            Name = "The Nurse",
            Avatar = "/assets/nurse-profile.png",
            Props = "active"
        };

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
            {
                // Look for any candidates.
                if (dbContext.Candidates.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);
            }
        }
        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.Candidates)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();
            dbContext.Candidates.Add(Candidate1);
            dbContext.Candidates.Add(Candidate2);
            dbContext.Candidates.Add(Candidate3);
            dbContext.Candidates.Add(Candidate4);
            dbContext.Candidates.Add(Candidate5);
            dbContext.Candidates.Add(Candidate6);
            dbContext.Candidates.Add(Candidate7);

            dbContext.SaveChanges();
        }
    }
}
