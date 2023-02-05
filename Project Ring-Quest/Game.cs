using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using IndependentResolutionRendering;
using System;
using System.Diagnostics;
using RingQuest;

namespace Project_Ring_Quest
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Tile t1, t2;

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Resolution.Init(ref _graphics);
            Resolution.SetVirtualResolution(1920, 1080);
            Resolution.SetResolution(Window.ClientBounds.Width, Window.ClientBounds.Height, false);

            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += updateResolution;
            //Window.IsBorderless = true;

            t1 = new Tile(new Vector2(100, 100));
            t2 = new Tile(new Vector2(1000, 1000));

            base.Initialize();
        }

        void updateResolution(object sender, EventArgs e)
        {
            Resolution.SetResolution(Window.ClientBounds.Width, Window.ClientBounds.Height, false);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ImageDB.LoadImages(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Resolution.BeginDraw();
            _spriteBatch.Begin(transformMatrix: Resolution.getTransformationMatrix());

            foreach (Texture2D tex in t1.GetSprites()) _spriteBatch.Draw(tex, t1.rect, Color.White);
            foreach (Texture2D tex in t2.GetSprites()) _spriteBatch.Draw(tex, t2.rect, Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}