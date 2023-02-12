using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class CharacterCard : UIElement
    {
        public Rectangle rect { get; set; }
        Rectangle charSpriteRect;

        Texture2D charSprite;
        int currentHealth, maxHealth;

        UIText name;
        HealthBar healthBar;

        public CharacterCard()
        {
            rect = new Rectangle(100, 100, 300, 400);
            charSpriteRect = new Rectangle(rect.X, rect.Y, 300, 300);

            charSprite = ImageDB.C_Lizard;
            currentHealth = 7;
            maxHealth = 10;

            name = new UIText(new Rectangle(rect.X, rect.Y + 300, 300, 50), "Lizardman");
            healthBar = new HealthBar(new Rectangle(rect.X, rect.Y + 350, 300, 50), currentHealth, maxHealth);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draw other stuff
            spriteBatch.Draw(charSprite, charSpriteRect, Color.White);
            name.Draw(gameTime, spriteBatch);
            healthBar.Draw(gameTime, spriteBatch);

            // Draw frame
            spriteBatch.Draw(ImageDB.CharacterFrame, rect, Color.White);
        }
    }
}
