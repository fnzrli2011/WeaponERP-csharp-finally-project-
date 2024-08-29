using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weapon.Buisness.Exceptions
{
    public class WeaponNotFound : Exception
    {
        public WeaponNotFound()
        {
        }

        public WeaponNotFound(string? message) : base(message)
        {
        }
    }
}
