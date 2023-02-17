using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class KeyEvent : TileEvent
    {
        public KeyEvent()
        {
            sprite = ImageDB.Key;
        }

        public override void StartEvent(Action<bool> OnCompleted)
        {
            PromptPanel.DisplayPrompt("You found the key!", "Now that you possess the key, you just need to find the exit tile and you will be able to leave the dungeon.",
                new Dictionary<string, Action> { { "Awesome!", () => { PromptPanel.Hide(); GameManager.Instance.UnlockExit(); tile.SetEvent(null); Debug.Write("KEY FOUND"); OnCompleted(true); } } });
        }
    }
}
