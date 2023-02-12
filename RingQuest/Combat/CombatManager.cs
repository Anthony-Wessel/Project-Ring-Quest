using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public static class CombatManager
    {
        public static Queue<Character> turnQueue;

        static Character activeCharacter;

        public static void Init()
        {
            turnQueue = new Queue<Character>();
        }

        public static void BeginNewCombat(PlayerCharacter pc, List<Character> enemies)
        {
            turnQueue.Enqueue(pc);
            foreach (Character c in enemies)
            {
                turnQueue.Enqueue(c);
            }

            StartNewTurn();
        }

        public static void StartNewTurn()
        {
            activeCharacter = turnQueue.Dequeue();
            turnQueue.Enqueue(activeCharacter);

            activeCharacter.TakeTurn();
        }
    }
}
