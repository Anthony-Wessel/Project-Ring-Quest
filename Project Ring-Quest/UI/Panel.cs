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
        public Rectangle rect { get; set; }
        public List<UIElement> childElements;

        public Panel(Rectangle rect)
        {
            this.rect = rect;
            childElements = new List<UIElement>();
        }

        public void AddUIElement(UIElement element)
        {
            childElements.Add(element);
        }

        public Dictionary<Texture2D, Rectangle> GetSprites()
        {
            Dictionary<Texture2D, Rectangle> result = new Dictionary<Texture2D, Rectangle>();

            result.Add(ImageDB.Panel, rect);

            foreach (UIElement element in childElements)
            {
                Dictionary<Texture2D, Rectangle> sprites = element.GetSprites();
                foreach (Texture2D tex in sprites.Keys)
                {
                    result.Add(tex, sprites[tex]);
                }
            }

            return result;
        }
    }
}
