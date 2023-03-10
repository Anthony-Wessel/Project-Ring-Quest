using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public static class RectangleUtil
    {
        public static Rectangle ScaleProportionately(this Rectangle original, Rectangle from, Rectangle to)
        {
            if (original == from) return to;

            float xProgress = (float)(original.X - from.X) / from.Width;
            float yProgress = (float)(original.Y - from.Y) / from.Height;

            float widthMultiplier = (float)to.Width / from.Width;
            float heightMultiplier = (float)to.Height / from.Height;

            Rectangle newRect = new Rectangle();
            newRect.X = (int)(to.X + (xProgress * to.Width));
            newRect.Y = (int)(to.Y + (yProgress * to.Height));
            newRect.Width = (int)(original.Width * widthMultiplier);
            newRect.Height = (int)(original.Height * heightMultiplier);

            return newRect;
        }
    }
}
