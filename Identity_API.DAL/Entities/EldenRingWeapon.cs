using System;
using System.Collections.Generic;

namespace Identity_API.DAL.Entities
{
    public partial class EldenRingWeapon
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? WeaponType { get; set; }
        public string? SkillBestScaledWith { get; set; }
        public int Damage { get; set; }
        public string? ImageURL { get; set; }
        public string? WeaponOwnerId { get; set; }
    }
}
