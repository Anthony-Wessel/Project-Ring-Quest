using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class EquipmentUI : UIElement
    {
        ItemGUI helmSlot, armorSlot, accessorySlot, weaponSlot, offhandSlot;

        List<ItemGUI> inventoryGUI;
        Inventory inventory;

        UIText characterName, healthStat, damageDoneStat, damageTakenStat, accuracyStat, critChanceStat, critDamageStat;

        UIList equipmentList, inventoryList, statList;
        Vector2 ItemSlotSize = new Vector2(300, 80);

        public EquipmentUI() : base(new FloatRect(560,40,900,1000))
        {
            equipmentList = new UIList(new FloatRect(rect.X + 400, rect.Y, 500, 500));
            AddChild(equipmentList);
            equipmentList.spacing = 15;

            helmSlot = new ItemGUI(new FloatRect(Vector2.Zero, ItemSlotSize));
            equipmentList.AddChild(helmSlot);

            armorSlot = new ItemGUI(new FloatRect(Vector2.Zero, ItemSlotSize));
            equipmentList.AddChild(armorSlot);
            
            accessorySlot = new ItemGUI(new FloatRect(Vector2.Zero, ItemSlotSize));
            equipmentList.AddChild(accessorySlot);

            weaponSlot = new ItemGUI(new FloatRect(Vector2.Zero, ItemSlotSize));
            equipmentList.AddChild(weaponSlot);

            offhandSlot = new ItemGUI(new FloatRect(Vector2.Zero, ItemSlotSize));
            equipmentList.AddChild(offhandSlot);

            SetEquipmentItems();
            PlayerEquipment.onEquipmentUpdated += SetEquipmentItems;



            inventoryList = new UIList(new FloatRect(rect.X, rect.Y, 400, 1000));
            AddChild(inventoryList);
            inventoryList.spacing = 10;

            inventory = Player.character.inventory;
            inventoryGUI = new List<ItemGUI>();
            for (int i = 0; i < inventory.Size; i++)
            {
                ItemGUI newItemGUI = new ItemGUI(new FloatRect(Vector2.Zero, ItemSlotSize));
                inventoryGUI.Add(newItemGUI);
                inventoryList.AddChild(newItemGUI);
            }

            SetInventoryItems();
            inventory.onInventoryChanged += SetInventoryItems;



            statList = new UIList(new FloatRect(rect.X + 400, rect.Y + 500, 500, 500));
            AddChild(statList);

            FloatRect singleStatRect = statList.rect;
            singleStatRect.Height = 40;

            characterName = new UIText(singleStatRect, "", Fonts.defaultFont, Color.Black);
            statList.AddChild(characterName);

            healthStat = new UIText(singleStatRect, "", Fonts.defaultFont, Color.Black);
            statList.AddChild(healthStat);

            damageDoneStat = new UIText(singleStatRect, "", Fonts.defaultFont, Color.Black);
            statList.AddChild(damageDoneStat);

            damageTakenStat = new UIText(singleStatRect, "", Fonts.defaultFont, Color.Black);
            statList.AddChild(damageTakenStat);

            accuracyStat = new UIText(singleStatRect, "", Fonts.defaultFont, Color.Black);
            statList.AddChild(accuracyStat);

            critChanceStat = new UIText(singleStatRect, "", Fonts.defaultFont, Color.Black);
            statList.AddChild(critChanceStat);

            critDamageStat = new UIText(singleStatRect, "", Fonts.defaultFont, Color.Black);
            statList.AddChild(critDamageStat);

            UpdateStats();
            PlayerEquipment.onEquipmentUpdated += UpdateStats;



            active = false;
        }

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageDB.Panel, inventoryList.rect.rectangle, Color.DarkGray);
            spriteBatch.Draw(ImageDB.Panel, equipmentList.rect.rectangle, Color.Gray);
            spriteBatch.Draw(ImageDB.Panel, statList.rect.rectangle, Color.White);
        }

        void SetInventoryItems()
        {
            // Remove extra itemGUIs
            while (inventoryGUI.Count > inventory.Size)
            {
                ItemGUI itemToRemove = inventoryGUI[inventoryGUI.Count - 1];
                inventoryGUI.Remove(itemToRemove);
                inventoryList.RemoveChild(itemToRemove);
            }

            // Add enough itemGUIs to represent whole inventory
            while (inventoryGUI.Count < inventory.Size)
            {
                ItemGUI newItemGUI = new ItemGUI(new FloatRect(Vector2.Zero, ItemSlotSize));
                inventoryGUI.Add(newItemGUI);
                inventoryList.AddChild(newItemGUI);
            }

            // Set items for all itemGUIs
            for (int i = 0; i < inventory.Size; i++)
            {
                inventoryGUI[i].SetItem(inventory.items[i]);
            }
        }

        void SetEquipmentItems()
        {
            helmSlot.SetItem(PlayerEquipment.equippedHelmet);
            armorSlot.SetItem(PlayerEquipment.equippedArmor);
            accessorySlot.SetItem(PlayerEquipment.equippedAccessory);
            weaponSlot.SetItem(PlayerEquipment.equippedWeapon);
            offhandSlot.SetItem(PlayerEquipment.equippedOffhand);
        }

        void UpdateStats()
        {
            Character c = Player.character;
            characterName.text = c.name;
            healthStat.text = "Health: " + c.currentHealth + " / " + c.maxHealth;
            damageDoneStat.text = "Damage: " + c.bonusDamageDone;
            damageTakenStat.text = "Armor: " + c.bonusDamageTaken;
            accuracyStat.text = "Accuracy: " + c.accuracy;
            critChanceStat.text = "Crit Chance: " + c.bonusCritChance;
            critDamageStat.text = "Crit Multiplier: " + c.bonusCritMultiplier;
        }
    }
}
