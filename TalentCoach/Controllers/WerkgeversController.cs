using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentCoach.Models.Domain;

namespace TalentCoach.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class WerkgeversController : ControllerBase {
        private readonly IWerkgeversRepository _repository;

        public WerkgeversController(IWerkgeversRepository repository) {
            _repository = repository;
        }

        /// <summary>
        ///     Geeft alle werkgevers terug uit de databank
        /// </summary>
        /// <returns>
        ///		Lijst van werkgevers
        /// </returns>		
        // GET api/werkgevers
        [HttpGet]
        public ActionResult<List<Werkgever>> GetAll() => _repository.GetAll();

        /// <summary>
        ///     Geeft de gevonden werkgevers terug op basis van id
        /// </summary>
        /// <param name="id">De id van de weer te geven werkgever</param>
        /// <returns>
        ///	Geldig id: Werkgever
        ///	
        /// Ongeldig id: NotFound met message
        /// </returns>	
        // GET api/werkgevers/1
        [HttpGet("{id}", Name = "GetWerkgever")]
        public ActionResult<Werkgever> GetById(int id) {
            var result = _repository.GetWerkgever(id);
            return result ?? (ActionResult<Werkgever>)NotFound(new Dictionary<string, string>() { { "message", $"werkgever with id: {id} not found" } });
        }

        /// <summary>
        ///     Maakt een nieuwe werkgever
        /// </summary>
        /// <param name="item">Werkgever object voor in de databank op te slaan</param>
        /// <returns>
        /// CreatedAtRoute van GetWerkgever
        /// </returns>	
        // POST api/werkgevers
        [HttpPost]
        public IActionResult Create(Werkgever wg) {
            var result = _repository.AddWerkgever(wg);
            var id = wg.Id;
            return CreatedAtRoute("GetWerkgever", new { id = wg.Id }, wg);
        }

        /// <summary>
        ///     Wijzigt het werkgevers object in de databank
        /// </summary>
        /// <param name="id">De id van de weer te geven werkgever</param>
        /// <param name="item">Het volledige (alle attributen) bijgewerkte werkgevers object</param>
        /// <returns>
        ///	Geldig id: Werkgever
        ///	
        /// Ongeldig id: NotFound met message
        /// </returns>	
        // PUT api/werkgevers/1
        [HttpPut("{id}")]
        public ActionResult<Werkgever> Update(int id, Werkgever wg) {
            var result = _repository.UpdateWerkgever(id, wg);
            return result ?? (ActionResult<Werkgever>)NotFound(new Dictionary<string, string>() { { "message", $"werkgever with id: {id} not found" } });
        }

        /// <summary>
        ///     Verwijdert het werkgevers object in de databank
        /// </summary>
        /// <param name="id">De id van de te verwijderen werkgever</param>
        /// <returns>
        ///	Geldig id: NoContent
        ///	
        /// Ongeldig id: NotFound 
        /// </returns>	
        // DELETE api/werkgevers
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            var result = _repository.Delete(id);
            return result == null ? NotFound(new Dictionary<string, string>() { { "message", $"werkgever with id: {id} not found" } }) : (IActionResult)NoContent();
        }

    }
}