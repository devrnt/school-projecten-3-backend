using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class ActiviteitenController : ControllerBase {
		private readonly IActiviteitenRepository _repository;

		public ActiviteitenController(IActiviteitenRepository repository) {
			_repository = repository;
		}

		/// <summary>
		///     Geeft alle activiteiten terug uit de databank
		/// </summary>
		/// <returns>
		///		Lijst van activiteiten
		/// </returns>		
		// GET api/activiteiten
		[HttpGet]
		public ActionResult<List<Activiteit>> GetAll() {
			return _repository.GetAll();
		}

		/// <summary>
		///     Geeft de gevonden activiteit terug op basis van id
		/// </summary>
		/// <param name="id">De id van de weer te geven activiteit</param>
		/// <returns>
		///	Geldig id: Activiteit
		///	
		/// Ongeldig id: NotFound met message
		/// </returns>	
		// GET api/activiteiten/1
		[HttpGet("{id}", Name = "GetActiviteit")]
		public ActionResult<Activiteit> GetById(int id) {

			var result = _repository.GetActiviteit(id);
			return result ?? (ActionResult<Activiteit>)NotFound(new Dictionary<string, string>() { { "message", $"activiteit with id: {id} not Found" } });
		}

		/// <summary>
		///     Maakt een nieuwe activiteit
		/// </summary>
		/// <param name="item">Activiteit object voor in de databank op te slaan</param>
		/// <returns>
		/// CreatedAtRoute van GetActiviteit
		/// </returns>	
		// POST api/activiteiten
		[HttpPost]
		public IActionResult Create(Activiteit item) {
			var result = _repository.AddActiviteit(item);
			var id = item.Id;
			return CreatedAtRoute("GetActiviteit", new { id = item.Id }, item);
		}

		/// <summary>
		///     Wijzigt het activiteit object in de databank
		/// </summary>
		/// <param name="id">De id van de weer te geven activiteit</param>
		/// <param name="item">Het volledige (alle attributen) bijgewerkte activiteit object</param>
		/// <returns>
		///	Geldig id: Activiteit
		///	
		/// Ongeldig id: NotFound met message
		/// </returns>	
		// PUT api/activieiten/1
		[HttpPut("{id}")]
		public ActionResult<Activiteit> Update(int id, Activiteit item) {
			var result = _repository.UpdateActiviteit(id, item);
			return result ?? (ActionResult<Activiteit>)NotFound(new Dictionary<string, string>() { { "message", $"activiteit with id: {id} not Found" } });
		}

		/// <summary>
		///     Wijzigt het activiteit object in de databank
		/// </summary>
		/// <param name="id">De id van de te verwijderen activiteit</param>
		/// <returns>
		///	Geldig id: NoContent
		///	
		/// Ongeldig id: NotFound 
		/// </returns>	
		// DELETE api/activiteiten
		[HttpDelete("{id}")]
		public IActionResult Delete(int id) {
			var result = _repository.Delete(id);
			return result == null ? NotFound(new Dictionary<string, string>() { { "message", $"activiteit with id: {id} not Found" } }) : (IActionResult)NoContent();
		}
	}
}