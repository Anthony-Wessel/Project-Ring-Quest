using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class EBleed : Effect
    {
        int damagePerTurn;

        public EBleed(int duration, int damagePerTurn) : base(duration, EffectType.BLEED, false)
        {
            this.damagePerTurn = damagePerTurn;
        }

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
            effectedCharacter.TakeDamage(null, damagePerTurn);
        }

        public override void OnTurnStarted(Character effectedCharacter)
        {
            // NOTHING
        }

        public override Effect Copy()
        {
            return new EBleed(remainingDuration, damagePerTurn);
        }
    }
}
