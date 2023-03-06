using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class EStun : Effect
    {
        public EStun(int duration) : base(duration, EffectType.STUN, false) { }

        public override void OnApplied(Character effectedCharacter)
        {
            // NOTHING
        }

        public override void OnRemoved(Character effectedCharacter)
        {
            // NOTHING
        }

        public override void OnTurnEnded(Character effectedCharacter)
        {
            // NOTHING
        }

        public override void OnTurnStarted(Character effectedCharacter)
        {
            CombatManager.StartNewTurn();
        }

        public override Effect Copy()
        {
            return new EStun(remainingDuration);
        }
    }
}
