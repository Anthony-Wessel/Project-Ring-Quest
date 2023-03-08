using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public static class PlayerEquipment
    {
        public static Character playerCharacter;
        public static Helmet equippedHelmet;
        public static Armor equippedArmor;
        public static Accessory equippedAccessory;

        public static Weapon equippedWeapon, equippedOffhand;

        // HELMET
        public static void Equip(Helmet helmet)
        {
            Dequip(equippedHelmet);

            helmet.OnEquip(playerCharacter);
            equippedHelmet = helmet;
        }

        // ARMOR
        public static void Equip(Armor armor)
        {
            Dequip(equippedArmor);

            armor.OnEquip(playerCharacter);
            equippedArmor = armor;
        }
        
        // ACCESSORY
        public static void Equip(Accessory accessory)
        {
            Dequip(equippedAccessory);

            accessory.OnEquip(playerCharacter);
            equippedAccessory = accessory;
        }

        // WEAPON
        public static void Equip(Weapon weapon)
        {
            if (weapon.type == WeaponType.TWOH)
            {
                Dequip(equippedWeapon);
                Dequip(equippedOffhand);

                weapon.OnEquip(playerCharacter);
                equippedWeapon = weapon;
            }
            else if (weapon.type == WeaponType.OFFHAND)
            {
                Dequip(equippedOffhand);

                weapon.OnEquip(playerCharacter);
                equippedOffhand = weapon;
            }
            else
            {
                if (equippedWeapon == null || equippedOffhand != null)
                {
                    Dequip(equippedWeapon);

                    weapon.OnEquip(playerCharacter);
                    equippedWeapon = weapon;
                }
                else
                {
                    Dequip(equippedOffhand);

                    weapon.OnEquip(playerCharacter);
                    equippedOffhand = weapon;
                }
            }
        }

        public static void Dequip(Equipment equipment)
        {
            if (equipment == null) return;

            equipment.OnDequip(playerCharacter);

            if (equipment == equippedHelmet) equippedHelmet = null;
            else if (equipment == equippedArmor) equippedArmor = null;
            else if (equipment == equippedAccessory) equippedAccessory = null;
            else if (equipment == equippedWeapon) equippedWeapon = null;
            else if (equipment == equippedOffhand) equippedOffhand = null;
        }
    }
}
