using Identity_API.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly List<EldenRingWeapon> _weapons;

        public DbManager(EldenRingWeaponsContext context, AuthDbContext userDatabase)
        {
            _context = context;
            _userDatabase = userDatabase;
            _weapons = _context.EldenRingWeapons.AsNoTracking().ToList();
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
            return _weapons.ToList();
        }

        public EldenRingWeapon GetWeapon(int id)
        {
            EldenRingWeapon returnWeapon = null;

            foreach (var weapon in _weapons)
            {
                if (weapon.Id == id)
                {
                    returnWeapon = weapon;
                }
            }

            return returnWeapon;
        }

        public async Task PostWeapon(EldenRingWeapon weapon)
        {
            _context.EldenRingWeapons.Add(weapon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateWeapon(EldenRingWeapon updateWeapon)
        {
            _context.EldenRingWeapons.Update(updateWeapon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteWeapon(int id)
        {
            EldenRingWeapon eldenRingWeapon = _weapons.Find(x => x.Id == id);

            _context.EldenRingWeapons.Remove(eldenRingWeapon);
            await _context.SaveChangesAsync();
        }
    }
}
