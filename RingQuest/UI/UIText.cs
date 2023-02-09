using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
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
        string text;
        Vector2 drawPosition;

        public UIText(Rectangle parentRect, string text, bool centerJustified = true)
        {
            this.rect = parentRect;
            
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


            if (centerJustified)
            {
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

                this.text = compiledString;
            }

            this.text = this.text.TrimEnd();

            // Center the text within the rect
            textSize = Fonts.defaultFont.MeasureString(this.text);
            drawPosition = new Vector2(rect.Location.X + (rect.Width - textSize.X) / 2, rect.Location.Y + (rect.Height - textSize.Y) / 2);            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Fonts.defaultFont, text, drawPosition, Color.White);
        }

        float stringLen(string x)
        {
            return Fonts.defaultFont.MeasureString(x).X;
        }
    }
}
