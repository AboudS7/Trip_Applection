using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trip_Applection.BL;
using Trip_Applection.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Trip_Applection.API
{
    [Route("[controller]/{action}")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRepostry<Trip> repostry;
        private readonly TravelsContext context;

        public ValuesController(IRepostry<Trip> repostry)
        {
            this.repostry = repostry;
            
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public ApiResponse Get()
        {
            try
            {            
                ApiResponse response = new ApiResponse();
                response.Data = repostry.GetAll();
                response.Errors = null;
                response.StatusCode = "200";
                return response;

            }
            catch (Exception ex)
            {
                ApiResponse response = new ApiResponse();
                response.Data = null;
                response.Errors = ex.Message;
                response.StatusCode = "502";
                return response;
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ApiResponse GetById(int id)
        {
            try
            {
                ApiResponse response = new ApiResponse();
                response.Data = repostry.GetById(id);
                response.Errors = null;
                response.StatusCode = "200";
                return response;

            }
            catch (Exception ex)
            {
                ApiResponse response = new ApiResponse();
                response.Data = null;
                response.Errors = ex.Message;
                response.StatusCode = "502 ";
                return response;
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ApiResponse Post([FromBody] Trip trip)
        {
            try
            {
                repostry.Create(trip);
                ApiResponse response = new ApiResponse();
                response.Data = "Done";
                response.Errors = null;
                response.StatusCode = "200";
                return response;
                
            }
            catch(Exception ex)
            {
                ApiResponse response = new ApiResponse();
                response.Data = null;
                response.Errors = ex.Message;
                response.StatusCode = "400";
                return response;
            }

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
