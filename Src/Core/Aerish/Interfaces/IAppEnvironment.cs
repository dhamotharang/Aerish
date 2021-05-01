namespace Aerish.Interfaces
{
    public interface IAppEnvironment
    {
        bool IsDevelopment();
        bool IsStaging();
        bool IsProduction();
    }
}
