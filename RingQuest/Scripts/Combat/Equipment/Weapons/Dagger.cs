using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Dagger : Weapon
    {
        public Dagger() : base("Dagger", "+1 damage, + 5% crit", WeaponType.ONEH) { }

        public override void OnDequip(PlayerCharacter c)
        {
            c.bonusCritChance -= 0.05f;
            c.bonusDamageDone -= 1;
        }

        public override void OnEquip(PlayerCharacter c)
        {
            c.bonusCritChance += 0.05f;
            c.bonusDamageDone += 1;
        }
    }
}
