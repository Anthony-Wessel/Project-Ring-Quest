using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class AApplyEffect : Ability
    {
        public Effect effect;

        public AApplyEffect(Effect effect)
        {
            this.effect = effect;
            targetFriendly = effect.helpful;
            cooldown = 0;
        }

        public override void Cast(Character source, Character target)
        {
            target.ApplyEffect(effect);
        }

        public override string Description { get { return "Applies Effect"; } }
        public override string Name { get { return "Apply Effect"; } }
        public override Texture2D Image { get { return ImageDB.Key; } }
    }
}
