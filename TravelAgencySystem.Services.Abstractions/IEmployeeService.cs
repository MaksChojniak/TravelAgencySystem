using TravelAgencySystem.DataModel;

namespace TravelAgencySystem.Services.Abstractions;

public interface IEmployeeService
{
    Guid Create(string firstName, string lastName, string pesel, double salary);
    Employee? Get(Guid id);
    IReadOnlyList<Employee> GetAll();
    bool Exist(Guid id);
    void Update(Guid id, string? firstName, string? lastName, string? pesel, double? salary);
}