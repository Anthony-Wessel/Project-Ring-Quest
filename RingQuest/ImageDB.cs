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
            LockedExit = Content.Load<Texture2D>("Tiles/Exit_Locked");
            Key = Content.Load<Texture2D>("Key");

            Player = Content.Load<Texture2D>("Player");

            Panel = Content.Load<Texture2D>("UI/Panel");
            Button = Content.Load<Texture2D>("UI/Button");
            Button_Pressed = Content.Load<Texture2D>("UI/Button_Pressed");
            Button_Hovered = Content.Load<Texture2D>("UI/Button_Hovered");
        }

        public static Texture2D TileBackground, TileCover,
                                CombatEvent, ChoiceEvent, LoreEvent, OpenExit, LockedExit, Key,
                                Player,
                                Panel, Button, Button_Pressed, Button_Hovered;
    }
}
