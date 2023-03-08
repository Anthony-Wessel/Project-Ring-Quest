using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public static class Fonts
    {
        public static SpriteFont defaultFont;
        public static SpriteFont large;
        
        public static void LoadFonts(ContentManager content)
        {
            defaultFont = content.Load<SpriteFont>("Fonts/DefaultFont");
            large = content.Load<SpriteFont>("Fonts/Large");
        }
    }
}
