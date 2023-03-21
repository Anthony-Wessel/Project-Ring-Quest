using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest.Scripts.UI
{
    public class CooldownDisplay : Image
    {
        UIText numberDisplay;

        public CooldownDisplay(FloatRect rect) : base(rect, ImageDB.Blank)
        {
            numberDisplay = new UIText(rect, "---", Fonts.large, Color.Black);
            AddChild(numberDisplay);
            active = false;
        }

        public void Update(int cooldownRemaining)
        {
            numberDisplay.text = cooldownRemaining.ToString();

            if (cooldownRemaining == 0) active = false;
            else active = true;
        }

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.DrawSelf(gameTime, spriteBatch);
        }
    }
}
