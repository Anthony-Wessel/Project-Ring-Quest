using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class ChoiceEvent : TileEvent
    {
        string title, prompt;
        Dictionary<string, Action> options;

        public ChoiceEvent(string title, string prompt, Dictionary<string, Action> options)
        {
            this.title = title;
            this.prompt = prompt;
            this.options = options;

            sprite = ImageDB.ChoiceEvent;
        }

        public ChoiceEvent(ChoiceEvent original)
        {
            title = original.title;
            prompt = original.prompt;
            options = original.options;

            sprite = original.sprite;
        }

        public override void StartEvent(Action<bool> OnCompleted)
        {
            foreach (string option in options.Keys)
            {
                Action act = options[option];
                options[option] = () => completeEvent(OnCompleted, act);
            }
            PromptPanel.DisplayPrompt(title, prompt, options);
        }

        void completeEvent(Action<bool> OnCompleted, Action optionAction)
        {
            PromptPanel.Hide();
            optionAction.Invoke();
            OnCompleted.Invoke(true);
            tile.SetEvent(null);
        }
    }
}
