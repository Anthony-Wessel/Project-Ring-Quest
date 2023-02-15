using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Panel : UIElement
    {
        Rectangle r;
        public Rectangle rect { get { return r; } set { if (childElements != null) { foreach (UIElement element in childElements) element.rect = element.rect.ScaleProportionately(r, value); } r = value; } }
        public List<UIElement> childElements;
        public bool hidden;

        public Panel(Rectangle rect)
        {
            this.rect = rect;
            childElements = new List<UIElement>();
        }

        public void AddUIElement(UIElement element)
        {
            childElements.Add(element);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (hidden) return;

            spriteBatch.Draw(ImageDB.Panel, rect, Color.White);

            foreach (UIElement element in childElements)
            {
                element.Draw(gameTime, spriteBatch);
            }
        }
    }
}
