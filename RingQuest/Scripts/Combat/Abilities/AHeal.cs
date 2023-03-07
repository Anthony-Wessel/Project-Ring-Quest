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

        public AHeal(int amount) : base("Heal", amount + " healing", ImageDB.OpenExit, 2, true)
        {
            this.amount = amount;
        }

        public override void Cast(Character source, Character target)
        {
            base.Cast(source, target);

            target.Heal(RNG.NextInt(amount));
        }
    }
}
