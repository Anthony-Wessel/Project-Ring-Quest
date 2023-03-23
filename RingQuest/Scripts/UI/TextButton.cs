using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class TextButton : Button
    {
        UIText UIText;
        Texture2D tex;

        double lastPress;

        public TextButton() : this(new FloatRect(0, 0, 100, 50), "", null){ }

        public TextButton(FloatRect rect, string text, Action OnClick) : base(rect)
        {
            UIText = new UIText(rect, text, Fonts.defaultFont, Color.Black);
            AddChild(UIText);

            ReInit(text, OnClick);
        }

        public void ReInit(string text, Action OnClick)
        {
            ReInit(() => { lastPress = Time.Now(); OnClick(); });
            UIText.SetText(text);
        }

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.DrawSelf(gameTime, spriteBatch);

            if (Time.Now() - lastPress < 0.2) tex = ImageDB.Button_Pressed;
            else tex = ImageDB.Button;

            spriteBatch.Draw(tex, rect.rectangle, Color.White);
        }
    }
}
