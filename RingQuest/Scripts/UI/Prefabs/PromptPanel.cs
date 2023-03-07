﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class PromptPanel : Panel
    {
        static PromptPanel instance;

        UIText title, prompt;
        Batch<Button> buttons;
        HorizontalGroup buttonGroup;

        public PromptPanel() : base(new Rectangle(610, 290, 700, 500))
        {
            // Title
            title = new UIText(new Rectangle(670, 315, 600, 50), "");
            AddUIElement(title);

            // Prompt
            prompt = new UIText(new Rectangle(720, 390, 500, 300), "");
            AddUIElement(prompt);

            buttons = new Batch<Button>();

            buttonGroup = new HorizontalGroup(new Rectangle(720, 690, 500, 100), null);
            AddUIElement(buttonGroup);

            instance = this;
            Hide();
        }

        public static void DisplayPrompt(string title, string prompt, Dictionary<string, Action> options)
        {
            instance.title.SetText(title);
            instance.prompt.SetText(prompt);


            instance.buttonGroup.children.Clear();

            instance.buttons.Clear();
            foreach (string option in options.Keys)
            {
                Button b = instance.buttons.Request();
                b.Init(b.rect, option, options[option]);
                instance.buttonGroup.children.Add(b);
            }

            instance.buttonGroup.ConfigurePlacement();

            instance.hidden = false;
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
            instance.hidden = true;
            instance.buttons.Clear();
        }
    }
}