using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class PlayerCharacter : Character
    {
        public PlayerCharacter(string name, Texture2D sprite, int maxHealth) : base(name, sprite, maxHealth)
        {
            isEnemy = false;
        }

        public override void TakeTurn()
        {
            // Request player input
            // Wait for callback
        }
    }
}
