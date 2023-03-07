using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Player
    {
        public static PlayerCharacter character;

        public Tile currentTile;
        public Rectangle rect;

        bool moving;
        float moveStartTime;
        Tile previousTile;
        Tile desiredTile;

        public Player(Tile t)
        {
            currentTile = t;
            rect = t.rect;

            t.Uncover();

            moving = false;

            character = new PlayerCharacter("Antony", ImageDB.Player, 60);
            character.ApplyEffect(new EIncreaseHealth(10));
        }

        public void MoveTo(Tile t)
        {
            if (moving) return;

            desiredTile = t;

            if (t.covered)
                t.Uncover();

            if (t.tEvent != null)
                t.tEvent.StartEvent(CompleteMove);
            else
                CompleteMove(true);
        }

        public void CompleteMove(bool successfulMove)
        {
            if (!successfulMove)
            {
                moving = false;
                desiredTile = currentTile;
                return;
            }

            moving = true;

            previousTile = currentTile;
            currentTile = desiredTile;
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
