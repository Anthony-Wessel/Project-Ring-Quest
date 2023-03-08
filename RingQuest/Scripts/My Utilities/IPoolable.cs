using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest.My_Utilities
{
    public interface IPoolable
    {
        public bool active { get; set; }
    }
}
