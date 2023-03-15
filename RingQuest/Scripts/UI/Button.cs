using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Button : UIElement
    {
        UIText UIText;
        Action OnClick;

        bool pressed, hovered;
        bool skipFrame;

        public Button() : this(new Rectangle(0, 0, 100, 50), "", null){ }

        public Button(Rectangle rect, string text, Action OnClick) : base(rect)
        {
            UIText = new UIText(rect, text, Fonts.defaultFont, Color.Black);
            AddChild(UIText);

            ReInit(text, OnClick);

            GameManager.Instance.updateChildren += Update;
        }

        public void ReInit(string text, Action OnClick)
        {
            UIText.SetText(text);
           
            this.OnClick = OnClick;

            skipFrame = true;
        }

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Texture2D tex;
            if (pressed) tex = ImageDB.Button_Pressed;
            else if (hovered) tex = ImageDB.Button_Hovered;
            else tex = ImageDB.Button;

            spriteBatch.Draw(tex, rect, Color.White);

            base.DrawSelf(gameTime, spriteBatch);
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
