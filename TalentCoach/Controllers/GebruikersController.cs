using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TalentCoach.Dtos;
using TalentCoach.Helpers;
using TalentCoach.Models.Domain;

namespace TalentCoach.Controllers
{
    [Authorize] // Scherm deze controller af van buitenwereld, voeg [AllowAnonymous] toe waar nodig
    [Route("api/[controller]")]
    [ApiController]
    public class GebruikersController : ControllerBase
    {
        private readonly IGebruikersRepository _repository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public GebruikersController(
            IGebruikersRepository gebruikersRepository,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _repository = gebruikersRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var gebruikers = _repository.GetAll();
            var gebruikerDtos = _mapper.Map<IList<GebruikerDto>>(gebruikers);
            return Ok(gebruikers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var gebruiker = _repository.GetById(id);
            var gebruikerDto = _mapper.Map<GebruikerDto>(gebruiker);
            return Ok(gebruikerDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]GebruikerDto gebruikerDto)
        {
            // Map Dto to Gebruiker
            var gebruiker = _mapper.Map<Gebruiker>(gebruikerDto);
            gebruiker.Id = id;

            try
            {
                _repository.UpdateGebruiker(gebruiker, gebruikerDto.Wachtwoord);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("registreer")]
        public IActionResult Register([FromBody] GebruikerDto gebruikerDto)
        {
            // Map Dto to Gebruiker
            var gebruiker = _mapper.Map<Gebruiker>(gebruikerDto);

            try
            {
                _repository.CreateGebruiker(gebruiker, gebruikerDto.Wachtwoord);
                return Ok();
            }
            catch (AppException e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("authenticeer")]
        public IActionResult Authenticate([FromBody] GebruikerDto gebruikerDto)
        {
            var gebruiker = _repository.Authenticate(gebruikerDto.Gebruikersnaam, gebruikerDto.Wachtwoord);

            if (gebruiker == null)
            {
                return BadRequest(new { message = "Gebruikersnaam of wachtwoord is fout" });
            }

            var gebruikersRol = gebruiker.GebruikersRol;

            var tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, gebruiker.Id.ToString()),
                    }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Voeg rol toe aan jwt-token afhankelijk van de rol van de gebruiker
            switch (gebruikersRol)
            {
                case GebruikersRol.Leerling:
                    tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, nameof(GebruikersRol.Leerling)));
                    break;

                case GebruikersRol.Leerkracht:
                    tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, nameof(GebruikersRol.Leerkracht)));
                    break;

                case GebruikersRol.Werkgever:
                    tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, nameof(GebruikersRol.Werkgever)));
                    break;
            }

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            // Geeft basis gebruiker info terug (zonder wachtwoord) en token voor op te slaan in client
            // Gebruikersrol en concretGebruikerId kunnen eigenlijk gelezen worden uit token
            return Ok(new
            {
                gebruiker.Id,
                gebruiker.Gebruikersnaam,
                gebruiker.GebruikersRol,
                gebruiker.ConcreteGebruikerId,
                Token = tokenString
            });
        }
    }
}
