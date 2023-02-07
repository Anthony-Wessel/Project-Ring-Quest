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

        bool moving;
        float moveStartTime;
        Tile previousTile;

        public Player(Tile t)
        {
            currentTile = t;
            rect = t.rect;

            t.Uncover();

            moving = false;
        }
        
        public void MoveTo(Tile t)
        {
            if (moving) return;

            t.Uncover();
            // Wait 0.5s
            // Tile event

            // If successful then move
            previousTile = currentTile;
            currentTile = t;
            moving = true;
            moveStartTime = -1;
        }

        public void Update(GameTime gameTime)
        {
            if (moving)
            {
                if (moveStartTime == -1) moveStartTime = (float)gameTime.TotalGameTime.TotalSeconds;

                float progress = ((float)gameTime.TotalGameTime.TotalSeconds - moveStartTime) / 0.5f;

                if (progress < 0.95f)
                {
                    Vector2 calculatedPosition = Vector2.Lerp(previousTile.rect.Location.ToVector2(), currentTile.rect.Location.ToVector2(), progress);

                    rect.Location = calculatedPosition.ToPoint();
                }
                else
                {
                    rect.Location = currentTile.rect.Location;
                    moving = false;
                }
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageDB.Player, rect, Color.White);
        }
    }
}
