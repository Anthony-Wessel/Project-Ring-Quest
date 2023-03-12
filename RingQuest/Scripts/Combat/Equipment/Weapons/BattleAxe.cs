using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class BattleAxe : Weapon
    {
        public BattleAxe() : base("BattleAxe", "+4 damage", WeaponType.TWOH) { }

        public override void OnDequip(PlayerCharacter c)
        {
            c.bonusDamageDone -= 4;
        }

        public override void OnEquip(PlayerCharacter c)
        {
            c.bonusDamageDone += 4;
        }
    }
}
