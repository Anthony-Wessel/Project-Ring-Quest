﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public enum EffectType
    {
        POISON,
        ENRAGE,
        BLEED,
        BURN,
        BLIND,
        STUN
    }

    public abstract class Effect
    {
        public int remainingDuration;
        public EffectType type;
        public bool helpful;

        public Effect(int duration, EffectType type, bool helpful)
        {
            remainingDuration = duration;
            this.type = type;
            this.helpful = helpful;
        }

        public abstract void OnTurnStarted(Character effectedCharacter);
        public abstract void OnTurnEnded(Character effectedCharacter);
        public abstract void OnApplied(Character effectedCharacter);
        public abstract void OnRemoved(Character effectedCharacter);

        public abstract Effect Copy();
    }
}
