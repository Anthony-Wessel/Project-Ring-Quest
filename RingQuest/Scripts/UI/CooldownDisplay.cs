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
        bool hidden;

        public CooldownDisplay(Rectangle rect) : base(rect, ImageDB.Blank)
        {
            numberDisplay = new UIText(rect, "---", Fonts.large, Color.Black);
            AddChild(numberDisplay);
        }

        public void Update(int cooldownRemaining)
        {
            numberDisplay.text = cooldownRemaining.ToString();

            if (cooldownRemaining == 0) hidden = true;
            else hidden = false;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!hidden)
                base.Draw(gameTime, spriteBatch);
        }
    }
}
