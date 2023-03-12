using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public abstract class Armor : Equipment
    {
        public Armor(string name, string description) : base(name, description, EquipSlot.CHEST)
        {
        }
    }
}
