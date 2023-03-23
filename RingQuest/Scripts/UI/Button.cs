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


        public Button(FloatRect rect) : base(rect)
        {
            Input.OnMouseClicked += CheckClick;
        }

        public void ReInit(Action OnClick)
        {
            this.OnClick = OnClick;
        }

        void CheckClick(Vector2 mousePosition)
        {
            if (!active) return;

            requestClickTrigger = rect.rectangle.Contains(mousePosition);
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
    }
}
