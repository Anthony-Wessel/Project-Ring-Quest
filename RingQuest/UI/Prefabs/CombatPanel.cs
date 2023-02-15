using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class CombatPanel : Panel
    {
        public static CombatPanel Instance;

        HorizontalGroup enemies, players;
        List<CharacterCard> cards;

        public CombatPanel() : base(new Rectangle(260, 102, 1400, 875))
        {
            enemies = new HorizontalGroup(new Rectangle(rect.X + 200, rect.Y + 25, 1000, 400), null);
            players = new HorizontalGroup(new Rectangle(rect.X + 200, rect.Y + 450, 1000, 400), null);

            cards = new List<CharacterCard>();
            for (int i = 0; i < 7; i++)
            {
                cards.Add(new CharacterCard());
                AddUIElement(cards[i]);
            }

            Instance = this;
            Hide();
        }

        public void Open()
        {
            players.children.Clear();
            enemies.children.Clear();
            
            int index = 0;
            foreach (Character c in CombatManager.turnQueue)
            {
                cards[index].SetCharacter(c);
                if (c.isEnemy) enemies.children.Add(cards[index]);
                else players.children.Add(cards[index]);

                index++;
            }

            while (index < cards.Count)
            {
                cards[index++].active = false;
            }

            players.ConfigurePlacement();
            enemies.ConfigurePlacement();

            hidden = false;
        }

        public void Hide()
        {
            hidden = true;
        }
    }
}
