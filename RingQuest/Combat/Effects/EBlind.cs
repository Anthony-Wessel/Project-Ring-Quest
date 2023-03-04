using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class EBlind : Effect
    {
        float accuracyDecrease;
        public EBlind(int duration, float accuracyDecrease) : base(duration, EffectType.BLIND, false)
        {
            this.accuracyDecrease = accuracyDecrease;
        }

        public override void OnApplied(Character effectedCharacter)
        {
            effectedCharacter.accuracy -= accuracyDecrease;
        }

        public override void OnRemoved(Character effectedCharacter)
        {
            effectedCharacter.accuracy += accuracyDecrease;
        }

        public override void OnTurnEnded(Character effectedCharacter)
        {
            // NOTHING
        }

        public override void OnTurnStarted(Character effectedCharacter)
        {
            // NOTHING
        }
    }
}
