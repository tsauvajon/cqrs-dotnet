namespace CQRS.Employee
{
    using CQRS.Location;
    using FluentValidation;
    using System;

    /// <summary>
    /// Validator for <see cref="CreateEmployeeRequest"/>
    /// Add validation rules to the ModelState
    /// </summary>
    public class CreateEmployeeRequestValidator : AbstractValidator<CreateEmployeeRequest>
    {
        public CreateEmployeeRequestValidator(IEmployeeRepository employeeRepo, ILocationRepository locationRepo)
        {
            // the employee id must not already exist
            RuleFor(cer => cer.EmployeeId).Must(id => !employeeRepo.Exists(id)).WithMessage("This employee already exists");

            // the location must exist
            RuleFor(cer => cer.LocationID).Must(id => locationRepo.Exists(id)).WithMessage("This location doesn't exist");

            // the first name cannot be null or empty
            RuleFor(cer => cer.FirstName).NotNull().NotEmpty().WithMessage("The first name cannot be blank");

            // the last name cannot be null or empty
            RuleFor(cer => cer.LastName).NotNull().NotEmpty().WithMessage("The last name cannot be blank");

            // the job title cannot be null or empty
            RuleFor(cer => cer.JobTitle).NotNull().NotEmpty().WithMessage("The job title cannot be blank");

            // Minimum age
            RuleFor(cer => cer.DateOfBirth).LessThan(DateTime.Today.AddYears(-16)).WithMessage("The employees must be at least 16 years old");
            
            // Maximum age
            RuleFor(cer => cer.DateOfBirth).GreaterThan(DateTime.Today.AddYears(-100)).WithMessage("The employees cannot be older than 99 years old");
        }
    }
}
