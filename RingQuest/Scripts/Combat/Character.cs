using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RingQuest.Character;

namespace RingQuest
{
    public class Character
    {
        public bool isEnemy;
        
        public string name;
        public Texture2D sprite;
        public int currentHealth, maxHealth;

        public int bonusDamageDone, bonusDamageTaken;
        public float accuracy, bonusCritChance, bonusCritMultiplier;

        public bool isDead;

        public delegate void OnCharacterUpdated();
        public OnCharacterUpdated onCharacterUpdated;

        public delegate void OnTakeDamageCalled(int i);
        public OnTakeDamageCalled onTakeDamageCalled;

        public List<Ability> abilities;
        public List<Effect> effects;

        public Character(string name, Texture2D sprite, int maxHealth)
        {
            this.name = name;
            this.sprite = sprite;
            this.maxHealth = maxHealth;
            this.currentHealth = maxHealth;

            abilities = new List<Ability>();
            effects = new List<Effect>();

            isDead = false;

            onCharacterUpdated = () => { };
            onTakeDamageCalled = (i) => { };

            bonusDamageDone = 0;
            bonusDamageTaken = 0;
            accuracy = 1;
        }

        public void TakeDamage(Character source, int amount)
        {
            if (source != null)
            {
                if (RNG.NextFloat(1) > source.accuracy) return; // Missed

                amount = amount + source.bonusDamageDone + bonusDamageTaken;

                if (RNG.NextFloat(1) <= source.bonusCritChance) amount = (int)(amount*(1.5 + source.bonusCritMultiplier));
            }

            currentHealth -= amount;
            if (currentHealth <= 0) Die();

            onTakeDamageCalled(amount);
            onCharacterUpdated();
        }

        void Die()
        {
            isDead = true;
        }

        public void Heal(int amount)
        {
            currentHealth = Math.Min(currentHealth + amount, maxHealth);
            onCharacterUpdated();
        }

        public virtual void TakeTurn()
        {
            Debug.WriteLine("Character named " + name + " does not have any behaviour set up and can't do anything on their turn.");
            CombatManager.StartNewTurn();
        }

        public void ManageEffects()
        {
            for (int i = effects.Count - 1; i >= 0; i--)
            {
                effects[i].OnTurnEnded(this);
                if (--effects[i].remainingDuration <= 0) RemoveEffect(effects[i]);
            }
        }

        public void ClearEffects()
        {
            for (int i = effects.Count-1; i >= 0; i--)
            {
                RemoveEffect(effects[i]);
            }
        }

        public void ApplyEffect(Effect e)
        {
            Effect eCopy = e.Copy();
            eCopy.OnApplied(this);
            effects.Add(eCopy);
        }

        public void RemoveEffect(Effect e)
        {
            e.OnRemoved(this);
            effects.Remove(e);
        }
    }
}
