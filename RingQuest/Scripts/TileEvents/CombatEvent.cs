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

        public CombatEvent(CombatEvent original)
        {
            enemies = new List<AICharacter>();
            foreach (AICharacter enemy in original.enemies)
            {
                enemies.Add(new AICharacter(enemy));
            }

            sprite = original.sprite;
        }

        public override void StartEvent(Action<bool> OnCompleted)
        {
            CombatManager.BeginNewCombat(Player.character, enemies, (x) => { if (x) tile.SetEvent(null); OnCompleted(x); });
            // TODO: Handle loss by retreat or defeat
        }
    }
}
