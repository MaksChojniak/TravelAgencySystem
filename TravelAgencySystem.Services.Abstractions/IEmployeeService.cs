using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IEmployeeService
{
    Employee? Get(Guid id);
    // IReadOnlyList<Employee> GetAll();
    void Update(Guid id, string? firstName = null, string? lastName = null, string? pesel = null, double? salary = null);
}