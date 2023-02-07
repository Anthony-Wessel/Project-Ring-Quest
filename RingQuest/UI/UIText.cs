using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    // TODO: DOES THIS NEED TO BE A UIELEMENT
    public class UIText : UIElement
    {
        public Rectangle rect { get; set; }
        string text;

        public UIText(Rectangle rect, string text)
        {
            this.rect = rect;
            this.text = text;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
        }
    }
}
