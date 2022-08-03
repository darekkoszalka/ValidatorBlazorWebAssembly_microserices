using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Validations.Pesel.IRepositories;
using Validations.Pesel.Models;


namespace Validations.Pesel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeselController : ControllerBase
    {
        private readonly IPeselRepository _peselRepository;
        private readonly IPeselUtilityRepository _peselUtilityRepository;

        public PeselController(IPeselRepository peselRepository,
            IPeselUtilityRepository peselUtilityRepository)
        {
            _peselRepository = peselRepository;
            _peselUtilityRepository = peselUtilityRepository;
        }


        // GET: /<controller>/
        [HttpGet("allPeselData/{pesel}")]
        public IActionResult GetAllData(string pesel)
        {
            bool result = _peselRepository.PeselIsValid(pesel);

            if(result)
            {
                PeselVM peselVM = new()
                {
                    Pesel = pesel,
                    Year = _peselUtilityRepository.GetYearOfDateOfBirth(pesel),
                    Month = _peselUtilityRepository.GetMonthOfDateOfBirth(pesel),
                    Day = _peselUtilityRepository.GetDayOfDateOfBirth(pesel),
                    Gender = _peselUtilityRepository.GetGender(pesel)
                };
                return Ok(peselVM);
            }
            else return BadRequest("Pesel jest nieprawidłowy");
        }

        [HttpGet("peselIsValid/{pesel}")]
        public IActionResult PeselIsValid(string pesel)
        {
            bool result = _peselRepository.PeselIsValid(pesel);
            if (result)
            {
                return Ok();
            }
            else return BadRequest("Pesel jest nieprawidłowy");

        }

        [HttpGet("getYearOfBirth/{pesel}")]
        public IActionResult GetYearOfBirth(string pesel)
        {
            bool result = _peselRepository.PeselIsValid(pesel);

            if (result)
            {
                string year = _peselUtilityRepository.GetYearOfDateOfBirth(pesel);
                return Ok(year);
            }
            else return Problem("Pesel jest nieprawidłowy.");

        }

        [HttpGet("getMonthOfBirth/{pesel}")]
        public IActionResult GetMonthOfBirth(string pesel)
        {
            bool result = _peselRepository.PeselIsValid(pesel);

            if (result)
            {
                string month = _peselUtilityRepository.GetMonthOfDateOfBirth(pesel);
                return Ok(month);
            }
            else return Problem("Pesel jest nieprawidłowy.");

        }

        [HttpGet("getDayOfBirth/{pesel}")]
        public IActionResult GetDayhOfBirth(string pesel)
        {
            bool result = _peselRepository.PeselIsValid(pesel) ? true : false;

            if (result)
            {
                string day = _peselUtilityRepository.GetDayOfDateOfBirth(pesel);
                return Ok(day);
            }
            else return Problem("Pesel jest nieprawidłowy.");

        }

        [HttpGet("getGender/{pesel}")]
        public IActionResult GetGender(string pesel)
        {
            bool result = _peselRepository.PeselIsValid(pesel) ? true : false;

            if (result)
            {
                string gender = _peselUtilityRepository.GetGender(pesel);
                return Ok(gender);
            }
            else return Problem("Pesel jest nieprawidłowy.");

        }
    }
}

