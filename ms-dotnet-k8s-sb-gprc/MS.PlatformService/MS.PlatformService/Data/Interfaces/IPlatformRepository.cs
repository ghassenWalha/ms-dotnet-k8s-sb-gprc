using MS.PlatformService.Models;

namespace MS.PlatformService.Data.Interfaces
{
    public interface IPlatformRepository
    {
        bool SaveChanges();
        IEnumerable<Platform> GetPlatforms();
        Platform? GetPlatformById(Guid id);
        void CreatePlatform(Platform platform);

    }
}
