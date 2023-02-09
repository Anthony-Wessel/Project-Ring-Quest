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
        Rectangle r;
        public Rectangle rect { get { return r; } set { r = value; if (text != null) text.rect = value; } }
        UIText text;
        Action OnClick;

        bool pressed, hovered;

        public Button(Rectangle rect, string text, Action OnClick)
        {
            this.rect = rect;
            this.text = new UIText(rect, text);
            this.OnClick = OnClick;

            GameManager.Instance.updateChildren += Update;
        }

        public static Button UIButton(Point position, string text, Action OnClick)
        {
            Button uiButton = new Button(new Rectangle(position, new Point(100, 50)), text, OnClick);


            return uiButton;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Texture2D tex;
            if (pressed) tex = ImageDB.Button_Pressed;
            else if (hovered) tex = ImageDB.Button_Hovered;
            else tex = ImageDB.Button;

            spriteBatch.Draw(tex, rect, Color.White);

            text.Draw(gameTime, spriteBatch);
        }

        void Update(GameTime gameTime)
        {
            if (rect.Contains(Input.GetMousePosition()))
            {
                hovered = true;
                if (Input.GetMouseButtonDown(0)) pressed = true;
                if (Input.GetMouseButtonUp(0) && pressed)
                {
                    pressed = false;
                    OnClick.Invoke();
                }
            }
            else
            {
                hovered = false;
                pressed = false;
            }
        }
    }
}
