using Microsoft.Xna.Framework;
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
        public Rectangle rect { get; set; }
        HorizontalGroup abilityGroup, optionsGroup, itemGroup;

        Pool<AbilityCard> abilityCards;

        public CombatOptions(Rectangle rect)
        {
            this.rect = rect;
            Rectangle oneThirdRect = rect;
            oneThirdRect.Width = rect.Width / 3;

            abilityGroup = new HorizontalGroup(oneThirdRect, null);

            oneThirdRect.X += oneThirdRect.Width;
            optionsGroup = new HorizontalGroup(oneThirdRect, null);

            oneThirdRect.X += oneThirdRect.Width;
            itemGroup = new HorizontalGroup(oneThirdRect, null);



            abilityCards = new Pool<AbilityCard>();
        }

        public void Open(Character player)
        {
            abilityGroup.children.Clear();

            abilityCards.Clear();
            
            foreach (Ability a in player.abilities)
            {
                AbilityCard ac = abilityCards.Request();
                ac.SetAbility(a);
                abilityGroup.children.Add(ac);

            }
            
            abilityGroup.ConfigurePlacement();
        }
        
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageDB.Blank, rect, Color.Black);

            abilityGroup.Draw(gameTime, spriteBatch);
            optionsGroup.Draw(gameTime, spriteBatch);
            itemGroup.Draw(gameTime, spriteBatch);
        }
    }
}
