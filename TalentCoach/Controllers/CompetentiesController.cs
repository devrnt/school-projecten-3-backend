using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TalentCoach.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CompetentiesController : ControllerBase
    {
        private readonly ICompetentiesRepository _repository;

        public CompetentiesController(ICompetentiesRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        ///     Geeft alle competenties terug uit de databank
        /// </summary>
        /// <returns>
        ///		Lijst van competenties
        /// </returns>		
        [HttpGet]
        public ActionResult<List<Competentie>> GetAll()
        {
            return _repository.GetAll();
        }

        /// <summary>
        ///     Geeft de gevonden competentie terug op basis van id
        /// </summary>
        /// <param name="id">De id van de weer te geven competentie</param>
        /// <returns>
        ///	Geldig id: Competentie
        ///	
        /// Ongeldig id: NotFound met message
        /// </returns>	
        // GET api/competenties/1
        [HttpGet("{id}", Name = "GetCompetentie")]
        public ActionResult<Competentie> GetById(int id)
        {

            var result = _repository.GetCompetentie(id);
            return result ?? (ActionResult<Competentie>)NotFound(new Dictionary<string, string>() { { "message", $"competentie with id: {id} not Found" } });
        }

        /// <summary>
        ///     Maakt een nieuwe competentie
        /// </summary>
        /// <param name="item">Competentie object voor in de databank op te slaan</param>
        /// <returns>
        /// CreatedAtRoute van GetCompetentie
        /// </returns>	
        // POST api/competenties
        [HttpPost]
        public IActionResult Create(Competentie item)
        {
            var result = _repository.AddCompetentie(item);
            var id = item.Id;
            return CreatedAtRoute("GetCompetentie", new { id = item.Id }, item);
        }

        /// <summary>
        ///     Wijzigt het competentie object in de databank
        /// </summary>
        /// <param name="id">De id van de weer te geven competentie</param>
        /// <param name="item">Het volledige (alle attributen) bijgewerkte competentie object</param>
        /// <returns>
        ///	Geldig id: Competentie
        ///	
        /// Ongeldig id: NotFound met message
        /// </returns>	
        // If we would like to update just a part of the object (example: Beoordeling) 
        // we should use HttpPatch
        // PUT api/competenties/1
        [HttpPut("{id}")]
        public ActionResult<Competentie> Update(int id, Competentie item)
        {
            var result = _repository.UpdateCompetentie(id, item);
            return result ?? (ActionResult<Competentie>)NotFound(new Dictionary<string, string>() { { "message", $"competentie with id: {id} not Found" } });
        }

        /// <summary>
        ///     Verwijdert het competentie object in de databank
        /// </summary>
        /// <param name="id">De id van de te verwijderen competentie</param>
        /// <returns>
        ///	Geldig id: NoContent
        ///	
        /// Ongeldig id: NotFound 
        /// </returns>	
        // DELETE api/competenties
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            return result == null ? NotFound(new Dictionary<string, string>() { { "message", $"competentie with id: {id} not Found" } }) : (IActionResult)NoContent();
        }
    }
}
