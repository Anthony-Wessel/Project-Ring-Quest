using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class HorizontalGroup : UIElement
    {
        public Rectangle rect { get; set; }
        public List<UIElement> children;

        public HorizontalGroup(Rectangle rect, List<UIElement> children)
        {
            Init(rect, children);
        }

        public void ConfigurePlacement()
        {
            float summedWidth = 0;
            foreach (UIElement child in children)
            {
                summedWidth += child.rect.Width;
            }

            float remainingWidth = rect.Width - summedWidth;
            int gaps = children.Count - 1;
            int gapSize = (int)(remainingWidth / gaps);

            int currentX = rect.X;
            foreach (UIElement child in children)
            {
                child.rect = new Rectangle(new Point(currentX, rect.Y + (rect.Height - child.rect.Height) / 2), child.rect.Size);
                currentX += child.rect.Width + gapSize;
            }
        }

        public void Init(Rectangle rect, List<UIElement> children)
        {
            this.rect = rect;
            if (children == null) this.children = new List<UIElement>();
            else this.children = children;

            ConfigurePlacement();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (UIElement child in children)
            {
                child.Draw(gameTime, spriteBatch);
            }
        }
    }
}
