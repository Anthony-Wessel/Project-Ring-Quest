using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class AHeal : Ability
    {
        int amount;

        public AHeal(int amount)
        {
            this.amount = amount;

            targetFriendly = true;
            cooldown = 2;
        }

        public override void Cast(Character source, Character target)
        {
            target.Heal(RNG.NextInt(amount));
        }

        public override string Description { get { return amount + " healing"; } }
        public override string Name { get { return "Heal"; } }
        public override Texture2D Image { get { return ImageDB.OpenExit; } }
    }
}
