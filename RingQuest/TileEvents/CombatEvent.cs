using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class CombatEvent : TileEvent
    {
        List<AICharacter> enemies;
        public CombatEvent(List<AICharacter> enemies)
        {
            this.enemies = enemies;
            sprite = ImageDB.CombatEvent;
        }

        public override void StartEvent(Action<bool> OnCompleted)
        {
            CombatManager.BeginNewCombat(Player.character, enemies, (x) => { if (x) tile.SetEvent(null); OnCompleted(x); });
            // TODO: Handle loss by retreat or defeat
        }
    }
}
