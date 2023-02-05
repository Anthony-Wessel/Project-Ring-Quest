using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public static class ImageDB
    {
        public static void LoadImages(ContentManager Content)
        {
            TileBackground = Content.Load<Texture2D>("TileBackground");
            TileCover = Content.Load<Texture2D>("TileCover");

            ChoiceEvent = Content.Load<Texture2D>("Choice");
            CombatEvent = Content.Load<Texture2D>("Combat");
            LoreEvent = Content.Load<Texture2D>("Lore");
            OpenExit = Content.Load<Texture2D>("Exit");
            Key = Content.Load<Texture2D>("Key");

            Player = Content.Load<Texture2D>("Player");
        }

        public static Texture2D TileBackground, TileCover,
                                CombatEvent, ChoiceEvent, LoreEvent, OpenExit, LockedExit, Key,
                                Player;
    }
}
