using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weapon.Core.Models;
using weapon.Core.Enum;
using weapon.Buisness.Exceptions;
using weapon.Buisness.Implementions;

namespace weapon.Buisness.Interfaces
{
    public interface IWeaponService
    {
        public void Create(Weapon weapon);
        public void Shoot(Weapon weapon);
        public void Information(Weapon weapon);
        public void Fire(Weapon weapon);
        public int GetRemainBulletCount(Weapon weapon);
        public void Reload(Weapon weapon);
        public void ChangeFireMod(Weapon weapon);
        public void Edit(Weapon weapon, int NewCapacity);
    }
}
