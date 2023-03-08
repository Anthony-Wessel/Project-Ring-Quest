using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Sword : Equipment
    {
        public Sword() : base("Sword", "+2 damage", EquipSlot.WEAPON_1H) { }

        public override void OnDequip(Character c)
        {
            c.bonusDamageDone -= 2;
        }

        public override void OnEquip(Character c)
        {
            c.bonusDamageDone += 2;
        }
    }
}
