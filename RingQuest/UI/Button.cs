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

        bool pressed, hovered;

        public Button(Rectangle rect, string text, Action OnClick)
        {
            this.rect = rect;
            this.text = new UIText(rect, text);
            this.OnClick = OnClick;

            GameManager.Instance.updateChildren += Update;
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
            Screen.SetWindowTitle(gameTime.TotalGameTime.TotalSeconds + "");
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
