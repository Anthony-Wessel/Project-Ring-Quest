using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using IndependentResolutionRendering;
using System;
using System.Diagnostics;
using RingQuest;
using System.Collections.Generic;

namespace RingQuest
{
    public class GameManager : Microsoft.Xna.Framework.Game
    {
        public static GameManager Instance;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Tile[,] tiles;
        Player player;
        Vector2 ScreenSize { get { return new Vector2(1920, 1080); } }
        Vector2 mousePos
        {
            get
            {
                float yScale = 1080f / Window.ClientBounds.Height;
                float xScale = 1920f / Window.ClientBounds.Width;

                MouseState ms = Mouse.GetState();
                return new Vector2(xScale * ms.Position.X, yScale * ms.Position.Y);
            }
        }

        bool wasPressed;

        delegate void MouseClicked(Vector2 mousePos);
        MouseClicked mouseClicked;

        public GameManager()
        {
            Instance = this;
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Setup graphics scaling
            Resolution.Init(ref _graphics);
            Resolution.SetVirtualResolution(1920, 1080);
            Resolution.SetResolution((int)ScreenSize.X, (int)ScreenSize.Y, false);

            // Misc window settings
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += updateResolution;
            ///Window.IsBorderless = true;

            // Spawn grid of tiles
            Vector2 boardSize = new Vector2(10, 5);
            Vector2 offset = (ScreenSize / 2) - (boardSize / 2 * Tile.SIZE);
            tiles = new Tile[(int)boardSize.X, (int)boardSize.Y];
            List<Tile> emptyTiles = new List<Tile>();
            for (int y = 0; y < boardSize.Y; y++)
            {
                for (int x = 0; x < boardSize.X; x++)
                {
                    Tile t = new Tile(new Vector2(offset.X + x * Tile.SIZE, offset.Y + y * Tile.SIZE));
                    if (x > 0) t.Connect(tiles[x - 1, y]);
                    if (y > 0) t.Connect(tiles[x, y - 1]);

                    tiles[x, y] = t;
                    emptyTiles.Add(t);
                }
            }

            // Spawn player
            Random rng = new Random();
            int index = rng.Next(emptyTiles.Count);
            player = new Player(emptyTiles[index]);

            // Setup mouse events
            mouseClicked = CheckIfTileClicked;
            wasPressed = false;

            base.Initialize();
        }

        void CheckIfTileClicked(Vector2 mousePos)
        {
            foreach (Tile t in tiles)
            {
                if (t.rect.Contains(mousePos))
                {
                    if (t.IsTileAdjacent(player.currentTile))
                        player.MoveTo(t);
                }
            }
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

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (!wasPressed) mouseClicked(mousePos);
                wasPressed = true;
            }
            else wasPressed = false;

            player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Resolution.BeginDraw();
            _spriteBatch.Begin(transformMatrix: Resolution.getTransformationMatrix());

            
            foreach (Tile t in tiles)
            {
                foreach (Texture2D tex in t.GetSprites()) _spriteBatch.Draw(tex, t.rect, Color.White);
            }

            _spriteBatch.Draw(player.sprite, player.rect, Color.White);

            _spriteBatch.End();
            
            base.Draw(gameTime);
        }

        public void SetWindowTitle(string title)
        {
            Window.Title = title;
        }
    }
}