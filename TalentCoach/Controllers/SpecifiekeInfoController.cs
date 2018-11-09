using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TalentCoach.Models.Domain;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TalentCoach.Controllers
{
    [Route("api/specifieke-info")]
    [ApiController]
    public class SpecifiekeInfoController : ControllerBase
    {
        readonly IRepository<SpecifiekeInfo> _specifiekeInfoRepository;

        public SpecifiekeInfoController(IRepository<SpecifiekeInfo> specifiekeInfoRepository)
        {
            _specifiekeInfoRepository = specifiekeInfoRepository;
        }

        /// <summary>
        ///     Geeft alle specifieke info terug uit de databank
        /// </summary>
        /// <returns>
        ///     Lijst van algemene info
        /// </returns>      
        // GET api/specifieke-info
        [HttpGet]
        public ActionResult<List<SpecifiekeInfo>> GetAll()
        {
            return _specifiekeInfoRepository.GetAll();
        }

    }
}
