using Application.DTO;
using Application.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
                
    {
        
        private readonly IServiceRepository _IServiceRepository;

        public ServiceController(IServiceRepository serviceRepository) {

                        _IServiceRepository = serviceRepository;
        }

        // GET: api/<ServiceController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetAll()
       {
           var Services = await _IServiceRepository.GetAllAsync();
           return Ok(Services);
        }
     

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ServiceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
