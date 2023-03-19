using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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

        UIList equipmentList, inventoryList;
        Point ItemSlotSize = new Point(300, 80);

        public EquipmentUI() : base(new Rectangle(560,40,900,1000))
        {
            equipmentList = new UIList(new Rectangle(rect.X + 400, rect.Y, 500, 500));
            AddChild(equipmentList);
            equipmentList.spacing = 15;


            helmSlot = new ItemGUI(new Rectangle(Point.Zero, ItemSlotSize));
            equipmentList.AddChild(helmSlot);

            armorSlot = new ItemGUI(new Rectangle(Point.Zero, ItemSlotSize));
            equipmentList.AddChild(armorSlot);
            
            accessorySlot = new ItemGUI(new Rectangle(Point.Zero, ItemSlotSize));
            equipmentList.AddChild(accessorySlot);

            weaponSlot = new ItemGUI(new Rectangle(Point.Zero, ItemSlotSize));
            equipmentList.AddChild(weaponSlot);

            offhandSlot = new ItemGUI(new Rectangle(Point.Zero, ItemSlotSize));
            equipmentList.AddChild(offhandSlot);



            inventoryList = new UIList(new Rectangle(rect.X, rect.Y, 400, 1000));
            AddChild(inventoryList);
            inventoryList.spacing = 10;

            inventory = Player.character.inventory;
            inventoryGUI = new List<ItemGUI>();
            for (int i = 0; i < inventory.Size; i++)
            {
                ItemGUI newItemGUI = new ItemGUI(new Rectangle(Point.Zero, ItemSlotSize));
                inventoryGUI.Add(newItemGUI);
                inventoryList.AddChild(newItemGUI);
            }

            SetInventoryItems();
            inventory.onInventoryChanged += SetInventoryItems;

            SetEquipmentItems();
            PlayerEquipment.onEquipmentUpdated += SetEquipmentItems;

            active = true;
        }

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageDB.Panel, inventoryList.rect, Color.DarkGray);
            spriteBatch.Draw(ImageDB.Panel, equipmentList.rect, Color.Gray);
            spriteBatch.Draw(ImageDB.Panel, new Rectangle(rect.X + 400, rect.Y + 500, 500, 500), Color.White);
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
                ItemGUI newItemGUI = new ItemGUI(new Rectangle(Point.Zero, ItemSlotSize));
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
    }
}
