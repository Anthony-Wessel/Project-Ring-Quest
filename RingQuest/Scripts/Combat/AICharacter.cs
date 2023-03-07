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

        public AICharacter(AICharacter original) : base(original.name, original.sprite, original.maxHealth)
        {
            isEnemy = original.isEnemy;
        }

        public override void TakeTurn()
        {
            foreach (Character c in CombatManager.turnQueue)
            {
                if (c.isEnemy != isEnemy)
                {
                    c.TakeDamage(this, 1);
                    CombatManager.StartNewTurn();
                    return;
                }
            }
        }
    }
}
