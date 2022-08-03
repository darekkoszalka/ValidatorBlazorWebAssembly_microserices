using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Validations.Nip.IRepositories;
using Validations.Nip.Validations;

namespace Validations.Nip.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NipController : ControllerBase
    {
        private readonly INipRepostory _nipRepostory;

        public NipController(INipRepostory nipRepostory)
        {
            _nipRepostory = nipRepostory;
        }

        [HttpGet("{nip}")]
        public IActionResult NipIsValid(string nip)
        {
            bool result = _nipRepostory.NipIsValid(nip);

            if (result)
                return Ok();
            else return BadRequest("Nip jest nieprawidłowy");           
        }
    }
}

