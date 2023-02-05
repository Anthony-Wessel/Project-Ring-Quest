using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Tile
    {
        static int TILE_SIZE = 64;

        public Rectangle rect;
        public TileEvent tEvent;
        bool covered;

        public Tile(Vector2 position)
        {
            rect = new Rectangle((int)position.X, (int)position.Y, TILE_SIZE, TILE_SIZE);
            covered = true;
        }

        public void Uncover()
        {
            covered = false;
        }

        public List<Texture2D> GetSprites()
        {
            List<Texture2D> result = new List<Texture2D>();
            result.Add(ImageDB.TileBackground);
            if (covered) result.Add(ImageDB.TileCover);
            else if (tEvent != null) result.Add(tEvent.sprite);

            return result;
        }
    }
}
