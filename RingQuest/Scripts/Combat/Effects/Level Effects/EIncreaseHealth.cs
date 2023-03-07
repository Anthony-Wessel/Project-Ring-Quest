using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class EIncreaseHealth : Effect
    {
        int amount;
        public EIncreaseHealth(int amount) : base(-1, EffectType.BUFF, true, EffectPermanence.LEVEL)
        {
            this.amount = amount;
        }

        public override Effect Copy()
        {
            return new EIncreaseHealth(amount);
        }

        public override void OnApplied(Character effectedCharacter)
        {
            effectedCharacter.maxHealth += amount;
            effectedCharacter.currentHealth += amount;
        }

        public override void OnRemoved(Character effectedCharacter)
        {
            effectedCharacter.maxHealth -= amount;
            effectedCharacter.currentHealth -= amount;
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
