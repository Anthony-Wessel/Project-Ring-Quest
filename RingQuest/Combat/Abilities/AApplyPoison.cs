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

        public AApplyPoison(EPoison effect)
        {
            this.effect = effect;
            targetFriendly = effect.helpful;
            cooldown = 0;
        }

        public override void Cast(Character source, Character target)
        {
            target.ApplyEffect(effect);
        }

        public override string Description { get { return effect.damagePerTurn + " dmg/turn for " + effect.remainingDuration + "turns"; } }
        public override string Name { get { return "Apply Poison"; } }
        public override Texture2D Image { get { return ImageDB.Key; } }
    }
}
