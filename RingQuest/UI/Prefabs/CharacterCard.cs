using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RingQuest.My_Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class CharacterCard : UIElement, IBatchable
    {
        Rectangle r;
        public Rectangle rect { get { return r; }
            set
            {
                if (image != null)
                    image.rect = image.rect.ScaleProportionately(r, value);
                if (name != null)
                    name.rect = name.rect.ScaleProportionately(r, value);
                if (healthBar != null)
                    healthBar.rect = healthBar.rect.ScaleProportionately(r, value);

                r = value;
            }
        }

        Image image;
        UIText name;
        HealthBar healthBar;

        Character character;

        public bool active { get; set; }

        public CharacterCard()
        {
            character = null;

            rect = new Rectangle(100, 100, 300, 400);
            image = new Image(new Rectangle(rect.X, rect.Y, 300, 300), ImageDB.Blank);

            name = new UIText(new Rectangle(rect.X, rect.Y + 300, 300, 50), "");
            healthBar = new HealthBar(new Rectangle(rect.X, rect.Y + 350, 300, 50), 0, 0);
        }

        public void SetCharacter(Character character)
        {
            this.character = character;
            character.onCharacterUpdated += updateUI;

            updateUI();
        }

        void updateUI()
        {
            if (character.isDead)
            {
                name.text = "---";
                healthBar.Update(0, character.maxHealth);
                image.image = ImageDB.OpenExit;
            }
            else
            {
                name.text = character.name;
                healthBar.Update(character.currentHealth, character.maxHealth);
                image.image = character.sprite;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!active) return;

            // Draw other stuff
            image.Draw(gameTime, spriteBatch);
            name.Draw(gameTime, spriteBatch);
            healthBar.Draw(gameTime, spriteBatch);

            // Draw frame
            spriteBatch.Draw(ImageDB.CharacterFrame, rect, Color.White);
        }
    }
}
