using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public abstract class Ability
    {
        public bool targetFriendly;
        public int cooldown, remainingCooldown;
        public bool isReady { get { return remainingCooldown == 0; } }

        public virtual void Cast(Character source, Character target)
        {
            remainingCooldown = cooldown;
        }

        public virtual string Name { get { return "NULL"; } }
        public virtual string Description { get { return "NULL"; } }
        public virtual Texture2D Image { get { return ImageDB.Blank; } }

        public void DecrementCooldown()
        {
            if (remainingCooldown > 0)
                remainingCooldown -= 1;
        }

    }
}
