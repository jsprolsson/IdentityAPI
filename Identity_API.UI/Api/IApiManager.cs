using Identity_API.DAL.Entities;

namespace Identity_API.UI.Api
{
    public interface IApiManager
    {
        Task<List<EldenRingWeapon>> GetWeaponsFromDb();
        Task<string> PostWeaponToDb(EldenRingWeapon weapon);
        Task<string> DeleteWeaponFromDb(int id);
        Task<string> UpdateWeaponFromDb(EldenRingWeapon weapon);
    }
}