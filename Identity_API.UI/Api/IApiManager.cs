using Identity_API.DAL.Entities;

namespace Identity_API.UI.Api
{
    public interface IApiManager
    {
        Task<List<EldenRingWeapon>> GetWeaponsFromDb();
    }
}