using Microsoft.Xna.Framework;
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

        public bool pressed, hovered;
        bool skipFrame;

        public Button(Rectangle rect) : base(rect)
        {
            GameManager.Instance.updateChildren += Update;
        }

        public void ReInit(Action OnClick)
        {
            this.OnClick = OnClick;
            skipFrame = true;

            hovered = false;
            pressed = false;
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
