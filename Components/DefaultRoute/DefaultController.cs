using Microsoft.AspNetCore.Mvc;

namespace DefaultRoute
{
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult NooP()
        {
            return Ok("Noop!");
        }
    }
}