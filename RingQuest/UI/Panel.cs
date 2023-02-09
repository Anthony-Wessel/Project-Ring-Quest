using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Panel : UIElement
    {
        public Rectangle rect { get; set; }
        public List<UIElement> childElements;

        public Panel(Rectangle rect)
        {
            this.rect = rect;
            childElements = new List<UIElement>();
        }

        public Panel PromptPanel(string title, string prompt, Dictionary<string, Action> options)
        {
            Panel promptPanel = new Panel(new Rectangle(610, 290, 700, 500));

            // Title
            Vector2 titleSize = Fonts.defaultFont.MeasureString(title);

            // Prompt

            // Options


            return promptPanel;
        }

        public void AddUIElement(UIElement element)
        {
            childElements.Add(element);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageDB.Panel, rect, Color.White);

            foreach (UIElement element in childElements)
            {
                element.Draw(gameTime, spriteBatch);
            }
        }
    }
}
