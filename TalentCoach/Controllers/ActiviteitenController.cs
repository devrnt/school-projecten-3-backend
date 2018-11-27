using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiviteitenController : ControllerBase
    {
        private readonly IHoofdCompetentieRepository _repository;

        public ActiviteitenController(IHoofdCompetentieRepository repository)
        {
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
        public ActionResult<List<HoofdCompetentie>> GetAll()
        {
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
        public ActionResult<HoofdCompetentie> GetById(int id)
        {

            var result = _repository.GetActiviteit(id);
            return result ?? (ActionResult<HoofdCompetentie>)NotFound(new Dictionary<string, string>() { { "message", $"activiteit with id: {id} not Found" } });
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
        public IActionResult Create(HoofdCompetentie item)
        {
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
        public ActionResult<HoofdCompetentie> Update(int id, HoofdCompetentie item)
        {
            var result = _repository.UpdateActiviteit(id, item);
            return result ?? (ActionResult<HoofdCompetentie>)NotFound(new Dictionary<string, string>() { { "message", $"activiteit with id: {id} not Found" } });
        }

        /// <summary>
        ///     Verwijdert het activiteit object in de databank
        /// </summary>
        /// <param name="id">De id van de te verwijderen activiteit</param>
        /// <returns>
        ///	Geldig id: NoContent
        ///	
        /// Ongeldig id: NotFound 
        /// </returns>	
        // DELETE api/activiteiten
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            return result == null ? NotFound(new Dictionary<string, string>() { { "message", $"activiteit with id: {id} not Found" } }) : (IActionResult)NoContent();
        }
    }
}