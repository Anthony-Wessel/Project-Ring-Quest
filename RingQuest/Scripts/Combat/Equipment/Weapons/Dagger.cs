using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Dagger : Equipment
    {
        public Dagger() : base("Dagger", "+1 damage, + 5% crit", EquipSlot.WEAPON_1H) { }

        public override void OnDequip(Character c)
        {
            c.bonusCritChance -= 0.05f;
            c.bonusDamageDone -= 1;
        }

        public override void OnEquip(Character c)
        {
            c.bonusCritChance += 0.05f;
            c.bonusDamageDone += 1;
        }
    }
}
