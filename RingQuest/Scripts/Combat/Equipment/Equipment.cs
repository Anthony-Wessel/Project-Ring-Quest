using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public enum EquipSlot
    {
        HELM,
        CHEST,
        WEAPON_2H,
        WEAPON_1H,
        OFF_HAND,
        ACCESSORY
    }

    public abstract class Equipment
    {
        public string name, description;
        public EquipSlot slot;
        public Equipment(string name, string description, EquipSlot slot)
        {
            this.name = name;
            this.description = description;
            this.slot = slot;
        }

        public abstract void OnEquip(Character c);
        public abstract void OnDequip(Character c);
    }
}
