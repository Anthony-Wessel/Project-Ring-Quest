using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class HorizontalGroup : UIElement
    {
        public HorizontalGroup(FloatRect rect) : base(rect) { }

        public UIElement this[int index]
        {
            get => children[index];
            set => children[index] = value;
        }

        public int Count => children.Count;

        public override void AddChild(UIElement newChild)
        {
            base.AddChild(newChild);

            ConfigurePlacement();
        }

        public void ConfigurePlacement()
        {
            if (children == null) return;

            if (children.Count == 1)
            {
                children[0].rect = new FloatRect(new Vector2(rect.X + (rect.Width - children[0].rect.Width) / 2, rect.Y + (rect.Height - children[0].rect.Height) / 2), children[0].rect.Size);
                return;
            }

            float summedWidth = 0;
            foreach (UIElement child in children)
            {
                summedWidth += child.rect.Width;
            }

            float remainingWidth = rect.Width - summedWidth;
            int gaps = children.Count;
            float gapSize = remainingWidth / gaps;

            float currentX = rect.X + gapSize/2;
            foreach (UIElement child in children)
            {
                child.rect = new FloatRect(new Vector2(currentX, rect.Y + (rect.Height - child.rect.Height) / 2), child.rect.Size);
                currentX += child.rect.Width + gapSize;
            }
        }

        public void Init(FloatRect rect, List<UIElement> children)
        {
            this.rect = rect;
            if (children == null) this.children = new List<UIElement>();
            else this.children = children;

            ConfigurePlacement();
        }
    }
}
