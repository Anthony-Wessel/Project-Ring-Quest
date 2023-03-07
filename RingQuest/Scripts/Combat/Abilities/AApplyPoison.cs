using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class AApplyPoison : Ability
    {
        public EPoison effect;

        public AApplyPoison(EPoison effect) : base("Apply Poison", effect.damagePerTurn + " dmg/turn for " + effect.remainingDuration + "turns", ImageDB.Key, 0, effect.helpful)
        {
            this.effect = effect;
        }

        public override void Cast(Character source, Character target)
        {
            base.Cast(source, target);

            target.ApplyEffect(effect);
        }
    }
}
