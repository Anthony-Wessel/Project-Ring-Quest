using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class EEnrage : Effect
    {
        int bonusDamageDone, bonusDamageTaken;

        public EEnrage(int duration, int bonusDamageDone, int bonusDamageTaken) : base(duration, EffectType.ENRAGE, true, EffectPermanence.COMBAT)
        {
            this.bonusDamageDone = bonusDamageDone;
            this.bonusDamageTaken = bonusDamageTaken;
        }

        public override void OnTurnEnded(Character effectedCharacter)
        {
            // NOTHING
        }

        public override void OnApplied(Character effectedCharacter)
        {
            effectedCharacter.bonusDamageDone += bonusDamageDone;
            effectedCharacter.bonusDamageTaken += bonusDamageTaken;
        }

        public override void OnRemoved(Character effectedCharacter)
        {
            effectedCharacter.bonusDamageDone -= bonusDamageDone;
            effectedCharacter.bonusDamageTaken -= bonusDamageTaken;
        }

        public override void OnTurnStarted(Character effectedCharacter)
        {
            // NOTHING
        }

        public override Effect Copy()
        {
            return new EEnrage(remainingDuration, bonusDamageDone, bonusDamageTaken);
        }
    }
}
