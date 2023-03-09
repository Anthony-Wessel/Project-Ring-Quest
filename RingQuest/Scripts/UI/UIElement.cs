using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public abstract class UIElement
    {
        protected List<UIElement> children;

        public UIElement(Rectangle rect)
        {
            children = new List<UIElement>();

            this.rect = rect;
        }

        public virtual void AddChild(UIElement newChild)
        {
            children.Add(newChild);
        }

        public void Clear()
        {
            children.Clear();
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (UIElement child in children)
            {
                child.Draw(gameTime, spriteBatch);
            }
        }

        private Rectangle r;
        public Rectangle rect
        {
            get
            {
                return r;
            }
            set
            {
                if (children != null)
                {
                    foreach (UIElement element in children)
                        element.rect = element.rect.ScaleProportionately(r, value);
                }
                r = value;
            }
        }
    }
}
