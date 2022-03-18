using DomainLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer;
using System;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersoBookController : ControllerBase
    {
        private readonly IPersoBookDetails PersoBookService;
        private readonly ILogger<PersoBookController> _logger;


        public PersoBookController(IPersoBookDetails persoBookService, ILogger<PersoBookController> logger)
        {

            PersoBookService= persoBookService;
            _logger= logger;


        }

        [HttpGet]
        [Route("/All Books Assigned To Person")]
        public ActionResult GetPersoBooks()
        {
            try
            {
                _logger.LogInformation("Get All Assigned Books endpoint start");
                var books = PersoBookService.GetPersoBooks();
                if (books != null)
                {
                    return Ok(books);
                }
                _logger.LogInformation("Get All Assigned Books endpoint complete");
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception occured;Exception detail:" + ex.InnerException);
            }
            
            return BadRequest("Not Found");
        }

        [HttpGet]
        [Route("/History Of Book")]
        public ActionResult GetBook(string bookid)
        {
            try
            {
                _logger.LogInformation("Get Books endpoint start");
                var book = PersoBookService.GetPersoBooks(bookid);
                if (book != null)
                {
                    return Ok(book);
                }
                _logger.LogInformation("Get Books endpoint complete");
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception occured;Exception detail:" + ex.InnerException);
            }
           
            return BadRequest("Not Found");
        }

        

        [HttpPost]
        [Route("/Assigning Book")]

        public ActionResult AddBook(PersoBooks book)
        {
            try
            {
                _logger.LogInformation(" assign Books endpoint start");
                PersoBookService.InsertBookIn(book);
                _logger.LogInformation(" assign Books endpoint complete");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured;Exception detail:" + ex.InnerException);
            }

          
            return Ok("Issued");
        }

        [HttpPut]
        [Route("/Removing The Book")]

        public ActionResult UpdatePerson(PersoBooks book)
        {
            try
            {
                _logger.LogInformation(" Update book endpoint start");
                PersoBookService.UpdateBookIn(book);
                _logger.LogInformation(" Update book endpoint complete");
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception occured;Exception detail:" + ex.InnerException);
            }
           
            return Ok("Updated");
        }

    }
}
