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
    public class PersonController : ControllerBase
    {
        private readonly IPersonDetails PersonService;
        private readonly ILogger<PersonController>_logger;

        #region "constructor init"
        public PersonController(IPersonDetails personService, ILogger<PersonController> logger)
        {
            PersonService = personService;
            _logger = logger;


        }
        #endregion

        #region "Api core func"

        [HttpGet]
        [Route("/All Person Details")]
        public ActionResult GetPersonDetails()
        {
            try
            {
                _logger.LogInformation("Get All Person Details endpoint start");
                var persons = PersonService.GetPersonDetails();
                if (persons != null && persons.Count > 0)
                {
                    return Ok(persons);
                }
                _logger.LogInformation("Get All Person Details endpoint complete");

            }
            catch(Exception ex)
            {
                _logger.LogError("Exception occured;Exception detail:" + ex.InnerException);
            }
           
            return BadRequest("Not Found");
        }

        [HttpGet]
        [Route("/One Person Details")]
        public ActionResult GetBook(int personid)
        {
            try
            {
                _logger.LogInformation("Get One Person Details endpoint start");
                var person = PersonService.GetPersonDetails(personid);
                if (person != null)
                {
                    return Ok(person);
                }
                _logger.LogInformation("Get One Person Details endpoint complete");
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occured;Exception detail:" + ex.InnerException);
            }
           


            return BadRequest("Not Found");
        }

        [HttpPost]
        [Route("/Insert Person Details")]

        public ActionResult AddPerson(PersonDetails personDetails)
        {
            try
            {
                _logger.LogInformation("Add Person Details endpoint start");
                PersonService.InsertPerson(personDetails);
                _logger.LogInformation("Add Person Details endpoint complete");
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception occured;Exception detail:" + ex.InnerException);
            }

           
            return Ok("Person added");
        }
        [HttpPut]
        [Route("/Update Person Details")]

        public ActionResult UpdatePerson(PersonDetails personDetails)
        {
            try
            {
                _logger.LogInformation("Update Person Details endpoint start");

                PersonService.UpdatePerson(personDetails);

                _logger.LogInformation("Update Person Details endpoint complete");
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception occured;Exception detail:" + ex.InnerException);
            }
            
            return Ok("Updated");
        }
        
     

        [HttpDelete]
        [Route("/Delete Person Details")]

        public ActionResult DeletePerson(int personid)
        {
            try
            {
                _logger.LogInformation("Delete Person Details endpoint start");
                PersonService.DeletePerson(personid);
                _logger.LogInformation("Delete Person Details endpoint complete");
            }
            catch(Exception ex)
            {
                _logger.LogError("Exception occured;Exception detail:" + ex.InnerException);
            }

            
            return Ok("Person Removed");
        }

       

        #endregion


    }
}
