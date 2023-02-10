using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class LoreEvent : TileEvent
    {
        string title, prompt, buttonTxt;

        public LoreEvent(string title, string prompt, string buttonTxt)
        {
            this.title = title;
            this.prompt = prompt;
            this.buttonTxt = buttonTxt;

            sprite = ImageDB.LoreEvent;
        }

        public override void StartEvent(Action<bool> OnCompleted)
        {
            PromptPanel.DisplayPrompt(title, prompt, new Dictionary<string, Action>() { { buttonTxt,
            () => {
                PromptPanel.Hide();
                OnCompleted.Invoke(true);
                tile.SetEvent(null);
            } } });
        }
    }
}
