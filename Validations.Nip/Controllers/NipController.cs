using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Validations.Nip.Validations;

namespace Validations.Nip.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NipController : ControllerBase
    {
        [HttpGet("{nip}")]
        public IActionResult NipIsValid(string nip)
        {
            bool result = NipValidator.NipIsValid(nip) ? true : false;

            if (result)
                return Ok();
            else return BadRequest("Nip jest nieprawidłowy");
            
        }
    }
}

