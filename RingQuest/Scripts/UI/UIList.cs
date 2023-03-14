using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class UIList : UIElement
    {
        public int spacing;

        public UIList(Rectangle rect) : base(rect)
        {
        }

        public UIElement this[int index]
        {
            get => children[index];
            set => children[index] = value;
        }

        public override void AddChild(UIElement newChild)
        {
            base.AddChild(newChild);

            ConfigurePlacement();
        }

        public override void RemoveChild(UIElement child)
        {
            base.RemoveChild(child);

            ConfigurePlacement();
        }

        void ConfigurePlacement()
        {
            int currentY = spacing;
            foreach (UIElement child in children)
            {
                child.rect = new Rectangle(rect.X + (rect.Width - child.rect.Width) / 2, rect.Y + currentY, child.rect.Width, child.rect.Height);
                currentY += child.rect.Height + spacing;
            }
        }
    }
}
