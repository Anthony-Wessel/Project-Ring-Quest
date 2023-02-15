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
    public class CharacterCard : UIElement
    {
        Rectangle r;
        public Rectangle rect { get { return r; }
            set
            {
                spriteRect = spriteRect.ScaleProportionately(r, value);
                if (name != null)
                    name.rect = name.rect.ScaleProportionately(r, value);
                if (healthBar != null)
                    healthBar.rect = healthBar.rect.ScaleProportionately(r, value);

                r = value;
            }
        }
        Rectangle spriteRect;

        UIText name;
        HealthBar healthBar;

        Character character;

        public bool active;

        public CharacterCard()
        {
            character = null;

            rect = new Rectangle(100, 100, 300, 400);
            spriteRect = new Rectangle(rect.X, rect.Y, 300, 300);

            name = new UIText(new Rectangle(rect.X, rect.Y + 300, 300, 50), "");
            healthBar = new HealthBar(new Rectangle(rect.X, rect.Y + 350, 300, 50), 0, 0);

            active = true;
        }

        public void SetCharacter(Character character)
        {
            this.character = character;
            character.onCharacterUpdated += updateUI;

            updateUI();

            active = true;
        }

        void updateUI()
        {
            if (character.isDead)
            {
                name.text = "---";
                healthBar.Update(0, character.maxHealth);
            }
            else
            {
                name.text = character.name;
                healthBar.Update(character.currentHealth, character.maxHealth);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!active) return;
            
            // Draw other stuff
            if (character != null)
                spriteBatch.Draw(character.sprite, spriteRect, Color.White);

            name.Draw(gameTime, spriteBatch);
            healthBar.Draw(gameTime, spriteBatch);

            // Draw frame
            spriteBatch.Draw(ImageDB.CharacterFrame, rect, Color.White);
        }
    }
}
