using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public abstract class Helmet : Equipment
    {
        public Helmet(string name, string description, EquipSlot slot) : base(name, description, slot)
        {
        }
    }
}
