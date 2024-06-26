﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class CombatOptions : UIElement
    {
        HorizontalGroup abilityGroup, optionsGroup, itemGroup;

        Pool<AbilityCard> abilityCards;

        public CombatOptions(FloatRect rect) : base(rect)
        {
            this.rect = rect;
            FloatRect oneThirdRect = rect;
            oneThirdRect.Width = rect.Width / 3;

            abilityGroup = new HorizontalGroup(oneThirdRect);
            AddChild(abilityGroup);

            oneThirdRect.X += oneThirdRect.Width;
            optionsGroup = new HorizontalGroup(oneThirdRect);
            AddChild(optionsGroup);

            oneThirdRect.X += oneThirdRect.Width;
            itemGroup = new HorizontalGroup(oneThirdRect);
            AddChild(itemGroup);

            abilityCards = new Pool<AbilityCard>();
        }

        public void Open(Character player)
        {
            abilityGroup.Clear();
            abilityCards.Clear();
            
            foreach (Ability a in player.abilities)
            {
                AbilityCard ac = abilityCards.Request();
                ac.SetAbility(a);
                abilityGroup.AddChild(ac);
            }
        }
        
        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageDB.Blank, rect.rectangle, Color.Black);
        }
    }
}
