using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public enum EquipSlot
    {
        HELM,
        CHEST,
        WEAPON,
        ACCESSORY
    }

    public abstract class Equipment : IItem
    {
        public string name, description;
        public EquipSlot slot;

        public Texture2D Sprite { get { return ImageDB.ChoiceEvent; } }
        public string Name { get { return name; } }
        public string Description { get { return description; } }

        public Equipment(string name, string description, EquipSlot slot)
        {
            this.name = name;
            this.description = description;
            this.slot = slot;
        }

        public abstract void OnEquip(PlayerCharacter c);
        public abstract void OnDequip(PlayerCharacter c);
    }
}
