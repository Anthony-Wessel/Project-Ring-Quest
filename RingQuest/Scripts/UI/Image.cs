using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Image : UIElement
    {
        public Rectangle rect { get; set; }
        public Texture2D image;

        public Image(Rectangle rect, Texture2D image)
        {
            this.rect = rect;
            this.image = image;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, rect, Color.White);
        }
    }
}
