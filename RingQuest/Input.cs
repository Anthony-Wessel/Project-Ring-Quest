using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Input
    {
        static bool[] mouseButtonDownPreviously;

        static MouseState mouseState;
        static KeyboardState keyboardState;

        public Input()
        {
            mouseButtonDownPreviously = new bool[3];
        }

        public void Update(GameTime gameTime)
        {
            for (int i = 0; i < mouseButtonDownPreviously.Length; i++)
            {
                mouseButtonDownPreviously[i] = GetMouseButton(i);
            }

            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();
        }

        #region Mouse
        
        public static bool GetMouseButton(int i)
        {
            switch (i)
            {
                case 0:
                    return mouseState.LeftButton == ButtonState.Pressed;
                case 1:
                    return mouseState.RightButton == ButtonState.Pressed;
                case 2:
                    return mouseState.MiddleButton == ButtonState.Pressed;
            }

            throw new ArgumentOutOfRangeException("i", "Parameter i cannot be greater than 3 for function 'GetMouseButton'.");
        }

        public static bool GetMouseButtonDown(int i)
        {
            return GetMouseButton(i) && !mouseButtonDownPreviously[i];

            throw new ArgumentOutOfRangeException("i", "Parameter i cannot be greater than 3 for function 'GetMouseButtonDown'.");
        }

        public static bool GetMouseButtonUp(int i)
        {
            return !GetMouseButton(i) && mouseButtonDownPreviously[i];

            throw new ArgumentOutOfRangeException("i", "Parameter i cannot be greater than 3 for function 'GetMouseButtonUp'.");
        }

        public static Point GetMousePosition()
        {
            float yScale = 1080f / Screen.UnscaledSize.Y;
            float xScale = 1920f / Screen.UnscaledSize.X;

            return new Vector2(xScale * mouseState.Position.X, yScale * mouseState.Position.Y).ToPoint();
        }

        #endregion
    }
}
