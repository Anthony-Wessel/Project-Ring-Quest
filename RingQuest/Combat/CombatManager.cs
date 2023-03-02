using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public static class CombatManager
    {
        public static Queue<Character> turnQueue;

        static Character activeCharacter;
        static Action<bool> onCompleted;

        static bool combatEnded;
        public static Ability playersActiveAbility;

        public static void Init()
        {
            turnQueue = new Queue<Character>();
        }

        public static void BeginNewCombat(PlayerCharacter pc, List<AICharacter> enemies, Action<bool> OnCompleted = null)
        {
            turnQueue.Enqueue(pc);
            pc.onCharacterUpdated += CheckCharacterStatus;
            foreach (Character c in enemies)
            {
                turnQueue.Enqueue(c);
                c.onCharacterUpdated += CheckCharacterStatus;
            }

            onCompleted = OnCompleted;

            CombatPanel.Instance.Open();

            combatEnded = false;
            StartNewTurn();
        }

        static void CheckCharacterStatus()
        {
            bool playerDefeated = true;
            bool enemiesDefeated = true;
            foreach (Character c in turnQueue)
            {
                if (!c.isDead)
                {
                    if (c.isEnemy) enemiesDefeated = false;
                    else playerDefeated = false;
                }
            }

            if (playerDefeated) EndCombat(false);
            else if (enemiesDefeated) EndCombat(true);
        }

        static void EndCombat(bool playerWon)
        {
            CombatPanel.Instance.Hide();
            turnQueue.Clear();
            combatEnded = true;

            onCompleted(playerWon);
        }

        public static void StartNewTurn()
        {
            if (combatEnded) return;

            activeCharacter = turnQueue.Dequeue();

            turnQueue.Enqueue(activeCharacter);

            activeCharacter.ManageEffects();
            activeCharacter.TakeTurn();
        }

        public static void SelectAbility(Ability a)
        {
            if (!(activeCharacter is PlayerCharacter)) return; // It is not the player's turn

            if (a.remainingCooldown > 0) return; // Ability is still on cooldown

            if (!activeCharacter.abilities.Contains(a)) throw new Exception(activeCharacter.name + " does not have that ability (" + a.Name + ")");

            

            if (a.targetFriendly) // ASSUMES ONLY 1 PLAYER CHARACTER
            {
                a.Cast(activeCharacter, activeCharacter);

                StartNewTurn();
            }
            else
            {
                playersActiveAbility = a;
            }
        }

        public static void SelectTarget(Character c)
        {
            if (!(activeCharacter is PlayerCharacter)) return; // It is not the player's turn

            if (playersActiveAbility == null) return; // No ability selected

            if (c.isDead) return; // That character is already dead

            if (playersActiveAbility.targetFriendly == c.isEnemy) return; // that ability cannot target that character


            playersActiveAbility.Cast(activeCharacter, c);

            StartNewTurn();
        }
    }
}
