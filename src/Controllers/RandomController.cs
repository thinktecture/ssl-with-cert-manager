using System;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Thinktecture.MiniAPI.Models;

namespace Thinktecture.MiniAPI.Controllers
{
    [ApiController]
    [Route("random")]
    [Produces("application/json")]
    public class RandomController: ControllerBase
    {

        [HttpGet]
        [Route("number")]
        [SwaggerOperation("Random Number", Description = "Generates a random number")]
        [SwaggerResponse(200, "Generated Number", typeof(RandomResponse<int>))]
        public IActionResult GetRandomNumber()
        {
            var rand = new Random(1);
            return Ok(new RandomResponse<int>(rand.Next(1, 1000)));
        }

        [HttpGet]
        [Route("id")]
        [SwaggerOperation("Random Id", Description = "Generates a random Id (uuid)")]
        [SwaggerResponse(200, "Generated Id", typeof(RandomResponse<Guid>))]
        public IActionResult GetRandomId()
        {
            return Ok(new RandomResponse<Guid>(Guid.NewGuid()));
        }
    }
}
