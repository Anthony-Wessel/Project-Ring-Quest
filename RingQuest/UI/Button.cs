using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Button : UIElement
    {
        public Rectangle rect { get; set; }
        UIText text;
        Action OnClick;

        public Button(Rectangle rect, string text, Action OnClick)
        {
            this.rect = rect;
            this.text = new UIText(rect, text);
            this.OnClick = OnClick;
        }

        public Dictionary<Texture2D, Rectangle> GetSprites()
        {
            Dictionary<Texture2D, Rectangle> result = new Dictionary<Texture2D, Rectangle>();
            result.Add(ImageDB.Button, rect);

            // TODO: Render text

            return result;
        }
    }
}
