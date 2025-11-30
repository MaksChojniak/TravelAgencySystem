using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Abstractions;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public class EmployeeService : IEmployeeService
{
    readonly IRepository<Employee> _employees;

    readonly IDbContext _dbContext;

    public EmployeeService(IRepository<Employee> employees, IDbContext dbContext)
    {
        _employees = employees;
        _dbContext = dbContext;
    }

    public Employee? Get(Guid id) => _employees.Get(id);

    public void Update(Guid id, string? firstName, string? lastName, string? pesel, double? salary)
    {
        if(Get(id) is not Employee employee)
            throw new ArgumentException("Employee not exist", nameof(employee));

        employee.FirstName = firstName ?? employee.FirstName;
        employee.LastName = lastName ?? employee.LastName;
        employee.Pesel = pesel ?? employee.Pesel;
        employee.Salary = salary ?? employee.Salary;

        _dbContext.SaveChanges();
    }

}