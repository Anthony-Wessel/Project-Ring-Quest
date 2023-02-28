using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    public class Input
    {
        static bool[] mouseButtonDownPreviously;

        static Keys[] keysPressedPreviously;
        static int numKeysPressedPreviously;

        static MouseState mouseState;
        static KeyboardState keyboardState;

        public Input()
        {
            mouseButtonDownPreviously = new bool[3];

            keysPressedPreviously = new Keys[15];
            numKeysPressedPreviously = 0;
        }

        public void Update(GameTime gameTime)
        {
            // Update mouse state
            for (int i = 0; i < mouseButtonDownPreviously.Length; i++)
            {
                mouseButtonDownPreviously[i] = GetMouseButton(i);
            }

            mouseState = Mouse.GetState();

            // Update keyboard state
            numKeysPressedPreviously = keyboardState.GetPressedKeyCount();
            keyboardState.GetPressedKeys(keysPressedPreviously);

            keyboardState = Keyboard.GetState();
        }

        #region Mouse

        public delegate void OnMouseClick(Point mousePos);
        public static OnMouseClick onMouseClick;

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

            throw new ArgumentOutOfRangeException("i", "Parameter i cannot be greater than 2 for function 'GetMouseButton'.");
        }

        public static bool GetMouseButtonDown(int i)
        {
            if (i > 2)
                throw new ArgumentOutOfRangeException("i", "Parameter i cannot be greater than 2 for function 'GetMouseButtonDown'.");

            return GetMouseButton(i) && !mouseButtonDownPreviously[i];
        }

        public static bool GetMouseButtonUp(int i)
        {
            if (i > 2)
                throw new ArgumentOutOfRangeException("i", "Parameter i cannot be greater than 2 for function 'GetMouseButtonUp'.");

            return !GetMouseButton(i) && mouseButtonDownPreviously[i];
        }

        public static Point GetMousePosition()
        {
            float yScale = 1080f / Screen.UnscaledSize.Y;
            float xScale = 1920f / Screen.UnscaledSize.X;

            return new Vector2(xScale * mouseState.Position.X, yScale * mouseState.Position.Y).ToPoint();
        }

        #endregion


        #region Keyboard

        public static bool GetKey(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        public static bool GetKeyDown(Keys key)
        {
            if (!keyboardState.IsKeyDown(key)) return false;
            
            for (int i = 0; i < numKeysPressedPreviously; i++)
            {
                if (keysPressedPreviously[i] == key) return false;
            }
            
            return true;
        }

        public static bool GetKeyUp(Keys key)
        {
            if (!keyboardState.IsKeyDown(key))
            {
                for (int i = 0; i < numKeysPressedPreviously; i++)
                {
                    if (keysPressedPreviously[i] == key) return true;
                }
            }

            return false;
        }

        #endregion
    }
}
