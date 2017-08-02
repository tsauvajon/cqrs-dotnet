namespace CQRS.Employee
{
    using Microsoft.AspNetCore.Mvc;

    [Produces("application/json")]
    [Route("employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepo;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetByID(int id)
        {
            var employee = employeeRepo.GetByID(id);

            // It is possible for GetByID() to return null.
            // If it does, we return HTTP 400 Bad Request
            if (employee == null)
            {
                return BadRequest($"No Employee with ID {id} was found");
            }

            return Ok(employee);
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var employees = employeeRepo.GetAll();
            return Ok(employees);
        }
    }
}