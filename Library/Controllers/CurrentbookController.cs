using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer;
using System;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentbookController : ControllerBase
    {
        private readonly ICurrentbook Currentbook;
        private readonly ILogger<CurrentbookController> _logger;


        public CurrentbookController(ICurrentbook currentbook, ILogger<CurrentbookController> logger)
        {
            Currentbook = currentbook;
            _logger = logger;

        }
      
        [HttpGet]
        [Route("/Person's Current Book ")]
        public ActionResult GetCurrentBook(string personid)
        {
            try
            {
                _logger.LogInformation("Get Current Book  endpoint start");
                var pid = Currentbook.GetCurrentBook(personid);
                if (pid != null)
                {
                    return Ok(pid);
                }
                _logger.LogInformation("Get Current Book  endpoint complete");
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception occured;Exception detail:" + ex.InnerException);
            }
           
            return BadRequest("Not Found");
        }

    }
}
