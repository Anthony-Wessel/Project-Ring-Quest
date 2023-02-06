using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Player
    {
        public Tile currentTile;
        public Rectangle rect;
        public Texture2D sprite { get { return ImageDB.Player; } }

        public Player(Tile t)
        {
            currentTile = t;
            rect = t.rect;
        }
        
        public void MoveTo(Tile t)
        {
            t.Uncover();

            currentTile = t;
            rect = t.rect;
        }
    }
}
