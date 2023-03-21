using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RingQuest.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class AbilityCard : Button
    {
        Ability ability;

        public UIText name, description;
        public Image image;
        public CooldownDisplay cooldownDisplay;

        public AbilityCard() : this(new FloatRect(0,0,100,150), null) { }

        public AbilityCard(FloatRect rect, Ability ability) : base(rect)
        {
            image = new Image(new FloatRect(), ImageDB.Blank);
            AddChild(image);

            cooldownDisplay = new CooldownDisplay(new FloatRect());
            AddChild(cooldownDisplay);

            name = new UIText(new FloatRect(), "", Fonts.defaultFont, Color.Black);
            AddChild(name);

            description = new UIText(new FloatRect(), "", Fonts.defaultFont, Color.Black);
            AddChild(description);

            UpdateRects();
            SetAbility(ability);
        }

        public void UpdateRects()
        {
            // Create image
            FloatRect r1 = rect;
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

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.DrawSelf(gameTime, spriteBatch);

            // TODO: Move to a more suitable spot, preferably an event
            if (ability != null)
                cooldownDisplay.Update(ability.remainingCooldown);

            spriteBatch.Draw(ImageDB.Panel, rect.rectangle, Color.White);
        }

        public void SetAbility(Ability ability)
        {
            this.ability = ability;

            if (ability == null) return;

            image.image = ability.image;
            name.text = ability.name;
            description.text = ability.description;
            
            // Set button functionality
            ReInit(() => CombatManager.SelectAbility(ability));
        }
    }
}
