﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Image : UIElement
    {
        public Texture2D image;

        public Image(FloatRect rect, Texture2D image) : base(rect)
        {
            this.image = image;
        }

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, rect.rectangle, Color.White);
        }
    }
}
