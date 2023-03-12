using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public interface IItem
    {
        public Texture2D Sprite { get; }
        public string Name { get; }
        public string Description { get; }
    }
}
