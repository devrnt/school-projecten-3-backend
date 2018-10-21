using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TalentCoach.Models.Domain;

namespace TalentCoach.Controllers {
	[Route("api/[controller]")]
	[ApiController]
	public class LeerlingenController : ControllerBase {
		private readonly ILeerlingenRepository _repository;

		public LeerlingenController(ILeerlingenRepository repository) {
			_repository = repository;
		}

		/// <summary>
		///     Geeft alle leerlingen terug uit de databank
		/// </summary>
		/// <returns>
		///		Lijst van leerlingen
		/// </returns>		
		// GET api/leerlingen
		[HttpGet]
		public ActionResult<List<Leerling>> GetAll() {
			return _repository.GetAll();
		}

		/// <summary>
		///     Geeft de gevonden leerling terug op basis van id
		/// </summary>
		/// <param name="id">De id van de weer te geven leerling</param>
		/// <returns>
		///	Geldig id: Leerling
		///	
		/// Ongeldig id: NotFound met message
		/// </returns>	
		// GET api/leerlingen/1
		[HttpGet("{id}", Name = "GetLeerling")]
		public ActionResult<Leerling> GetById(int id) {
			var result = _repository.GetLeerling(id);
			return result ?? (ActionResult<Leerling>)NotFound(new Dictionary<string, string>() { { "message", $"leerling with id: {id} not found" } });
		}

		/// <summary>
		///     Maakt een nieuwe leerling
		/// </summary>
		/// <param name="item">Leerling object voor in de databank op te slaan</param>
		/// <returns>
		/// CreatedAtRoute van GetLeerling
		/// </returns>	
		// POST api/leerlingen
		[HttpPost]
		public IActionResult Create(Leerling item) {
			var result = _repository.AddLeerling(item);
			var id = item.Id;
			return CreatedAtRoute("GetLeerling", new { id = item.Id }, item);
		}

		/// <summary>
		///     Wijzigt het leerling object in de databank
		/// </summary>
		/// <param name="id">De id van de weer te geven leerling</param>
		/// <param name="item">Het volledige (alle attributen) bijgewerkte leerling object</param>
		/// <returns>
		///	Geldig id: Leerling
		///	
		/// Ongeldig id: NotFound met message
		/// </returns>	
		// PUT api/leerlingen/1
		[HttpPut("{id}")]
		public ActionResult<Leerling> Update(int id, Leerling leerling) {
			var result = _repository.UpdateLeerling(id, leerling);
			return result ?? (ActionResult<Leerling>)NotFound(new Dictionary<string, string>() { { "message", $"leerling with id: {id} not found" } });
		}

		/// <summary>
		///     Verwijdert het leerling object in de databank
		/// </summary>
		/// <param name="id">De id van de te verwijderen leerling</param>
		/// <returns>
		///	Geldig id: NoContent
		///	
		/// Ongeldig id: NotFound 
		/// </returns>	
		// DELETE api/leerlingen
		[HttpDelete("{id}")]
		public IActionResult Delete(int id) {
			var result = _repository.Delete(id);
			return result == null ? NotFound(new Dictionary<string, string>() { { "message", $"leerling with id: {id} not found" } }) : (IActionResult)NoContent();
		}

	}
}