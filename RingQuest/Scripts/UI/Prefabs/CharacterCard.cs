using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class CharacterCard : Button
    {
        Image image;
        UIText name;
        HealthBar healthBar;

        Character character;

        Vector2 normalSize, expandedSize;
        FloatRect targetRect;
        double sizeChangeTime;
        bool changingSize;

        public CharacterCard() : base(new FloatRect(100, 100, 300, 400))
        {
            character = null;

            image = new Image(new FloatRect(rect.X, rect.Y, 300, 300), ImageDB.Blank);
            AddChild(image);

            name = new UIText(new FloatRect(rect.X, rect.Y + 300, 300, 50), "", Fonts.defaultFont, Color.Black);
            AddChild(name);

            healthBar = new HealthBar(new FloatRect(rect.X, rect.Y + 350, 300, 50), 0, 0);
            AddChild(healthBar);

            normalSize = rect.Size;
            expandedSize = rect.Size;
            expandedSize.X = (int)(1.03f * expandedSize.X);
            expandedSize.Y = (int)(1.03f * expandedSize.Y);

            targetRect = rect;

            CombatManager.OnNewTurnStarted += CheckSize;
        }

        public void SetCharacter(Character character)
        {
            this.character = character;
            character.onCharacterUpdated += updateUI;
            character.onHealthChanged = (amount) => HealthPopups.Display(image.rect, amount);

            updateUI();

            // Set button functionality
            ReInit(()=> CombatManager.SelectTarget(character));
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

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.DrawSelf(gameTime, spriteBatch);

            spriteBatch.Draw(ImageDB.CharacterFrame, rect.rectangle, Color.White);
        }

        void CheckSize(Character activeCharacter)
        {
            if (activeCharacter == character) Grow();
            else Shrink();
        }

        public void Grow()
        {
            if (rect.Size == expandedSize) return;

            sizeChangeTime = Time.Now();
            targetRect = new FloatRect(rect.Location, expandedSize);
            changingSize = true;
        }

        public void Shrink()
        {
            if (rect.Size == normalSize) return;

            sizeChangeTime = Time.Now();
            targetRect = new FloatRect(rect.Location, normalSize);
            changingSize = true;
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (changingSize)
            {
                if (Time.Now() - sizeChangeTime > 0.25)
                {
                    rect = targetRect;
                    changingSize = false;
                }
                else
                {
                    rect = RectangleUtil.Lerp(rect, targetRect, 0.1f);
                }
            }
            
        }
    }
}
