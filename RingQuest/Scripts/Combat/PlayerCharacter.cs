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
        public PlayerCharacter(string name, Texture2D sprite, int maxHealth) : base(name, sprite, maxHealth)
        {
            isEnemy = false;

            abilities.Add(new AAttack(2, 4));
            abilities.Add(new AHeal(8));
            abilities.Add(new AApplyPoison(new EPoison(3, 2)));
        }

        public override void TakeTurn()
        {
            CombatManager.playersActiveAbility = abilities[0];
        }
    }
}
