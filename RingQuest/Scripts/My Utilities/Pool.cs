using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Pool<T> where T : new()
    {
        public List<T> active;
        private List<T> inactive;

        public Pool()
        {
            active = new List<T>();
            inactive = new List<T>();
        }

        public void Clear()
        {
            for (int i = active.Count-1; i >= 0; i--)
            {
                Remove(active[i]);
            }
        }

        public T Request()
        {
            T newItem;

            if (inactive.Count > 0)
            {
                newItem = inactive[0];
                inactive.RemoveAt(0);
                active.Add(newItem);
                return newItem;
            }

            newItem = new T();
            active.Add(newItem);
            return newItem;
        }

        public void Remove(T item)
        {
            inactive.Add(item);
            active.Remove(item);
        }
    }
}
