using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TalentCoach.Models.Domain;

namespace TalentCoach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RichtingenController : ControllerBase
    {
        private readonly IRichtingenRepository _repository;

        public RichtingenController(IRichtingenRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        ///     Geeft alle richtingen terug uit de databank
        /// </summary>
        /// <returns>
        ///		Lijst van richtingen
        /// </returns>		
        // GET api/richtingen
        [HttpGet]
        public ActionResult<List<Richting>> GetAll()
        {
            return _repository.GetAll();
        }

        /// <summary>
        ///     Geeft de gevonden richting terug op basis van id
        /// </summary>
        /// <param name="id">De id van de weer te geven richting</param>
        /// <returns>
        ///	Geldig id: Richting
        ///	
        /// Ongeldig id: NotFound met message
        /// </returns>	
        // GET api/richtingen/1
        [HttpGet("{id}", Name = "GetRichting")]
        public ActionResult<Richting> GetById(int id)
        {
            var result = _repository.GetRichting(id);
            return result ?? (ActionResult<Richting>)NotFound(new Dictionary<string, string>() { { "message", $"richting with id: {id} not found" } });
        }

        /// <summary>
        ///     Maakt een nieuwe richting
        /// </summary>
        /// <param name="item">Richting object voor in de databank op te slaan</param>
        /// <returns>
        /// CreatedAtRoute van GetRichting
        /// </returns>	
        // POST api/richtingen
        [HttpPost]
        public IActionResult Create(Richting item)
        {
            var result = _repository.AddRichting(item);
            var id = item.Id;
            return CreatedAtRoute("GetRichting", new { id = item.Id }, item);
        }

        /// <summary>
        ///     Wijzigt het richting object in de databank
        /// </summary>
        /// <param name="id">De id van de weer te geven richting</param>
        /// <param name="item">Het volledige (alle attributen) bijgewerkte richting object</param>
        /// <returns>
        ///	Geldig id: Richting
        ///	
        /// Ongeldig id: NotFound met message
        /// </returns>	
        // PUT api/richtingen/1
        [HttpPut("{id}")]
        public ActionResult<Richting> Update(int id, Richting item)
        {
            var result = _repository.UpdateRichting(id, item);
            return result ?? (ActionResult<Richting>)NotFound(new Dictionary<string, string>() { { "message", $"richting with id: {id} not found" } });
        }

        /// <summary>
        ///     Verwijdert het richting object in de databank
        /// </summary>
        /// <param name="id">De id van de te verwijderen richting</param>
        /// <returns>
        ///	Geldig id: NoContent
        ///	
        /// Ongeldig id: NotFound 
        /// </returns>	
        // DELETE api/richtingen
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            return result == null ? NotFound(new Dictionary<string, string>() { { "message", $"richting with id: {id} not found" } }) : (IActionResult)NoContent();
        }

    }
}