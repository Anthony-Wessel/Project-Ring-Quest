using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public abstract class TileEvent
    {
        public Tile tile;
        public Texture2D sprite;

        public abstract void StartEvent(Action<bool> OnCompleted);
    }
}
