using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public static class RNG
    {
        static Random random;
        public static Random rng
        {
            get
            {
                if (random == null) random = new Random();
                return random;
            }
        }


        public static int NextInt(int minInclusive, int maxExclusive)
        {
            return rng.Next(minInclusive, maxExclusive);
        }

        public static int NextInt(int maxExclusive)
        {
            return NextInt(0, maxExclusive);
        }

        public static float NextFloat(float minInclusive, float maxInclusive)
        {
            float single = rng.NextSingle();
            return minInclusive + (maxInclusive - minInclusive) * single;
        }

        public static float NextFloat(float maxInclusive)
        {
            return NextFloat(0, maxInclusive);
        }

        public static bool NextBool()
        {
            return rng.Next(2) == 0;
        }
    }
}
