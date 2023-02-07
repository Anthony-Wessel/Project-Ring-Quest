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
        public Dictionary<Texture2D, Rectangle> GetSprites();
        public Rectangle rect { get; set; }
    }
}
