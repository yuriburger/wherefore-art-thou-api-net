using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wherefore.Core.Entities;

namespace Wherefore.WebApi.Models
{
    public class CandidateDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Props { get; set; } 
        public bool IsMatched { get; private set; }

        public static CandidateDTO FromCandidate(Candidate item)
        {
            return new CandidateDTO()
            {
                Id = item.Id,
                Name = item.Name,
                Avatar = item.Avatar,
                Props = item.Props,
                IsMatched = item.IsMatched
            };
        }
    }
}
