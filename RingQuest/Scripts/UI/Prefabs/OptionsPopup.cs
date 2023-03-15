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
    public class OptionsPopup : UIElement
    {
        UIList buttons;

        int itemHeight;

        public OptionsPopup(Rectangle rect) : base(rect)
        {
            itemHeight = rect.Height;


            buttons = new UIList(rect);
            AddChild(buttons);
            
            for (int i = 0; i < 3; i++)
            {
                buttons.AddChild(new Button(rect, "", null));
                (buttons[i] as Button).active = false;
            }
        }

        public void OpenPopup(IItem clickedItem)
        {
            (buttons[0] as Button).ReInit("Equip", () => PlayerEquipment.Equip(clickedItem as Weapon));
            (buttons[0] as Button).active = true;

            (buttons[1] as Button).ReInit("Print", () => Debug.WriteLine(clickedItem.Name));
            (buttons[1] as Button).active = true;

            (buttons[2] as Button).active = false;

            active = false;
        }

        public void HidePopup()
        {
            active = true;
        }

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageDB.Panel, rect, Color.Black);
        }
    }
}
