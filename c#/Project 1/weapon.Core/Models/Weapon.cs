using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using weapon.Core;
using weapon.Core.Models;
using System.Threading.Tasks;
using weapon.Core.Enum;

namespace weapon.Core.Models
{
    public class Weapon
    {
        public string? Name { get; set; }
        public int BulletCapacity { get; set; }
        private int _bn;
        public int BulletNumber
        {
            get
            {
                return _bn;
            }
            set
            {
                if (value <= BulletCapacity) _bn = value;
                else _bn = BulletCapacity;
            }
        }
        public FireMOd fireMod { get; set; }
        public static int _id { get; set; }
        public int Id { get; set; }
        public Weapon()
        {
            _id += 1;
            Id = _id;
        }
    }
}
