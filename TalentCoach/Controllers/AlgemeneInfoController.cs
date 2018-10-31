using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TalentCoach.Models.Domain;

namespace TalentCoach.Controllers
{
    [Route("api/algemene-info")]
    [ApiController]
    public class AlgemeneInfoController : ControllerBase
    {
        private readonly IAlgemeneInfoRepository _repository;

        public AlgemeneInfoController(IAlgemeneInfoRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        ///     Geeft alle algemene info terug uit de databank
        /// </summary>
        /// <returns>
        ///		Lijst van algemene info
        /// </returns>		
        // GET api/algemene-info
        [HttpGet]
        public ActionResult<List<AlgemeneInfo>> GetAll()
        {
            return _repository.GetAll();
        }


        /// <summary>
        ///     Geeft de gevonden algemene info terug op basis van id
        /// </summary>
        /// <param name="id">De id van de weer te geven algemene info</param>
        /// <returns>
        ///	Geldig id: Algemene info
        ///	
        /// Ongeldig id: NotFound met message
        /// </returns>	
        // GET api/algemeneinfo/1
        [HttpGet("{id}", Name = "GetAlgemeneInfo")]
        public ActionResult<AlgemeneInfo> GetById(int id)
        {
            var result = _repository.GetAlgemeneInfo(id);
            return result ?? (ActionResult<AlgemeneInfo>)NotFound(new Dictionary<string, string>() { { "message", $"algemene info with id: {id} not found" } });
        }

        /// <summary>
        ///     Maakt een nieuwe algemene info
        /// </summary>
        /// <param name="item">Algemene info object voor in de databank op te slaan</param>
        /// <returns>
        /// CreatedAtRoute van Get
        /// </returns>	
        // POST api/algemene-info
        [HttpPost]
        public IActionResult Create(AlgemeneInfo item)
        {
            var result = _repository.AddAlgemeneInfo(item);
            var id = item.Id;
            return CreatedAtRoute("GetAlgemeneInfo", new { id = item.Id }, item);
        }


        /// <summary>
        ///     Wijzigt het algemene info object in de databank
        /// </summary>
        /// <param name="id">De id van de weer te geven algemen info</param>
        /// <param name="item">Het volledige (alle attributen) bijgewerkte algemene info object</param>
        /// <returns>
        ///	Geldig id: Algemene Info
        ///	
        /// Ongeldig id: NotFound met message
        /// </returns>	
        // PUT api/algemene-info/1
        [HttpPut("{id}")]
        public ActionResult<AlgemeneInfo> Update(int id, AlgemeneInfo item)
        {
            var result = _repository.UpdateAlgemeneInfo(id, item);
            return result ?? (ActionResult<AlgemeneInfo>)NotFound(new Dictionary<string, string>() { { "message", $"algemene info with id: {id} not found" } });
        }

    }
}
