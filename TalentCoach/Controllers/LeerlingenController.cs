using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalentCoach.Models.Domain;

namespace TalentCoach.Controllers
{
    [Route("api/[controller]")]
    //    [Authorize(Roles = "Leerkracht")]
    [ApiController]
    public class LeerlingenController : ControllerBase
    {
        private readonly ILeerlingenRepository _leerlingRepository;
        private readonly ILeerlingCompetentieRepository _competentieRepository;
        private readonly ILeerlingWerkaanbiedingenRepository _werkaanbiedingRepository;
        private readonly IWerkgeversRepository _werkgeversRepository;

        public LeerlingenController(ILeerlingenRepository leerlingrepository, ILeerlingCompetentieRepository competentieRepository, ILeerlingWerkaanbiedingenRepository werkaanbiedingenRepository, IWerkgeversRepository werkgeversRepository)
        {
            _leerlingRepository = leerlingrepository;
            _competentieRepository = competentieRepository;
            _werkaanbiedingRepository = werkaanbiedingenRepository;
            _werkgeversRepository = werkgeversRepository;
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
        /// <param name="leerling">Het volledige (alle attributen) bijgewerkte leerling object</param>
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
        [HttpPost("deelcompetenties/beoordelen/{competentieId}")]
        public ActionResult<LeerlingDeelCompetentie> BeoordeelDeelCompetentie(int competentieId, BeoordelingDeelCompetentie beoordeling)
        {
            this._competentieRepository.BeoordeelDeelCompetentie(competentieId, beoordeling);
            var result = this._competentieRepository.GetDeelCompetentie(competentieId);
            return result ?? (ActionResult<LeerlingDeelCompetentie>)NotFound(new Dictionary<string, string>() { { "message", $"deelcompetentie with id: {competentieId} not found" } });
        }

        /// <summary>
        ///    Zet een deelcompetentie op behaald
        /// </summary>
        /// <param name="competentieId">Het id van de leerlingDeelCompetentie die wordtbehaald</param>
        /// <returns>
        /// CreatedAtRoute van GetLeerling
        /// </returns>  
        // POST api/leerlingen
        [HttpPost("deelcompetenties/behalen/{competentieId}")]
        public ActionResult<LeerlingDeelCompetentie> BehaalDeelCompetentie(int competentieId)
        {
            this._competentieRepository.BehaalDeelCompetentie(competentieId);
            var result = this._competentieRepository.GetDeelCompetentie(competentieId);
            return result ?? (ActionResult<LeerlingDeelCompetentie>)NotFound(new Dictionary<string, string>() { { "message", $"deelcompetentie with id: {competentieId} not found" } });
        }

        /// <summary>
        ///   like een werkaanbieding. Voegt een leerlingwerkaanbieding toe aan de bewaarde lijst
        /// </summary>
        /// <param name="leerlingId">Het id van de leerling</param>
        /// <param name="werkaanbiedingId">Het id van de te bewaren werkaanbieding</param>
        /// <returns>
        /// ActionResult LeerlingWerkaanbieding
        /// </returns>  
        // POST api/leerlingen/1/werkaanbiedingen/1/like
        [HttpPost("{leerlingId}/werkaanbiedingen/{werkaanbiedingId}/like")]
        public ActionResult<LeerlingWerkaanbieding> LikeWerkAanbieding(int leerlingId, int werkaanbiedingId)
        {
            var result = this._werkaanbiedingRepository.LikeWerkaanbiedingLeerling(leerlingId, werkaanbiedingId);
            return result ?? (ActionResult<LeerlingWerkaanbieding>)NotFound(new Dictionary<string, string>() { { "message", $"leerling with id: {leerlingId} or werkaanbieding with id: {werkaanbiedingId} not found" } });
        }


        /// <summary>
        ///   dislike een werkaanbieding. Voegt een leerlingwerkaanbieding toe aan de verwijderde lijst
        /// </summary>
        /// <param name="leerlingId">Het id van de leerling</param>
        /// <param name="werkaanbiedingId">Het id van de te verwijderen werkaanbieding</param>
        /// <returns>
        /// ActionResult LeerlingWerkaanbieding
        /// </returns>  
        // POST api/leerlingen/1/werkaanbiedingen/1/like
        [HttpPost("{leerlingId}/werkaanbiedingen/{werkaanbiedingId}/dislike")]
        public ActionResult<LeerlingWerkaanbieding> DislikeWerkAanbieding(int leerlingId, int werkaanbiedingId)
        {
            var result = this._werkaanbiedingRepository.DislikeWerkaanbiedingLeerling(leerlingId, werkaanbiedingId);
            return result ?? (ActionResult<LeerlingWerkaanbieding>)NotFound(new Dictionary<string, string>() { { "message", $"leerling with id: {leerlingId} or werkaanbieding with id: {werkaanbiedingId} not found" } });
        }

        /// <summary>
        ///   Geeft de meest interessante werkaanbieding terug op basis van de leerling zijn interesses
        /// </summary>
        /// <param name="leerlingId">Het id van de leerling</param>
        /// <returns>
        /// ActionResult LeerlingWerkaanbieding
        /// </returns>  
        // POST api/leerlingen/1/werkaanbiedingen/1/like
        [HttpGet("{leerlingId}/werkaanbiedingen/interessant")]
        public ActionResult<List<Werkaanbieding>> GeefInteressantsteWerkaanbieding(int leerlingId)
        {
            var result = this._werkaanbiedingRepository.GeefInteressantsteWerkaanbieding(leerlingId);
            if (result != null)
            {
                return result;
            }
            else
            {
                if (_leerlingRepository.GetAll().Exists(l => l.Id == leerlingId))
                {
                    return (ActionResult<List<Werkaanbieding>>)Ok(new Dictionary<string, string>() { { "message", $"Geen matching werkaanbiedingen gevonden" } });

                }
                return (ActionResult<List<Werkaanbieding>>)NotFound(new Dictionary<string, string>() { { "message", $"leerling with id: {leerlingId} not found" } });

            }
        }

        /// <summary>
        /// Kent een werkgever toe aan een leerling.
        /// </summary>
        /// <returns>De toegekende werkgever.</returns>
        /// <param name="id">Leerling id</param>
        /// <param name="werkgever">Werkgever object</param>
        /// <response code="200">Toegekende werkgever</response>
        /// <response code="404">Not Found object met message field</response>
        // POST api/leerlingen/1/werkgever
        [HttpPost("{id}/werkgever")]
        public ActionResult<Werkgever> WerkgeverToekennen(int id, Werkgever werkgever)
        {
            var leerling = _leerlingRepository.GetLeerling(id);
            if (leerling == null)
            {
                return NotFound(new { message = $"Geen leerling gevonden met id {id}" });
            }

            var toeTeKennenWerkgever = _werkgeversRepository.GetWerkgever(werkgever.Id);
            if (werkgever == null)
            {
                return NotFound(new { message = $"Geen werkgever gevonden met id {id}" });
            }

            leerling.Werkgever = toeTeKennenWerkgever;
            _leerlingRepository.SaveChanges();

            return werkgever;
        }

        /// <summary>
        /// Zet een reeds verwijderde werkaanbieding in de bewaarde, of omgekeerd.
        /// </summary>
        /// <returns>De gewijzigde leerlingWerkaanbieding</returns>
        /// <param name="leerlingId">Leerling Id</param>
        /// <param name="werkaanbiedingId">Werkaanbieding Id</param>
        /// <response code="200">Veranderde Werkaanbieding</response>
        /// <response code="404">Not Found object met message field</response>
        // POST api/leerlingen/1/werkaanbiedingen/1/undo
        [HttpPost("{leerlingId}/werkaanbiedingen/{werkaanbiedingId}/undo")]
        public ActionResult<LeerlingWerkaanbieding> VerwijderOfVoegToeWerkAanbieding(int leerlingId, int werkaanbiedingId)
        {
            var result = this._werkaanbiedingRepository.UndoLikeDislikeWerkaanbieding(leerlingId,werkaanbiedingId);
            if (result != null)
            {
                return result;
            }
            else
            {
                if (_leerlingRepository.GetAll().Exists(l => l.Id == leerlingId))
                {
                    return (ActionResult<LeerlingWerkaanbieding>)NotFound(new Dictionary<string, string>() { { "message", $"werkaanbieding with id: {werkaanbiedingId} not found" } });

                }
                return (ActionResult<LeerlingWerkaanbieding>)NotFound(new Dictionary<string, string>() { { "message", $"leerling with id: {leerlingId} not found" } });
            }
        }


        /// <summary>
        /// Voegt een intresse toe aan een leerling
        /// </summary>
        /// <returns>De nieuwe lijst van intresses van de leerling</returns>
        /// <param name="leerlingId">Leerling Id</param>
        /// <param name="interesse">De </param>
        /// <response code="200">Veranderde lijst van interesses</response>
        /// <response code="404">Not Found object met message field</response>
        // POST api/leerlingen/1/interesse/add
        [HttpPost("{leerlingId}/interesses/add")]
        public ActionResult<List<String>> AddInteresseLeerling(int leerlingId, Interesse interesse)
        {
            var result = this._leerlingRepository.AddIntresseToLeerling(leerlingId, interesse);
            if (result != null)
            {
                return result;
            }
            else
            {
                if (_leerlingRepository.GetAll().Exists(l => l.Id == leerlingId))
                {
                    return (ActionResult<List<String>>)NotFound(new Dictionary<string, string>() { { "message", $"Geen matching interesse gevonden: {interesse}" } });

                }
                return (ActionResult<List<String>>)NotFound(new Dictionary<string, string>() { { "message", $"leerling with id: {leerlingId} not found" } });
            }
        }

        /// <summary>
        /// Verwijdert een intresseuit een leerling
        /// </summary>
        /// <returns>De nieuwe lijst van intresses van de leerling</returns>
        /// <param name="leerlingId">Leerling Id</param>
        /// <param name="interesse">De </param>
        /// <response code="200">Veranderde lijst van interesses</response>
        /// <response code="404">Not Found object met message field</response>
        // POST api/leerlingen/1/interesse/add
        [HttpPost("{leerlingId}/interesses/delete")]
        public ActionResult<List<String>> RemoveInteresseLeerling(int leerlingId, Interesse interesse)
        {
            var result = this._leerlingRepository.VerwijderIntresseFromLeerling(leerlingId, interesse);
            if (result != null)
            {
                return result;
            }
            else
            {
                if (_leerlingRepository.GetAll().Exists(l => l.Id == leerlingId))
                {
                    return (ActionResult<List<String>>)NotFound(new Dictionary<string, string>() { { "message", $"Geen matching interesse gevonden: {interesse}" } });

                }
                return (ActionResult<List<String>>)NotFound(new Dictionary<string, string>() { { "message", $"leerling with id: {leerlingId} not found" } });
            }
        }
    }
}
