using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public abstract class Ability
    {
        public bool targetFriendly;

        public abstract void Cast(Character source, Character target);


    }
}
