using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class HealthBar : UIElement
    {
        FloatRect remainingRect;
        UIText text;

        public HealthBar(FloatRect rect, int currentHealth, int maxHealth) : base(rect)
        {
            remainingRect = rect;
            remainingRect.Width = calculateRemainingWidth(currentHealth, maxHealth);

            text = new UIText(rect, currentHealth + " / " + maxHealth, Fonts.defaultFont, Color.Black);
            AddChild(text);
        }

        public void Update(int currentHealth, int maxHealth)
        {
            remainingRect.Width = calculateRemainingWidth(currentHealth, maxHealth);
            text.text = currentHealth + " / " + maxHealth;
        }

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            remainingRect.Location = rect.Location;

            spriteBatch.Draw(ImageDB.Blank, rect.rectangle, Color.Red);
            spriteBatch.Draw(ImageDB.Blank, remainingRect.rectangle, Color.Green);
        }

        int calculateRemainingWidth(int currentHealth, int maxHealth)
        {
            float percent = (float)currentHealth / maxHealth;
            return (int)(percent * rect.Width);
        }
    }
}
