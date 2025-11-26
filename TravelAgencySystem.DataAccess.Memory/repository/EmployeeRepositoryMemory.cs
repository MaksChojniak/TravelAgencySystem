using TravelAgencySystem.DataAccess.Abstractions;
using TravelAgencySystem.Database.Memory;
using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.DataAccess;

public class EmployeeRepositoryMemory : RepositoryMemory<Employee, Guid>
{
    public EmployeeRepositoryMemory(MemoryDbContext dbContext) : base(dbContext) { }

    public override  IQueryable<Employee> Query() => _dbContext.Employees.AsQueryable();

    public override void Add(Employee entity) => _dbContext.Employees.Add(entity);

    public override void Remove(Employee entity) => _dbContext.Employees.Remove(entity);

    public override Employee? Get(Guid id) => _dbContext.Employees.FirstOrDefault(e => e.Id == id);
}