using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RingQuest.My_Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class CharacterCard : UIElement, IPoolable
    {
        Image image;
        UIText name;
        HealthBar healthBar;

        Character character;

        public bool active { get; set; }
        bool pressed;

        public CharacterCard() : base(new Rectangle(100, 100, 300, 400))
        {
            character = null;

            image = new Image(new Rectangle(rect.X, rect.Y, 300, 300), ImageDB.Blank);
            AddChild(image);

            name = new UIText(new Rectangle(rect.X, rect.Y + 300, 300, 50), "", Fonts.defaultFont, Color.Black);
            AddChild(name);

            healthBar = new HealthBar(new Rectangle(rect.X, rect.Y + 350, 300, 50), 0, 0);
            AddChild(healthBar);

            GameManager.Instance.updateChildren += Update;
        }

        public void SetCharacter(Character character)
        {
            this.character = character;
            character.onCharacterUpdated += updateUI;
            character.onHealthChanged = (amount) => HealthPopups.Display(image.rect, amount);

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

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!active) return;

            base.Draw(gameTime, spriteBatch);

            // Draw frame
            spriteBatch.Draw(ImageDB.CharacterFrame, rect, Color.White);
        }

        void Update(GameTime gameTime)
        {
            if (!active) return;

            if (rect.Contains(Input.GetMousePosition()))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    pressed = true;
                }
                if (Input.GetMouseButtonUp(0) && pressed)
                {
                    pressed = false;
                    CombatManager.SelectTarget(character);
                }
            }
            else
            {
                pressed = false;
            }
        }
    }
}
