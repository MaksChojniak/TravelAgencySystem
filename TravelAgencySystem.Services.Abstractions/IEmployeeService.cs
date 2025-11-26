using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IEmployeeService
{
    Guid Create();
    Employee? Get(Guid id);
    IReadOnlyList<Employee> GetAll();
}