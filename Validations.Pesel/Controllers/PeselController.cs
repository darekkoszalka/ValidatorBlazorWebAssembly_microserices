using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Validations.Pesel.Models;
using Validations.Pesel.Validations;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Validations.Pesel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeselController : ControllerBase
    {
        // GET: /<controller>/
        [HttpGet("allPeselData/{pesel}")]
        public IActionResult GetAllData(string pesel)
        {
            bool result = PeselValidator.PeselIsValid(pesel) ? true : false;

            if(result)
            {
                PeselVM peselVM = new()
                {
                    Pesel = pesel,
                    Year = PeselUtility.GetYearOfDateOfBirth(pesel),
                    Month = PeselUtility.GetMonthOfDateOfBirth(pesel),
                    Day = PeselUtility.GetDayOfDateOfBirth(pesel),
                    Gender = PeselUtility.Gender(pesel)
                };
                return Ok(peselVM);
            }
            else return BadRequest("Pesel jest nieprawidłowy");
        }

        [HttpGet("peselIsValid/{pesel}")]
        public IActionResult PeselIsValid(string pesel)
        {
            bool result = PeselValidator.PeselIsValid(pesel) ? true : false;

            if (result)
            {
                return Ok();
            }
            else return BadRequest("Pesel jest nieprawidłowy");

        }

        [HttpGet("getYearOfBirth/{pesel}")]
        public IActionResult GetYearOfBirth(string pesel)
        {
            bool result = PeselValidator.PeselIsValid(pesel) ? true : false;

            if (result)
            {
                string year = PeselUtility.GetYearOfDateOfBirth(pesel);
                return Ok(year);
            }
            else return Problem("Pesel jest nieprawidłowy.");

        }

        [HttpGet("getMonthOfBirth/{pesel}")]
        public IActionResult GetMonthOfBirth(string pesel)
        {
            bool result = PeselValidator.PeselIsValid(pesel) ? true : false;

            if (result)
            {
                string month = PeselUtility.GetMonthOfDateOfBirth(pesel);
                return Ok(month);
            }
            else return Problem("Pesel jest nieprawidłowy.");

        }

        [HttpGet("getDayOfBirth/{pesel}")]
        public IActionResult GetDayhOfBirth(string pesel)
        {
            bool result = PeselValidator.PeselIsValid(pesel) ? true : false;

            if (result)
            {
                string day = PeselUtility.GetDayOfDateOfBirth(pesel);
                return Ok(day);
            }
            else return Problem("Pesel jest nieprawidłowy.");

        }

        [HttpGet("getGender/{pesel}")]
        public IActionResult GetGender(string pesel)
        {
            bool result = PeselValidator.PeselIsValid(pesel) ? true : false;

            if (result)
            {
                string gender = PeselUtility.Gender(pesel);
                return Ok(gender);
            }
            else return Problem("Pesel jest nieprawidłowy.");

        }
    }
}

