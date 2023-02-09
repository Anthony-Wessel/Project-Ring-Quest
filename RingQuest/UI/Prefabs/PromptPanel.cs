using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class PromptPanel : Panel
    {
        UIText title, prompt;
        Button[] buttons;
        HorizontalGroup buttonGroup;

        public PromptPanel() : base(new Rectangle(610, 290, 700, 500))
        {
            // Title
            title = new UIText(new Rectangle(670, 315, 600, 50), "");
            AddUIElement(title);

            // Prompt
            prompt = new UIText(new Rectangle(720, 390, 500, 300), "");
            AddUIElement(prompt);

            buttons = new Button[3];
            for (int i = 0; i < buttons.Length; i++)
                buttons[i] = new Button(new Rectangle(0, 0, 100, 50), "", null);

            buttonGroup = new HorizontalGroup(new Rectangle(720, 690, 500, 100), null);
            AddUIElement(buttonGroup);
        }

        public void DisplayPrompt(string title, string prompt, Dictionary<string, Action> options)
        {
            this.title.SetText(title);
            this.prompt.SetText(prompt);


            buttonGroup.children.Clear();

            int index = 0;
            foreach (string option in options.Keys)
            {
                buttons[index].Init(buttons[index].rect, option, options[option]);
                buttonGroup.children.Add(buttons[index]);
                index++;
            }
            while (index < buttons.Length) buttons[index++].Deactivate();

            buttonGroup.ConfigurePlacement();

            hidden = false;
        }
    }
}
