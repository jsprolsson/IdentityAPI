using Identity_API.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity_API.DAL
{
    public class DbManager : IDbManager
    {
        private readonly EldenRingWeaponsContext _context;
        private readonly AuthDbContext _userDatabase;

        public DbManager(EldenRingWeaponsContext context, AuthDbContext userDatabase)
        {
            _context = context;
            _userDatabase = userDatabase;
        }

        public bool GetCurrentUserAccessToken(string accessToken)
        {
            List<ApplicationUser> users = _userDatabase.Users.ToList();
            bool accessTokenLegit = false;

            foreach (var user in users)
            {
                if (user.AccessToken == accessToken)
                {
                    accessTokenLegit = true;
                }
            }

            return accessTokenLegit;
        }

        public List<EldenRingWeapon> GetWeapons()
        {
            List<EldenRingWeapon> weapons = _context.EldenRingWeapons.ToList();
            return weapons;
        }
    }
}
