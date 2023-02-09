﻿using Microsoft.Xna.Framework;
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
        Panel openPanel;
        Input input;

        public delegate void UpdateChildren(GameTime gameTime);
        public UpdateChildren updateChildren;

        public GameManager()
        {
            Instance = this;
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Screen.Init(Window);
            input = new Input();
        }

        #region Initialization
        
        protected override void Initialize()
        {
            // Setup graphics scaling
            Resolution.Init(ref _graphics);
            Resolution.SetVirtualResolution(1920, 1080);
            Resolution.SetResolution((int)Screen.UnscaledSize.X, (int)Screen.UnscaledSize.Y, false);

            updateChildren = (x) => { };

            base.Initialize();
        }

        void InitBoard()
        {
            Vector2 boardSize = new Vector2(10, 5);
            Vector2 offset = (Screen.Size / 2) - (boardSize / 2 * Tile.SIZE);
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
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ImageDB.LoadImages(Content);
            Fonts.LoadFonts(Content);

            // Spawn grid of tiles and player
            InitBoard();

            var options = new Dictionary<string, Action>();
            options.Add("Close window", () => Debug.WriteLine("Trying to close window, but that's not implemented yet"));
            options.Add("Red", () => Debug.WriteLine("You pressed the button that said 'red'"));
            openPanel = Panel.PromptPanel("This is a title", "This is a prompt. I am prompting you to make a decision. Please choose one of the following choices by pressing one of the buttons. Your decision will affect your character in some way.", options);
        }

        #endregion

        #region Mouse events

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

        #endregion

        

        protected override void Update(GameTime gameTime)
        {
            input.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // Check for mouse click
            if (Input.GetMouseButtonDown(0))
                CheckIfTileClicked(Input.GetMousePosition().ToVector2());

            // Update player
            player.Update(gameTime);

            updateChildren.Invoke(gameTime);

            // Monogame stuff
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Background color
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Resolution.BeginDraw();
            _spriteBatch.Begin(transformMatrix: Resolution.getTransformationMatrix());


            // Draw tiles
            foreach (Tile t in tiles)
            {
                t.Draw(gameTime, _spriteBatch);
            }

            // Draw player
            player.Draw(gameTime, _spriteBatch);

            // Draw panel
            openPanel.Draw(gameTime, _spriteBatch);


            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}