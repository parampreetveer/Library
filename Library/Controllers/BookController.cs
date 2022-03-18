
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
    public class BookController : ControllerBase
    {
        private readonly IBookDetails BookService;
        private readonly ILogger<BookController> _logger;
        #region "constructor init"
        public BookController(IBookDetails bookService, ILogger<BookController> logger)
        {
            BookService = bookService;
            _logger = logger;
            

        }
        #endregion

        #region "Api core func"
        
        [HttpGet]
        [Route("/All Book Details")]
        public ActionResult GetBookDetails()
        {
            try
            {
                _logger.LogInformation("Get All Book Details endpoint start");
                var books = BookService.GetBookDetails();
                if (books != null && books.Count > 0)
                {
                    return Ok(books);
                }
                _logger.LogInformation("Get All Book Details endpoint complete");


            }
            catch(Exception ex)
            {
                _logger.LogError("Exception occured;Exception detail:" + ex.InnerException);
            }
            return BadRequest("Not Found");

        }

        [HttpGet]
        [Route("/One Book Details")]
        public ActionResult GetBook(int bookid)
        {
            try
            {
                _logger.LogInformation("Get One Book Details endpoint start");
                var book = BookService.GetBookDetails(bookid);
                if (book != null)
                {
                    return Ok(book);
                }
                _logger.LogInformation("Get One Book Details endpoint complete");

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured;Exception detail:" + ex.InnerException);
            }
            return BadRequest("Not Found");

        }

        [HttpPost]
        [Route("/Insert Book")]

        public ActionResult AddBook(BookDetails bookDetails )
        {
            try
            {
                _logger.LogInformation("Get Add Book Details endpoint start");
                BookService.InsertBook(bookDetails);
                _logger.LogInformation("Get Add Book Details endpoint complete");
            }

            catch( Exception ex)
            {
                _logger.LogError("Exception occured;Exception detail:" + ex.InnerException);

            }
           
            
            return Ok("Book added");
        }

     

        #endregion

    }
}
