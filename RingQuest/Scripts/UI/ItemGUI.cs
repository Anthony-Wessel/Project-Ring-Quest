using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class ItemGUI : UIElement
    {
        public Image image;
        public UIText text;

        public ItemGUI(Rectangle rect) : base(rect)
        {
            image = new Image(new Rectangle(rect.X, rect.Y, rect.Height, rect.Height), ImageDB.ChoiceEvent);
            AddChild(image);

            text = new UIText(new Rectangle(rect.X + rect.Height, rect.Y, rect.Width - rect.Height, rect.Height), "", Fonts.defaultFont, Color.Black);
            AddChild(text);
        }

        public void SetItem(IItem item)
        {
            if (item == null)
            {
                image.image = ImageDB.ChoiceEvent;
                text.text = "Nothing";
                return;
            }

            image.image = item.Sprite;
            text.text = item.Name + "\n" + item.Description;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageDB.Panel, rect, Color.White);

            base.Draw(gameTime, spriteBatch);
        }
    }
}
