using Identity_API.DAL.Entities;

namespace Identity_API.DAL
{
    public interface IDbManager
    {
        Task DeleteWeapon(int id);
        bool GetCurrentUserAccessToken(string accessToken);
        EldenRingWeapon GetWeapon(int id);
        List<EldenRingWeapon> GetWeapons();
        Task PostWeapon(EldenRingWeapon weapon);
        Task UpdateWeapon(EldenRingWeapon updateWeapon);
    }
}