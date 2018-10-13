using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TalentCoach.Data;
using TalentCoach.Data.Repositories;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TalentCoach.Controllers {
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class CompetentiesController : ControllerBase {
		private readonly ICompetentiesRepository _repository;

		public CompetentiesController(ICompetentiesRepository repository) {
			_repository = repository;
		}

		// GET api/competenties
		[HttpGet]
		public ActionResult<List<Competentie>> GetAll() {
			return _repository.GetAll();
		}

		// GET api/competenties/1
		[HttpGet("{id}", Name = "GetCompetentie")]
		public ActionResult<Competentie> GetById(int id) {
			var result = _repository.GetCompetentie(id);
			return result == null ? (ActionResult<Competentie>)NotFound() : NoContent();
		}

		// POST api/competenties
		[HttpPost]
		public IActionResult Create(Competentie item) {
			_repository.AddCompetentie(item);
			_repository.SaveChanges();
			return CreatedAtRoute(nameof(GetById), new { id = item.Id }, item);
		}

		// If we would like to update just a part of the object (example: Beoordeling) 
		// we should use HttpPatch
		// PUT api/competenties/1
		[HttpPut("{id}")]
		public IActionResult Update(int id, Competentie item) {
			var result = _repository.UpdateCompetentie(id, item);
			if (result == null) {
				return NotFound();
			}

			_repository.SaveChanges();
			return NoContent();
		}

		// DELETE api/competenties
		[HttpDelete("{id}")]
		public IActionResult Delete(int id) {
			var result = _repository.Delete(id);
			if (result == null) {
				return NotFound();
			}
			_repository.SaveChanges();
			return NoContent();
		}
	}
}
