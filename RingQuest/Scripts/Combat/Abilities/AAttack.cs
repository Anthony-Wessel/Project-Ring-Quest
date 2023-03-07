using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class AAttack : Ability
    {
        int minDamage, maxDamage;

        public AAttack(int minDamage, int maxDamage) : base("Attack", minDamage + "-" + maxDamage + " damage", ImageDB.CombatEvent, 0, false)
        {
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
        }

        public override void Cast(Character source, Character target)
        {
            base.Cast(source, target);

            target.TakeDamage(source, RNG.NextInt(minDamage, maxDamage+1));
        }
    }
}
