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

        UIText name;
        HealthBar healthBar;

        Character character;

        public CharacterCard(Character character)
        {
            this.character = character;

            rect = new Rectangle(100, 100, 300, 400);
            charSpriteRect = new Rectangle(rect.X, rect.Y, 300, 300);

            name = new UIText(new Rectangle(rect.X, rect.Y + 300, 300, 50), character.name);
            healthBar = new HealthBar(new Rectangle(rect.X, rect.Y + 350, 300, 50), character.currentHealth, character.maxHealth);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // Draw other stuff
            spriteBatch.Draw(character.sprite, charSpriteRect, Color.White);
            name.Draw(gameTime, spriteBatch);
            healthBar.Draw(gameTime, spriteBatch);

            // Draw frame
            spriteBatch.Draw(ImageDB.CharacterFrame, rect, Color.White);
        }
    }
}
