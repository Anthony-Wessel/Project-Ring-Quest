﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class ItemGUI : Button
    {
        public Image image;
        public UIText text;

        public ItemGUI(FloatRect rect) : base(rect)
        {
            image = new Image(new FloatRect(rect.X, rect.Y, rect.Height, rect.Height), ImageDB.ChoiceEvent);
            AddChild(image);

            text = new UIText(new FloatRect(rect.X + rect.Height, rect.Y, rect.Width - rect.Height, rect.Height), "", Fonts.defaultFont, Color.Black);
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

            ReInit(() => OptionsPopup.OpenPopup(item, Input.GetMousePosition()));
        }

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.DrawSelf(gameTime, spriteBatch);

            spriteBatch.Draw(ImageDB.Panel, rect.rectangle, Color.White);
        }
    }
}
