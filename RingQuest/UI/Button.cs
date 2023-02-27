using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RingQuest.My_Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Button : UIElement, IBatchable
    {
        Rectangle r;
        public Rectangle rect { get { return r; } set { r = value; if (text != null) { text.rect = value; text.SetText(text.text); } } }
        UIText text;
        Action OnClick;

        bool pressed, hovered;
        bool skipFrame;
        public bool active { get; set; }

        public Button() : this(new Rectangle(0, 0, 100, 50), "", null){ }

        public Button(Rectangle rect, string text, Action OnClick)
        {
            Init(rect, text, OnClick);
            GameManager.Instance.updateChildren += Update;
        }

        public void Init(Rectangle rect, string text, Action OnClick)
        {
            this.rect = rect;
            if (this.text == null) this.text = new UIText(rect, text);
            else
            {
                this.text.rect = rect;
                this.text.SetText(text);
            }

            this.OnClick = OnClick;

            skipFrame = true;
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
            if (!active) return;

            if (skipFrame)
            {
                skipFrame = false;
                return;
            }

            if (rect.Contains(Input.GetMousePosition()))
            {
                hovered = true;
                if (Input.GetMouseButtonDown(0))
                {
                    pressed = true;
                }
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
