using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Character
    {
        public bool isEnemy;
        
        public string name;
        public Texture2D sprite;
        public int currentHealth, maxHealth;

        public bool isDead;

        public delegate void OnCharacterUpdated();
        public OnCharacterUpdated onCharacterUpdated;

        public Character(string name, Texture2D sprite, int maxHealth)
        {
            this.name = name;
            this.sprite = sprite;
            this.maxHealth = maxHealth;
            this.currentHealth = maxHealth;

            isDead = false;

            onCharacterUpdated = () => { };
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            if (currentHealth <= 0) Die();

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
    }
}
