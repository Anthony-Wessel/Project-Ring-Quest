using IndependentResolutionRendering;
using Microsoft.Xna.Framework;
using System;

namespace RingQuest
{
    public static class Screen
    {
        public static GameWindow Window;

        public static Vector2 Size { get { return new Vector2(1920, 1080); } }
        public static Vector2 UnscaledSize { get { return Window.ClientBounds.Size.ToVector2(); } }

        public static void Init(GameWindow window)
        {
            Window = window;

            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += updateResolution;
        }

        public static void SetWindowTitle(string title)
        {
            Window.Title = title;
        }

        public static void updateResolution(object sender, EventArgs e)
        {
            Resolution.SetResolution(Window.ClientBounds.Width, Window.ClientBounds.Height, false);
        }
    }
}
