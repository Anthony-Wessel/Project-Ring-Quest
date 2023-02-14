using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class PlayerCharacter : Character
    {
        bool waitingForInput;
        public PlayerCharacter(string name, Texture2D sprite, int maxHealth) : base(name, sprite, maxHealth)
        {
            isEnemy = false;
            waitingForInput = false;
            GameManager.Instance.updateChildren += Update;
        }

        public override void TakeTurn()
        {
            Debug.WriteLine("Player turn");
            waitingForInput = true;
        }

        void Update(GameTime gameTime)
        {
            if (waitingForInput && Input.GetKeyDown(Keys.Space))
            {
                foreach (Character c in CombatManager.turnQueue)
                {
                    if (c.isEnemy != isEnemy)
                    {
                        waitingForInput = false;

                        c.TakeDamage(1);
                        CombatManager.StartNewTurn();
                        return;
                    }
                }
            }
        }
    }
}
