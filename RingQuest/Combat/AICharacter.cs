using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class AICharacter : Character
    {
        public AICharacter(string name, Texture2D sprite, int maxHealth) : base(name, sprite, maxHealth)
        {
            isEnemy = true;
        }

        public override void TakeTurn()
        {
            foreach (Character c in CombatManager.turnQueue)
            {
                if (c.isEnemy != isEnemy)
                {
                    c.TakeDamage(1);
                    CombatManager.StartNewTurn();
                    return;
                }
            }
        }
    }
}
