using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class PromptPanel : UIElement
    {
        static PromptPanel instance;

        UIText title, prompt;
        Pool<TextButton> buttons;
        HorizontalGroup buttonGroup;

        public PromptPanel() : base(new Rectangle(610, 290, 700, 500))
        {
            // Title
            title = new UIText(new Rectangle(670, 315, 600, 50), "", Fonts.defaultFont, Color.Black);
            AddChild(title);

            // Prompt
            prompt = new UIText(new Rectangle(720, 390, 500, 300), "", Fonts.defaultFont, Color.Black);
            AddChild(prompt);

            buttons = new Pool<TextButton>();

            buttonGroup = new HorizontalGroup(new Rectangle(720, 690, 500, 100));
            AddChild(buttonGroup);

            instance = this;
            Hide();
        }

        public static void DisplayPrompt(string title, string prompt, Dictionary<string, Action> options)
        {
            instance.title.SetText(title);
            instance.prompt.SetText(prompt);

            instance.buttonGroup.Clear();
            instance.buttons.Clear();

            foreach (string option in options.Keys)
            {
                TextButton b = instance.buttons.Request();
                b.ReInit(option, options[option]);
                b.active = true;
                instance.buttonGroup.AddChild(b);
            }

            instance.buttonGroup.ConfigurePlacement();

            instance.active = true;
        }

        public static void DisplaySimplePrompt(string title, string prompt, string buttonText, Action OnButtonPressed)
        {
            DisplayPrompt(title, prompt, new Dictionary<string, Action>() { { buttonText,
            () => {
                Hide();
                if (OnButtonPressed != null)
                    OnButtonPressed.Invoke();
            } } });
        }

        public static void Hide()
        {
            instance.active = false;
            instance.buttons.Clear();
        }

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageDB.Panel, rect, Color.White);
        }
    }
}
