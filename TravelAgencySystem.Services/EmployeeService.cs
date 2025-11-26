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


    public Guid Create(string firstName, string lastName, string pesel, double salary)
    {
        throw new NotImplementedException();
    }

    public Employee? Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyList<Employee> GetAll()
    {
        throw new NotImplementedException();
    }
}