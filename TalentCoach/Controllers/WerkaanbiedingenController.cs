using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalentCoach.Models.Domain;

namespace TalentCoach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WerkaanbiedingenController : ControllerBase
    {
        private readonly IWerkaanbiedingenRepository _repository;

        public WerkaanbiedingenController(IWerkaanbiedingenRepository repo)
        {
            _repository = repo;
        }

        /// <summary>
        ///     Geeft alle werkaanbiedingen terug uit de databank
        /// </summary>
        /// <returns>
        ///		Lijst van werkaanbiedingen
        /// </returns>		
        // GET api/werkaanbiedingen
        [HttpGet]
        public ActionResult<List<Werkaanbieding>> GetAll()
        {
            return _repository.GetAll();
        }

        /// <summary>
        ///     Geeft de gevonden werkaanbieding terug op basis van id
        /// </summary>
        /// <param name="id">De id van de weer te geven werkaanbieding</param>
        /// <returns>
        ///	Geldig id: Werkaanbieding
        ///	
        /// Ongeldig id: NotFound met message
        /// </returns>	
        // GET api/werkaanbiedingen/1
        [HttpGet("{id}", Name = "GetWerkaanbieding")]
        public ActionResult<Werkaanbieding> GetById(int id)
        {
            var result = _repository.GetWerkaanbieding(id);
            return result ?? (ActionResult<Werkaanbieding>)NotFound(new Dictionary<string, string>() { { "message", $"Werkaanbieding with id: {id} not found" } });
        }

        /// <summary>
        ///     Geeft een werkaanbieding terug die in zijn tags 1 van de meegegeven interesses bevat
        /// </summary>
        /// <param name="interesses">Interesses van de leerling</param>
        /// <returns>
        ///     Een werkaanbieding
        /// </returns>
        // GET api/werkaanbiedingen/interesseString
        [HttpGet("{interesses}", Name = "GetWerkaanbiedingByInteresses")]
        public ActionResult<Werkaanbieding> GetWerkaanbiedingByInteresses(string interesses)
        {
            var interessesList = interesses.Split(" ").ToList();
            var result = _repository.GetAll().FirstOrDefault(wa => interessesList.Any(i => i == wa.Tags));
            return result ?? (ActionResult<Werkaanbieding>)NotFound(new Dictionary<string, string>() { { "message", $"Werkaanbieding with tags: {interesses} not found" } });
        }

        /// <summary>
        ///     Maakt een nieuwe werkaanbieding
        /// </summary>
        /// <param name="item">Werkaanbieding object voor in de databank op te slaan</param>
        /// <returns>
        /// CreatedAtRoute van GetWerkaanbieding
        /// </returns>	
        // POST api/werkaanbiedingen
        [HttpPost]
        public IActionResult Create(Werkaanbieding wa)
        {
            var result = _repository.AddWerkaanbieding(wa);
            var id = wa.Id;
            return CreatedAtRoute("GetWerkaanbieding", new { id = wa.Id }, wa);
        }

        /// <summary>
        ///     Wijzigt het werkaanbieding object in de databank
        /// </summary>
        /// <param name="id">De id van de weer te geven werkaanbieding</param>
        /// <param name="item">Het volledige (alle attributen) bijgewerkte werkaanbieding object</param>
        /// <returns>
        ///	Geldig id: Werkaanbieding
        ///	
        /// Ongeldig id: NotFound met message
        /// </returns>	
        // PUT api/werkaanbiedingen/1
        [HttpPut("{id}")]
        public ActionResult<Werkaanbieding> Update(int id, Werkaanbieding wa)
        {
            var result = _repository.UpdateWerkaanbieding(id, wa);
            return result ?? (ActionResult<Werkaanbieding>)NotFound(new Dictionary<string, string>() { { "message", $"werkaanbieding with id: {id} not found" } });
        }

        /// <summary>
        ///     Verwijdert het werkaanbieding object in de databank
        /// </summary>
        /// <param name="id">De id van de te verwijderen werkaanbieding</param>
        /// <returns>
        ///	Geldig id: NoContent
        ///	
        /// Ongeldig id: NotFound 
        /// </returns>	
        // DELETE api/werkaanbiedingen
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _repository.Delete(id);
            return result == null ? NotFound(new Dictionary<string, string>() { { "message", $"werkaanbieding with id: {id} not found" } }) : (IActionResult)NoContent();
        }
    }
}