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
        public Rectangle rect { get; set; }
        Rectangle remainingRect;
        int currentHealth, maxHealth;
        UIText text;

        public HealthBar(Rectangle rect, int currentHealth, int maxHealth)
        {
            this.rect = rect;
            remainingRect = new Rectangle(rect.X, rect.Y, calculateRemainingWidth(currentHealth, maxHealth), rect.Height);
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;

            text = new UIText(rect, currentHealth + " / " + maxHealth);
        }

        public void Update(int currentHealth, int maxHealth)
        {
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;

            remainingRect.Width = calculateRemainingWidth(currentHealth, maxHealth);
            text.text = currentHealth + " / " + maxHealth;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageDB.Blank, rect, Color.Red);
            spriteBatch.Draw(ImageDB.Blank, remainingRect, Color.Green);
            text.Draw(gameTime, spriteBatch);
        }

        int calculateRemainingWidth(int currentHealth, int maxHealth)
        {
            float percent = (float)currentHealth / maxHealth;
            return (int)(percent * rect.Width);
        }
    }
}
