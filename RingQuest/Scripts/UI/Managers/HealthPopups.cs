using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RingQuest.My_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    class HealthPopup : IPoolable
    {
        public UIText UIText;
        public double spawnTime;
        public Color baseColor;

        public void Init(string text, Color color, Point position)
        {
            if (UIText == null) UIText = new UIText(Rectangle.Empty, "", Fonts.large, Color.Black);

            UIText.text = text;
            UIText.rect = new Rectangle(position, Point.Zero);
            UIText.color = color;

            baseColor = color;

            spawnTime = -1;
        }

        public bool active { get; set; }
    }

    public static class HealthPopups
    {
        static Pool<HealthPopup> popups = new Pool<HealthPopup>();

        public static void Display(Rectangle area, int amount)
        {
            HealthPopup newPopup = popups.Request();
            Point position = new Point(RNG.NextInt(area.X, area.X + area.Width), RNG.NextInt(area.Y, area.Y + area.Height));
            
            if (amount > 0)
            {
                newPopup.Init("+" + amount, Color.Green, position);
            }
            else if (amount < 0)
            {
                newPopup.Init(amount.ToString(), Color.Red, position);
            }
            else
            {
                newPopup.Init("miss", Color.Blue, position);
            }
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            for(int i = popups.tList.Count-1; i >= 0; i--)
            {
                HealthPopup popup = popups.tList[i];
                if (popup.active)
                {
                    if (popup.spawnTime == -1) popup.spawnTime = gameTime.TotalGameTime.TotalSeconds;

                    double lifetime = gameTime.TotalGameTime.TotalSeconds - popup.spawnTime;
                    if (lifetime > 0.75)
                    {
                        popups.Remove(popup);
                    }
                    else
                    {
                        float alpha;
                        if (lifetime > 0.5)
                        {
                            alpha = (float)(1 - ((lifetime - 0.5) / 0.25));
                        }
                        else alpha = 1;

                        popup.UIText.color = popup.baseColor * alpha;
                        popup.UIText.Draw(gameTime, spriteBatch);
                    }
                }
            }
        }

        public static void Clear()
        {
            popups.Clear();
        }
    }
}