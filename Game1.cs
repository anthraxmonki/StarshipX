using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace StarshipX
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont fKootenay;

        Rectangle rScreenSize;
        float fScreenWidth;
        float fScreenHeight;


        PlayerShip oPlayerShip;
        SnakeSegment oSnakeSegment;





        public GameState currentGameState;
        public enum GameState
        {
            DebugOff, 
            DebugOn
        }




        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            this.graphics.PreferredBackBufferWidth  = 800;
            this.graphics.PreferredBackBufferHeight = 925;

            rScreenSize   = new Rectangle(0, 0, this.graphics.PreferredBackBufferWidth, this.graphics.PreferredBackBufferHeight);
            fScreenWidth  = this.graphics.PreferredBackBufferWidth;
            fScreenHeight = this.graphics.PreferredBackBufferHeight;

        }





        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            currentGameState = GameState.DebugOff;
            oPlayerShip      = new PlayerShip();
            oSnakeSegment    = new SnakeSegment();



            base.Initialize();
        }




        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            fKootenay = Content.Load<SpriteFont>("fKootenay");

            //the Shuttle image Can Not Scale. It is a Broken Image.
            //    I don't know why it is broke.
            //    This same code works & scales properly with "SnakeSegment" instead of "shuttle"
            oPlayerShip.LoadContent(Content, "shuttle", 1.0f);
            oPlayerShip.SetSpritePosition(new Vector2((rScreenSize.Width / 2 - oPlayerShip.rSpriteSource.Width / 2), rScreenSize.Bottom - oPlayerShip.rSpriteSource.Height) );

            //made to test scaling getter/setter/drawer
            oSnakeSegment.LoadContent(Content, "SnakeSegment", 10.0f);



        }




        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }














        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            GamePadState gpCurrentState = GamePad.GetState(PlayerIndex.One);
            KeyboardState ksCurrentState = Keyboard.GetState();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();


            if (ksCurrentState.IsKeyDown(Keys.D1) == true)
            {
                currentGameState = GameState.DebugOn;
                IsMouseVisible = true;
            }
            if (ksCurrentState.IsKeyDown(Keys.D2) == true)
            {
                currentGameState = GameState.DebugOff;
                IsMouseVisible = false;
            }

            oPlayerShip.Update(gameTime, ksCurrentState, gpCurrentState);



















            base.Update(gameTime);
        }










        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            //drawing based on gamestates 
            if (currentGameState == GameState.DebugOn)
            {
                spriteBatch.DrawString(fKootenay, "Mouse coordinates  X: " + Mouse.GetState().X + " Y: " + Mouse.GetState().Y, new Vector2(10, 10), Color.DarkRed);
                oSnakeSegment.Draw(spriteBatch);
            }




            oPlayerShip.Draw(spriteBatch);


            spriteBatch.End();
            base.Draw(gameTime);
        }













    //
    }
//
}
