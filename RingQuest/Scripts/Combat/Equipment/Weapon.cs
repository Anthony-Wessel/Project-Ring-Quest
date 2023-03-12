using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public enum WeaponType
    {
        ONEH,
        TWOH,
        OFFHAND
    }
    public abstract class Weapon : Equipment
    {
        public WeaponType type;
        public Weapon(string name, string description, WeaponType type) : base(name, description, EquipSlot.WEAPON)
        {
            this.type = type;
        }
    }
}
