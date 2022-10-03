using Microsoft.AspNetCore.Mvc;
using test.Interfaces;
using test.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociatedVehicleController : ControllerBase
    {

        private readonly IAssociatedVehicle repository;
        public AssociatedVehicleController(IAssociatedVehicle repository)
        {
            this.repository = repository;
        }
        // GET: api/<ValuesController>
        [HttpGet("odometer/{platNumber}")]
        public float GetOdometer(string platNumber)
        {
           
            var odometer = repository.GetLastOdometer(platNumber);
            return odometer;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{platNumber}")]
        public ActionResult<AssociatedVehicle> GetVehicalInfo(string platNumber)
        {

            var vehicalInfo = repository.GetVehicalInfo(platNumber);
            return vehicalInfo;
        }


    }
}
