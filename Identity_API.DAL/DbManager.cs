using Identity_API.DAL.Entities;
using Microsoft.AspNetCore.Http;
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
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly List<EldenRingWeapon> _weapons;

        public DbManager(EldenRingWeaponsContext context, AuthDbContext userDatabase, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userDatabase = userDatabase;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;

            //Bad practice I guess to have list here. Attempt to avoid repeating myself in the DbManagers methods.
            //AsNoTracking() to be able to save changes to database without database being confused what to save.
            _weapons = _context.EldenRingWeapons.AsNoTracking().ToList();
        }

        public bool GetCurrentUserAccessToken(string accessToken)
        {
            //Searches through entire user database for accessToken passed in.
            //Returns true if access token found.

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

        public bool AllowUserAccessToWeapon(EldenRingWeapon weapon)
        {
            bool correctUser = false;
            //Check the weapon that is passed in and compare that to the weapon that is already in the database.
            //If the weaponownerid is the same, update the weapon.
            var weaponInDatabase = _weapons.Find(w => w.Id == weapon.Id);

            correctUser = weaponInDatabase.WeaponOwnerId == weapon.WeaponOwnerId ? true : false;

            return correctUser;
        }
    }
}
