using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class CombatPanel : UIElement
    {
        public static CombatPanel Instance;

        HorizontalGroup enemies, players;
        Pool<CharacterCard> cards;

        CombatOptions combatOptions;

        public CombatPanel() : base(new FloatRect(260, 2, 1400, 1075))
        {
            enemies = new HorizontalGroup(new FloatRect(rect.X + 200, rect.Y + 25, 1000, 400));
            players = new HorizontalGroup(new FloatRect(rect.X + 200, rect.Y + 450, 1000, 400));

            cards = new Pool<CharacterCard>();

            combatOptions = new CombatOptions(new FloatRect(rect.X + 50, rect.Y + 875, 1300, 175));
            AddChild(combatOptions);

            Instance = this;
            Hide();
        }

        public void Open()
        {
            players.Clear();
            enemies.Clear();

            cards.Clear();

            foreach (Character c in CombatManager.turnQueue)
            {
                CharacterCard cc = cards.Request();
                if (!children.Contains(cc)) AddChild(cc);

                cc.SetCharacter(c);
                if (c.isEnemy) enemies.AddChild(cc);
                else
                {
                    players.AddChild(cc);
                    combatOptions.Open(c);
                }
            }

            players.ConfigurePlacement();
            enemies.ConfigurePlacement();

            active = true;
        }

        public void Hide()
        {
            active = false;
        }

        protected override void DrawSelf(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ImageDB.Panel, rect.rectangle, Color.White);
        }
    }
}
