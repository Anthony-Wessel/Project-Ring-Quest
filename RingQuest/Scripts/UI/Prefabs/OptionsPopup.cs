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
        public static OptionsPopup instance;

        UIList buttons;

        int itemHeight;

        public OptionsPopup() : base(new Rectangle(0,0,100,50))
        {
            itemHeight = rect.Height;

            buttons = new UIList(rect);
            AddChild(buttons);
            
            for (int i = 0; i < 3; i++)
            {
                buttons.AddChild(new TextButton(rect, "", null));
                (buttons[i] as TextButton).active = false;
            }

            active = false;

            instance = this;

            Input.OnMouseClicked += (x) => { if (!rect.Contains(x)) HidePopup(); };
        }

        public static void OpenPopup(IItem clickedItem, Point location)
        {
            instance.rect = new Rectangle(location, instance.rect.Size);

            (instance.buttons[0] as TextButton).ReInit("Equip", () => { PlayerEquipment.Equip(clickedItem as Weapon); HidePopup(); });
            (instance.buttons[0] as TextButton).active = true;

            (instance.buttons[1] as TextButton).ReInit("Print", () => { Debug.WriteLine(clickedItem.Name); HidePopup(); });
            (instance.buttons[1] as TextButton).active = true;

            (instance.buttons[2] as TextButton).active = false;

            instance.active = true;
        }

        public static void HidePopup()
        {
            instance.active = false;
            foreach (UIElement element in instance.buttons.children)
            {
                element.active = false;
            }
        }

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageDB.Panel, rect, Color.Black);
        }
    }
}
