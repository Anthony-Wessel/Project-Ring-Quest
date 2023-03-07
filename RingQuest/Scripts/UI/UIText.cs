using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace RingQuest
{
    // TODO: DOES THIS NEED TO BE A UIELEMENT
    public class UIText : UIElement
    {
        public Rectangle rect { get; set; }
        public string text;

        public UIText(Rectangle parentRect, string text)
        {
            this.rect = parentRect;
            SetText(text);         
        }

        public void SetText(string text)
        {
            Vector2 textSize = Fonts.defaultFont.MeasureString(text);

            if (textSize.X > rect.Width)
            {
                // Add new line characters to reduce width (and increase height) of text
                int numLines = (int)Math.Ceiling(textSize.X / rect.Width);
                int desiredLength = (int)(textSize.X / numLines);
                string[] words = text.Split(' ');

                float currentLength = 0;
                string compiledText = "";
                foreach (string word in words)
                {
                    if (currentLength + stringLen(word) >= desiredLength)
                    {
                        // finish line with either currentLength or currentLength + word
                        if (desiredLength - currentLength < currentLength + stringLen(word) - desiredLength || currentLength + stringLen(word) > rect.Width)
                        {
                            compiledText += '\n' + word + " ";
                            currentLength = stringLen(word + " ");
                        }
                        else
                        {
                            compiledText += word + '\n';
                            currentLength = 0;
                        }
                    }
                    else
                    {
                        compiledText += word + " ";
                        currentLength += stringLen(word + " "); ;
                    }
                }
                this.text = compiledText;
            }
            else this.text = text;


            // Center individual lines
            string[] lines = this.text.Split('\n');
            float maxLength = 0;
            foreach (string line in lines)
            {
                float lineLength = stringLen(line);
                if (lineLength > maxLength) maxLength = lineLength;
            }

            float spaceLength = stringLen(" ");
            string compiledString = "";
            foreach (string line in lines)
            {
                float diff = maxLength - stringLen(line);
                int spaces = (int)((diff / 2) / spaceLength);

                for (int i = 0; i < spaces; i++) compiledString += " ";
                compiledString += line + '\n';
            }

            this.text = compiledString.TrimEnd();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) => Draw(gameTime, spriteBatch, Fonts.defaultFont, Color.Black);

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, SpriteFont font) => Draw(gameTime, spriteBatch, font, Color.Black);

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, SpriteFont font, Color color)
        {
            Vector2 textSize = Fonts.defaultFont.MeasureString(this.text);
            Vector2 drawPosition = new Vector2(rect.Location.X + (rect.Width - textSize.X) / 2, rect.Location.Y + (rect.Height - textSize.Y) / 2);

            spriteBatch.DrawString(font, text, drawPosition, color);
        }

        float stringLen(string x)
        {
            return Fonts.defaultFont.MeasureString(x).X;
        }
    }
}
