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
        Batch<CharacterCard> cards;

        CombatOptions combatOptions;

        public CombatPanel() : base(new Rectangle(260, 2, 1400, 1075))
        {
            enemies = new HorizontalGroup(new Rectangle(rect.X + 200, rect.Y + 25, 1000, 400), null);
            players = new HorizontalGroup(new Rectangle(rect.X + 200, rect.Y + 450, 1000, 400), null);

            cards = new Batch<CharacterCard>();

            combatOptions = new CombatOptions(new Rectangle(rect.X + 50, rect.Y + 875, 1300, 175));
            AddUIElement(combatOptions);

            Instance = this;
            Hide();
        }

        public void Open()
        {
            players.children.Clear();
            enemies.children.Clear();

            cards.Clear();

            foreach (Character c in CombatManager.turnQueue)
            {
                CharacterCard cc = cards.Request();
                if (!childElements.Contains(cc)) AddUIElement(cc);

                cc.SetCharacter(c);
                if (c.isEnemy) enemies.children.Add(cc);
                else
                {
                    players.children.Add(cc);
                    combatOptions.Open(c);
                }
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
