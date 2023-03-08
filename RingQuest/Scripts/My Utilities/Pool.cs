using RingQuest.My_Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Pool<T> where T : IPoolable, new()
    {
        public List<T> tList;

        public Pool()
        {
            tList = new List<T>();
        }

        public void Clear()
        {
            foreach (T item in tList)
            {
                Remove(item);
            }
        }

        public T Request()
        {
            foreach (T item in tList)
            {
                if (!item.active)
                {
                    item.active = true;
                    return item;
                }
            }

            T newItem = new T();
            tList.Add(newItem);
            newItem.active = true;
            return newItem;
        }

        public void Remove(T item)
        {
            item.active = false;
        }
    }
}
