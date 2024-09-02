using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weapon.Buisness.Interfaces;
using weapon.Core.Models;
using weapon.Core.Enum;
using weapon.Buisness.Exceptions;
using WMPLib;
using weapon.Data.DAL;

namespace weapon.Buisness.Implementions
{
    public class WeaponService : IWeaponService
    {

        public void ChangeFireMod(Weapon weapon)
        {
           if(weapon.fireMod == FireMOd.Single)
            {
                weapon.fireMod = FireMOd.Multi;
            }
           else
            {
                weapon.fireMod = FireMOd.Single;
            }
            Console.WriteLine($"FireMod is {weapon.fireMod}");
        }


        public void Create(Weapon weapon)
        {
            if(weapon != null)
            {
                WeaponDAL<Weapon>.Weapons.Add(weapon);
                Console.WriteLine("Weapon created successfully");
            }
            else
            {
                throw new WeaponNotFound("Weapon could not be found");
            }
        }

        public void Edit(Weapon weapon , int NewCapacity)
        {
            if (weapon != null)
            {
                weapon.BulletCapacity = NewCapacity;
                weapon.BulletNumber = weapon.BulletCapacity;
                Console.WriteLine($"New bulletcapacity : {weapon.BulletCapacity} and New bulletnumber :{weapon.BulletNumber}");
            }
            else
            {
                throw new WeaponNotFound("Weapon could not be found");
            }
        }

        public void Fire(Weapon weapon)
        {
            if(weapon != null)
            {
                if (weapon.BulletNumber > 0)
                {
                    weapon.BulletNumber = 0;
                    WindowsMediaPlayer player = new WindowsMediaPlayer();
                    player.URL = @"C:\Users\fnzrli109\Desktop\Project\c#\Sounds\Fire.mp3";
                    player.controls.play();
                    Console.WriteLine("Press any key to end the fire ...");
                    Console.ReadKey();
                    Console.WriteLine("Fire stopped.");
                }
                else
                {
                    Console.WriteLine("Please rebuild weapon.");
                }

            }
            else
            {
                throw new WeaponNotFound("Weapon could not be found");
            }
        }

        public int GetRemainBulletCount(Weapon weapon)
        {
            if (weapon != null)
            {
                return weapon.BulletNumber;
            }
            else
            {
                throw new WeaponNotFound("Weapon could not be found");
            }
        }

        public void Information(Weapon weapon)
        {
            if(weapon != null)
            {
                Console.WriteLine($"Weapon Name : {weapon.Name},Weapon Id : {weapon.Id}, Weapon BulletCapacity : {weapon.BulletCapacity}, Weapon BulletNumber : {weapon.BulletNumber}, Weapon FireMod : {weapon.fireMod}"); 
            }
            else
            {
                throw new WeaponNotFound("Weapon could not be found");
            }
        }


        public void Reload(Weapon weapon)
        {
            if (weapon != null)
            {
                weapon.BulletNumber = weapon.BulletCapacity;
            }
            else
            {
                throw new WeaponNotFound("Weapon could not be found");
            }
        }

        public void Shoot(Weapon weapon)
        {
           if(weapon != null)
            {
                if (weapon.BulletNumber > 0)
                {
                    weapon.BulletNumber -= 1;
                    WindowsMediaPlayer player = new WindowsMediaPlayer();
                    player.URL = @"C:\Users\fnzrli109\Desktop\Project\c#\Sounds\shoot.mp3";
                    player.controls.play();
                    Console.WriteLine("Press any key for continue ...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Please rebuild weapon.");
                }
            }
           else
            {
                throw new WeaponNotFound("Weapon could not be found");
            }
        }
    }
}
