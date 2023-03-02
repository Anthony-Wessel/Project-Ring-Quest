using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class EPoison : Effect
    {
        public int damagePerTurn;

        public EPoison(int duration, int damagePerTurn) : base(duration, EffectType.POISON, false)
        {
            this.damagePerTurn = damagePerTurn;
        }

        public override void DoSomething(Character effectedCharacter)
        {
            effectedCharacter.TakeDamage(damagePerTurn);
        }
    }
}
