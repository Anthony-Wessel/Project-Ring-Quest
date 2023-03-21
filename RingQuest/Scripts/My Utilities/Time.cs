using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public static class Time
    {
        static GameTime gt;

        public static void Update(GameTime gameTime)
        {
            gt = gameTime;
        }

        public static double Now()
        {
            return gt.TotalGameTime.TotalSeconds;
        }
    }
}
