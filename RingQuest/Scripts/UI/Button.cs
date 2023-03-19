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
        public Action OnClick;
        bool requestClickTrigger;

        public bool pressed, hovered;
        bool skipFrame;

        public Button(Rectangle rect) : base(rect)
        {
            GameManager.Instance.updateChildren += Update;
            Input.OnMouseClicked += CheckClick;
        }

        public void ReInit(Action OnClick)
        {
            this.OnClick = OnClick;
            skipFrame = true;

            hovered = false;
            pressed = false;
        }

        void CheckClick(Point mousePosition)
        {
            if (!active) return;

            requestClickTrigger = rect.Contains(mousePosition);
        }

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (requestClickTrigger)
            {
                Input.RequestClick(OnClick);
                requestClickTrigger = false;
            }

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
