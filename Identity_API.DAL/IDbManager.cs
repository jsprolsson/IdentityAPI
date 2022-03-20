using Identity_API.DAL.Entities;

namespace Identity_API.DAL
{
    public interface IDbManager
    {
        bool GetCurrentUserAccessToken(string accessToken);
        List<EldenRingWeapon> GetWeapons();
    }
}