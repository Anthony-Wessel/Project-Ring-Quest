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
    public abstract class UIElement
    {
        public List<UIElement> children;
        public bool active;

        public UIElement(FloatRect rect)
        {
            children = new List<UIElement>();

            active = true;

            this.rect = rect;
        }

        public virtual void AddChild(UIElement newChild)
        {
            children.Add(newChild);
        }

        public virtual void RemoveChild(UIElement child)
        {
            children.Remove(child);
        }

        public void Clear()
        {
            children.Clear();
        }

        protected virtual void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!active) return;

            DrawSelf(gameTime, spriteBatch);

            foreach (UIElement child in children)
            {
                child.Draw(gameTime, spriteBatch);
            }
        }

        private FloatRect r;
        public FloatRect rect
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
