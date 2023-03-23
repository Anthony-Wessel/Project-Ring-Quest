using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public delegate void EventTrigger();


    public delegate void IntEventTrigger(int i);
    public delegate void Vector2EventTrigger(Vector2 vector);


    public delegate void GameTimeEventTrigger(GameTime gameTime);
    public delegate void CharacterEventTrigger(Character character);
}
