using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Button : UIElement
    {
        public Rectangle rect { get; set; }
        UIText text;
        Action OnClick;

        public Button(Rectangle rect, string text, Action OnClick)
        {
            this.rect = rect;
            this.text = new UIText(rect, text);
            this.OnClick = OnClick;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageDB.Button, rect, Color.White);

            text.Draw(gameTime, spriteBatch);
        }
    }
}
