using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    class ALeech : Ability
    {
        public int minDamage, maxDamage;
        public float percentLeech;

        public ALeech(int minDamage, int maxDamage, float percentLeech) : base("Leech", minDamage + "-" + maxDamage + " damage and " + percentLeech + " leech", ImageDB.C_Ninja, 1, false)
        {
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.percentLeech = percentLeech;
        }

        public override void Cast(Character source, Character target)
        {
            base.Cast(source, target);

            int damageAmount = target.TakeDamage(source, RNG.NextInt(minDamage, maxDamage + 1));
            source.Heal((int)(percentLeech * damageAmount));
        }
    }
}
