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
    public class GameManager : Game
    {
        public static GameManager Instance;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Tile[,] tiles;
        Player player;
        
        PromptPanel promptPanel;
        CombatPanel combatPanel;
        EquipmentUI equipmentPanel;
        OptionsPopup optionsPopup;

        Input input;

        ExitEvent exit;

        public GameTimeEventTrigger updateChildren;

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
            ProbabilityTable pTable = new ProbabilityTable();

            Vector2 boardSize = new Vector2(10, 5);
            Vector2 offset = (Screen.Size / 2) - (boardSize / 2 * Tile.SIZE);
            tiles = new Tile[(int)boardSize.X, (int)boardSize.Y];
            List<Tile> emptyTiles = new List<Tile>();
            for (int y = 0; y < boardSize.Y; y++)
            {
                for (int x = 0; x < boardSize.X; x++)
                {
                    Tile t = new Tile(new Vector2(offset.X + x * Tile.SIZE, offset.Y + y * Tile.SIZE));

                    TileEvent tEvent = pTable.GetRandomEvent();
                    if (tEvent != null) t.SetEvent(tEvent);
                    else emptyTiles.Add(t);


                    if (x > 0) t.Connect(tiles[x - 1, y]);
                    if (y > 0) t.Connect(tiles[x, y - 1]);

                    tiles[x, y] = t;
                    
                }
            }

            // Spawn exit
            Random rng = new Random();
            int index = rng.Next(emptyTiles.Count);
            bool locked = rng.NextSingle() > 0f;
            exit = new ExitEvent(locked);
            emptyTiles[index].SetEvent(exit);
            emptyTiles.RemoveAt(index);

            // Spawn key?
            if (locked)
            {
                index = rng.Next(emptyTiles.Count);
                emptyTiles[index].SetEvent(new KeyEvent());
                emptyTiles.RemoveAt(index);
            }

            // Spawn player
            index = rng.Next(emptyTiles.Count);
            player = new Player(emptyTiles[index]);
            PlayerEquipment.playerCharacter = Player.character;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            ImageDB.LoadImages(Content);
            Fonts.LoadFonts(Content);

            // Spawn grid of tiles and player
            InitBoard();
            CombatManager.Init();

            promptPanel = new PromptPanel();
            combatPanel = new CombatPanel();
            equipmentPanel = new EquipmentUI();
            optionsPopup = new OptionsPopup();
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
            Time.Update(gameTime);
            input.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // Update player
            player.Update(gameTime);

            updateChildren.Invoke(gameTime);

            // Check for mouse click
            if (Input.GetMouseButtonDown(0) && !promptPanel.active && !combatPanel.active && !equipmentPanel.active)
                CheckIfTileClicked(Input.GetMousePosition());




            
            /// INVENTORY TESTING ///
            
            if (Input.GetKeyDown(Keys.Space))
            {
                PlayerEquipment.Equip(Player.character.inventory.items[0] as Weapon);

                Debug.Write("Now Equipped: ");
                if (PlayerEquipment.equippedWeapon != null) Debug.Write(PlayerEquipment.equippedWeapon.name + " + ");
                if (PlayerEquipment.equippedOffhand != null) Debug.Write(PlayerEquipment.equippedOffhand.name);

                Debug.WriteLine("");

                Debug.WriteLine("Items left in inventory: " + Player.character.inventory.items.Length);
            }

            /////////////////////////
            



            // Monogame stuff
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Background color
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Resolution.BeginDraw();
            _spriteBatch.Begin(transformMatrix: Resolution.getTransformationMatrix());

            Input.CheckForClick();

            // Draw tiles
            foreach (Tile t in tiles)
            {
                t.Draw(gameTime, _spriteBatch);
            }

            // Draw player
            player.Draw(gameTime, _spriteBatch);

            // Draw panels
            promptPanel.Draw(gameTime, _spriteBatch);
            combatPanel.Draw(gameTime, _spriteBatch);
            equipmentPanel.Draw(gameTime, _spriteBatch);

            HealthPopups.Draw(gameTime, _spriteBatch);
            optionsPopup.Draw(gameTime, _spriteBatch);

            _spriteBatch.End();

            Input.HandleClickRequests();

            base.Draw(gameTime);
        }

        public void UnlockExit()
        {
            exit.Unlock();
        }
    }
}