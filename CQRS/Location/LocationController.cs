namespace CQRS.Location
{
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("locations")]
    public class LocationController : Controller
    {
        private ILocationRepository locationRepo;

        public LocationController(ILocationRepository locationRepo)
        {
            this.locationRepo = locationRepo;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var location = locationRepo.GetByID(id);

            if (location == null)
            {
                return BadRequest($"No location with ID {id} was found");
            }

            return Ok(location);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var locations = locationRepo.GetAll();
            return Ok(locations);
        }

        [HttpGet]
        [Route("{id}/employees")]
        public IActionResult GetEmployees(int id)
        {
            var employees = locationRepo.GetEmployees(id);
            return Ok(employees);
        }
    }
}