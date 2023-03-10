using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RingQuest.My_Utilities;
using RingQuest.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class AbilityCard : UIElement, IPoolable
    {
        Point expandedSize, reducedSize;
        Ability ability;

        public UIText name, description;
        public Image image;
        public CooldownDisplay cooldownDisplay;

        public bool active { get; set; }
        bool pressed;

        public AbilityCard() : this(new Rectangle(0,0,100,150), Point.Zero, null) { }

        public AbilityCard(Rectangle rect, Point expandedSize, Ability ability) : base(rect)
        {
            image = new Image(Rectangle.Empty, ImageDB.Blank);
            AddChild(image);

            cooldownDisplay = new CooldownDisplay(Rectangle.Empty);
            AddChild(cooldownDisplay);

            name = new UIText(Rectangle.Empty, "", Fonts.defaultFont, Color.Black);
            AddChild(name);

            description = new UIText(Rectangle.Empty, "", Fonts.defaultFont, Color.Black);
            AddChild(description);

            reducedSize = rect.Size;
            this.expandedSize = expandedSize;

            UpdateRects();
            SetAbility(ability);

            GameManager.Instance.updateChildren += Update;
        }

        public void UpdateRects()
        {
            // Create image
            Rectangle r1 = rect;
            r1.Height = (int)(rect.Height * 0.5);
            image.rect = r1;
            cooldownDisplay.rect = r1;

            // Create name text
            r1.Y += r1.Height;
            r1.Height = (int)(rect.Height * 0.15);
            name.rect = r1;

            // Create description text
            r1.Y += r1.Height;
            r1.Height = (int)(rect.Height * 0.35);
            description.rect = r1;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!active) return;

            spriteBatch.Draw(ImageDB.Panel, rect, Color.White);

            base.Draw(gameTime, spriteBatch);
        }

        public void SetAbility(Ability ability)
        {
            this.ability = ability;

            if (ability == null) return;

            image.image = ability.image;
            name.text = ability.name;
            description.text = ability.description;
        }

        void Update(GameTime gameTime)
        {
            if (!active) return;

            cooldownDisplay.Update(ability.remainingCooldown);

            if (rect.Contains(Input.GetMousePosition()))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    pressed = true;
                }
                if (Input.GetMouseButtonUp(0) && pressed)
                {
                    pressed = false;
                    CombatManager.SelectAbility(ability);
                }
            }
            else
            {
                pressed = false;
            }
        }
    }
}
