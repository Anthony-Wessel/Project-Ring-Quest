using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Inventory
    {
        public IItem[] items;

        public int Size { get => items.Length; }

        public event EventTrigger onInventoryChanged;

        public Inventory(int size)
        {
            items = new IItem[size];

            onInventoryChanged = () => { };
        }

        public bool Add(IItem item)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null)
                {
                    items[i] = item;
                    onInventoryChanged();
                    return true;
                }
            }

            // No space in inventory
            return false;
        }

        public void Remove(IItem item)
        {
            bool found = false;
            for (int i = 0; i < items.Length; i++)
            {
                if (!found && items[i] == item)
                {
                    found = true;
                }

                if (found) items[i] = (i+1 == items.Count() ? null : items[i + 1]);
            }
            if (found) onInventoryChanged();
        }

        public void ChangeSize(int newSize)
        {
            if (newSize < items.Length) throw new Exception("Cannot shrink inventory size");

            IItem[] newArray = new IItem[newSize];
            for (int i = 0; i < items.Length; i++)
            {
                newArray[i] = items[i];
            }

            items = newArray;
        }
    }
}
