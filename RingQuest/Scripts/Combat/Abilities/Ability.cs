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
        public string name, description;
        public Texture2D image;
        public bool targetFriendly;
        public int cooldown, remainingCooldown;
        public bool isReady { get { return remainingCooldown == 0; } }

        public Ability(string name, string description, Texture2D image, int cooldown, bool targetFriendly)
        {
            this.name = name;
            this.description = description;
            this.image = image;

            this.cooldown = cooldown;
            remainingCooldown = 0;

            this.targetFriendly = targetFriendly;
        }

        public virtual void Cast(Character source, Character target)
        {
            remainingCooldown = cooldown + 1;
        }

        public void DecrementCooldown()
        {
            if (remainingCooldown > 0)
                remainingCooldown -= 1;
        }
    }
}
