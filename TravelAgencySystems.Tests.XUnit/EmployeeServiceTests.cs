using TravelAgencySystem.DataModel;
using TravelAgencySystem.Services.Abstractions;
using TravelAgencySystem.Tests.XUnit;

namespace TravelAgencySystems.Tests.XUnit;

public class EmployeeServiceTests : IClassFixture<InMemoryServicesFixture>
{
    readonly IEmployeeService _employeeService;

    readonly SeedResult _seed;

    public EmployeeServiceTests(InMemoryServicesFixture fx)
    {
        _employeeService = fx.EmployeeService;
        
        _seed = fx.Seed;
    }

#region Get
    [Fact]
    public void Get_Success()
    {
        Employee? employee = _employeeService.Get(_seed.Employees[0]);
        Assert.NotNull(employee);
    }
    [Fact]
    public void Get_Fail()
    {
        Employee? employee = _employeeService.Get(Guid.Empty);
        Assert.Null(employee);
    }
#endregion

#region Update
    [Fact]
    public void Update_Success()
    {
        string newFirstName = "UpdatedFirstName";
        string newLastName = "UpdatedLastName";

        _employeeService.Update(_seed.Employees[0], firstName: newFirstName, lastName: newLastName);

        Employee? updatedEmployee = _employeeService.Get(_seed.Employees[0]);
        Assert.NotNull(updatedEmployee);
        Assert.Equal(newFirstName, updatedEmployee.FirstName);
        Assert.Equal(newLastName, updatedEmployee.LastName);
    }
#endregion

}