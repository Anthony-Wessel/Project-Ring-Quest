﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Sword : Weapon
    {
        public Sword() : base("Sword", "+2 damage", WeaponType.ONEH) { }

        public override void OnDequip(PlayerCharacter c)
        {
            c.bonusDamageDone -= 2;
        }

        public override void OnEquip(PlayerCharacter c)
        {
            c.bonusDamageDone += 2;
        }
    }
}
