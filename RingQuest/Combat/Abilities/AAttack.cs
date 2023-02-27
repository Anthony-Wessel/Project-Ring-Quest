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

        public AAttack(int minDamage, int maxDamage)
        {
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;

            targetFriendly = false;
            cooldown = 0;
        }

        public override void Cast(Character source, Character target)
        {
            target.TakeDamage(RNG.NextInt(minDamage, maxDamage+1));
        }

        public override string Description { get { return minDamage + "-" + maxDamage + " damage"; } }
        public override string Name { get { return "Attack"; } }
        public override Texture2D Image { get { return ImageDB.CombatEvent; } }
    }
}
