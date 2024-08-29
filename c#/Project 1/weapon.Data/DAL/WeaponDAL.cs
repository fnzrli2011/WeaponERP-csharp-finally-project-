using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using weapon.Core.Models;

namespace weapon.Data.DAL
{
    public class WeaponDAL<T>
    {
        public static List<T> Weapons = new List<T>();
    }
}
