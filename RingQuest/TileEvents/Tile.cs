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
        public bool covered;

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

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageDB.TileBackground, rect, Color.White);

            if (covered) spriteBatch.Draw(ImageDB.TileCover, rect, Color.White);
            else if (tEvent != null) spriteBatch.Draw(tEvent.sprite, rect, Color.White);
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

        public void SetEvent(TileEvent tEvent)
        {
            if (tEvent != null)
                tEvent.tile = this;
            this.tEvent = tEvent;
        }
    }
}
