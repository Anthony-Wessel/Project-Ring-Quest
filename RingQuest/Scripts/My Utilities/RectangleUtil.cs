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
        
        public static FloatRect ScaleProportionately(this FloatRect original, FloatRect from, FloatRect to)
        {
            if (from.Equals(to)) return original;

            float xProgress = (original.X - from.X) / from.Width;
            float yProgress = (original.Y - from.Y) / from.Height;

            float widthMultiplier = to.Width / from.Width;
            float heightMultiplier = to.Height / from.Height;

            FloatRect newRect = new FloatRect();
            newRect.X = to.X + (xProgress * to.Width);
            newRect.Y = to.Y + (yProgress * to.Height);
            newRect.Width = original.Width * widthMultiplier;
            newRect.Height = original.Height * heightMultiplier;

            return newRect;
        }

        public static FloatRect Lerp(FloatRect a, FloatRect b, float t)
        {
            return new FloatRect(MathHelper.Lerp(a.X, b.X, t),
                                MathHelper.Lerp(a.Y, b.Y, t),
                                MathHelper.Lerp(a.Width, b.Width, t),
                                MathHelper.Lerp(a.Height, b.Height, t));
        }
    }
}
