using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class ExitEvent : TileEvent
    {
        public bool locked;
        public ExitEvent(bool locked)
        {
            this.locked = locked;

            sprite = locked ? ImageDB.LockedExit : ImageDB.OpenExit;
        }

        public void Unlock()
        {
            sprite = ImageDB.OpenExit;
        }

        public override void StartEvent(Action<bool> OnCompleted)
        {
            if (locked)
                PromptPanel.DisplayPrompt("The exit is locked!", "You have found the exit, but it is locked!. You need to find a key to unlock it," +
                                                                    " then return to this exit in order to leave the dungeon.",
                                                                    new Dictionary<string, Action> { { "OK", PromptPanel.Hide } });
            else
                PromptPanel.DisplayPrompt("You found the exit!", "Now that you have found the exit, you can leave with all of your spoils." +
                                                                   "You could also continue exploring the dungeon if you have more to do." +
                                                                    " You can exit the dungeon by returning to this tile at any time.",
                                                                    new Dictionary<string, Action> {
                                                                        { "Leave now", () => { Debug.WriteLine("Exit not implemented yet."); } },
                                                                        { "Keep exploring", () => {PromptPanel.Hide(); OnCompleted(true); } }
                                                                    });
        }
    }
}
