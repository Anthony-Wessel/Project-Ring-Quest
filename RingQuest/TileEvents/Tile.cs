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
        public const int SIZE = 128;

        public Rectangle rect;
        public TileEvent tEvent;
        bool covered;

        List<Tile> adjacentTiles;

        public Tile(Vector2 position)
        {
            rect = new Rectangle((int)position.X, (int)position.Y, SIZE, SIZE);
            covered = true;

            adjacentTiles = new List<Tile>();
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

        public void Connect(Tile t)
        {
            adjacentTiles.Add(t);
            t.adjacentTiles.Add(this);
        }

        public bool IsTileAdjacent(Tile t)
        {
            return adjacentTiles.Contains(t);
        }
    }
}
