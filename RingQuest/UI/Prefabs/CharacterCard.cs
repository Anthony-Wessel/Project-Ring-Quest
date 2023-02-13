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
    public class CharacterCard : UIElement
    {
        Rectangle r;
        public Rectangle rect { get { return r; }
            set
            {
                r = value;
                spriteRect = new Rectangle(rect.X, rect.Y, 300, 300);
                if (name != null)
                    name.rect = new Rectangle(rect.X, rect.Y + 300, 300, 50);
                if (healthBar != null)
                    healthBar.rect = new Rectangle(rect.X, rect.Y + 350, 300, 50);
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

            name.text = character.name;
            healthBar.Update(character.currentHealth, character.maxHealth);

            active = true;
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
