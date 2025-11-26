namespace TravelAgencySystem.Database.Abstractions;

public interface IDbContext
{
    int SaveChanges();
}