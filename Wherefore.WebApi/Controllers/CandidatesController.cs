using Wherefore.Core.Entities;
using Wherefore.Core.Interfaces;
using Wherefore.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Microsoft.ApplicationInsights;

namespace Wherefore.WebApi.Controllers
{
    public class CandidatesController : BaseApiController
    {
        private readonly IRepository _repository;
        private TelemetryClient _telemetry;

        public CandidatesController(IRepository repository, TelemetryClient telemetry)
        {
            _repository = repository;
            _telemetry = telemetry;
        }

        // GET: api/candidates
        [HttpGet]
        public IActionResult List()
        {
            var items = _repository.List<Candidate>()
                            .Select(CandidateDTO.FromCandidate);
            return Ok(items);
        }

        // GET: api/candidates/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = CandidateDTO.FromCandidate(_repository.GetById<Candidate>(id));
            return Ok(item);
        }

        [HttpGet("match")]
        public IActionResult GetRandom()
        {
            var items = _repository.List<Candidate>()
                            .Select(CandidateDTO.FromCandidate);

            var rand = new Random();
            var item = items.ElementAt(rand.Next(0, items.Count()));

            _telemetry.TrackEvent("Match requested");

            return Ok(item);
        }

        // POST: api/candidates
        [HttpPost]
        public IActionResult Post([FromBody] CandidateDTO item)
        {
            var candidate = new Candidate()
            {
                Name = item.Name,
                Avatar = item.Avatar
            };
            _repository.Add(candidate);
            return Ok(CandidateDTO.FromCandidate(candidate));
        }

        [HttpPatch("{id:int}/complete")]
        public IActionResult Complete(int id)
        {
            var candidate = _repository.GetById<Candidate>(id);
            candidate.MarkMatched();
            _repository.Update(candidate);

            return Ok(CandidateDTO.FromCandidate(candidate));
        }
    }
}
