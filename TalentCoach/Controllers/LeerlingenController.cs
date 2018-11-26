using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TalentCoach.Models.Domain;

namespace TalentCoach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeerlingenController : ControllerBase
    {
        private readonly ILeerlingenRepository _leerlingRepository;
        private readonly ILeerlingCompetentieRepository _competentieRepository;

        public LeerlingenController(ILeerlingenRepository leerlingrepository,ILeerlingCompetentieRepository competentieRepository)
        {
            _leerlingRepository = leerlingrepository;
            _competentieRepository = competentieRepository;
        }

        /// <summary>
        ///     Geeft alle leerlingen terug uit de databank
        /// </summary>
        /// <returns>
        ///		Lijst van leerlingen
        /// </returns>		
        // GET api/leerlingen
        [HttpGet]
        public ActionResult<List<Leerling>> GetAll()
        {
            return _leerlingRepository.GetAll();
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
        public ActionResult<Leerling> GetById(int id)
        {
            var result = _leerlingRepository.GetLeerling(id);
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
        public IActionResult Create(Leerling item)
        {
            var result = _leerlingRepository.AddLeerling(item);
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
        public ActionResult<Leerling> Update(int id, Leerling leerling)
        {
            ActionResult<Leerling> result = null;
            try
            {
                result = _leerlingRepository.UpdateLeerling(id, leerling);
            }
            catch (Exception e)
            {
                result = (ActionResult<Leerling>)NotFound(new Dictionary<string, string>() { { "message", $"exception: {e.Message} {e.StackTrace}" } });
            }
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
        public IActionResult Delete(int id)
        {
            var result = _leerlingRepository.Delete(id);
            return result == null ? NotFound(new Dictionary<string, string>() { { "message", $"leerling with id: {id} not found" } }) : (IActionResult)NoContent();
        }

        /// <summary>
        ///     Geeft de hoofd- en deelcompetenties van een gevonden leerling terug op basis van id
        /// </summary>
        /// <param name="id">De id van de leerling waaran de competenties toe behoren</param>
        /// <returns>
        /// Geldig id: Leerling
        /// 
        /// Ongeldig id: NotFound met message
        /// </returns>  
        // GET api/leerlingen/1/competenties
        [HttpGet("{id}/competenties", Name = "GetLeerlingCompetenties")]
        public ActionResult<List<LeerlingHoofdCompetentie>> GetLeerlingCompetenties(int id)
        {
            var result = _leerlingRepository.GetLeerlingCompetenties(id);
            return result ?? (ActionResult<List<LeerlingHoofdCompetentie>>)NotFound(new Dictionary<string, string>() { { "message", $"leerling with id: {id} not found" } });
        }

        /// <summary>
        ///    Voegt een nieuwe beooreling toe aan een leerlingDeelCompetentie
        /// </summary>
        /// <param name="competentieId">Het id van de leerlingDeelCompetentie</param>
        /// <param name="beoordeling">Het id van de leerling</param>
        /// <returns>
        /// CreatedAtRoute van GetLeerling
        /// </returns>  
        // POST api/leerlingen
        [HttpPost]
        public IActionResult Create(int competentieId, BeoordelingDeelCompetentie beoordeling)
        {
            var result = _.AddLeerling(item);
            var id = item.Id;
            return CreatedAtRoute("GetLeerling", new { id = item.Id }, item);
        }

    }
}