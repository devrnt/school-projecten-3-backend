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
    public class WerkspreukenController : ControllerBase
    {
        private readonly IWerkspreukenRepository _repository;

        public WerkspreukenController(IWerkspreukenRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        ///     Geeft alle werkspreuken terug uit de databank
        /// </summary>
        /// <returns>
        ///		Lijst van activiteiten
        /// </returns>		
        // GET api/werkspreuken
        [HttpGet]
        public ActionResult<List<Werkspreuk>> GetAll()
        {
            return _repository.GetAll();
        }

        /// <summary>
        ///     Geeft de gevonden werkspreuk terug op basis van id
        /// </summary>
        /// <param name="id">De id van de weer te geven werkspreuk</param>
        /// <returns>
        ///	Geldig id: Werkspreuk
        ///	
        /// Ongeldig id: NotFound met message
        /// </returns>	
        // GET api/werkspreuken/1
        [HttpGet("{id}", Name = "GetWerkspreuk")]
        public ActionResult<Werkspreuk> GetById(int id)
        {

            var result = _repository.GetWerkspreuk(id);
            return result ?? (ActionResult<Werkspreuk>)NotFound(new Dictionary<string, string>() { { "message", $"werkspreuk with id: {id} not Found" } });
        }

        /// <summary>
        ///     Geeft de gevonden werkspreuk terug op basis van de meegeven schoolweek
        /// </summary>
        /// <param name="week">Geeft de werkspreuk gebasseerd op de week</param>
        /// <returns>
        ///	Geldig id: Werkspreuk
        ///	
        /// Ongeldig id: NotFound met message
        /// </returns>	
        // GET api/werkspreuken/week/1
        [HttpGet("week/{week}")]
        public ActionResult<Werkspreuk> GetByWeek(int week)
        {

            var result = _repository.GetByWeek(week);
            return result ?? (ActionResult<Werkspreuk>)NotFound(new Dictionary<string, string>() { { "message", $"No werkspreuk found for week {week}" } });
        }

    }
}