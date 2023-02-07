using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public interface UIElement
    {
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public Rectangle rect { get; set; }
    }
}
