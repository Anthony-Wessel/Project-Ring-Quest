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

        public static Panel PromptPanel(string title, string prompt, Dictionary<string, Action> options)
        {
            Panel promptPanel = new Panel(new Rectangle(610, 290, 700, 500));

            // Title
            promptPanel.AddUIElement(new UIText(new Rectangle(670, 315,600,50), title));

            // Prompt
            promptPanel.AddUIElement(new UIText(new Rectangle(720, 390, 500, 300), prompt));

            // Options
            List<UIElement> buttons = new List<UIElement>();
            foreach (string option in options.Keys)
            {
                buttons.Add(Button.UIButton(Point.Zero, option, options[option]));
            }

            promptPanel.AddUIElement(new HorizontalGroup(new Rectangle(720,690,500,100), buttons));

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
