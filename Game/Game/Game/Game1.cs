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

namespace Game
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D Background;
        Texture2D player1Texture;
        Rectangle player1Rectangle;
        Texture2D energyBallTexture;
        Song Song;
        bool songstart = false;

        Rectangle energyBallRectangle;
        
        Vector2 player1Position = new Vector2(90, 490); //(Width, Height)
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            
            this.graphics.PreferredBackBufferWidth = 1280;
            this.graphics.PreferredBackBufferHeight = 720;
            this.graphics.IsFullScreen = false;
            
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        /// 
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            EnergyBall EB = new EnergyBall(this);
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
            Background = Content.Load<Texture2D>(@"Textures\Background");
            player1Texture = Content.Load<Texture2D>(@"Textures\Player1");
            energyBallTexture = Content.Load<Texture2D>(@"Textures\Energyball");
            Song = Content.Load<Song>(@"Sounds\Final_Music");
            MediaPlayer.IsRepeating = true;

            int energyBallx = energyBallRectangle.X;
            int energyBally = energyBallRectangle.Y;

            energyBallRectangle = new Rectangle(290, 575, energyBallTexture.Width, energyBallTexture.Height);
            // TODO: use this.Content to load your game content here
           
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
            MouseState mouseState = Mouse.GetState();
            KeyboardState keyState = Keyboard.GetState();
            // Allows the game to exit
            if (keyState.IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here
            if (keyState.IsKeyDown(Keys.Left))
            {
                player1Position += new Vector2(-10, 0);
            }


            if (keyState.IsKeyDown(Keys.Right))
            {
                player1Position += new Vector2(10, 0);
            }


            if (keyState.IsKeyDown(Keys.Space))
            {
                energyBallRectangle = new Rectangle(1600, 840, energyBallTexture.Width, energyBallTexture.Height);
            }

            if (player1Rectangle.X == 100)
            {
                player1Position.Y -= 100;
            }

            if (!songstart)
            {
                MediaPlayer.Play(Song);
                songstart = true;
            }  



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
            // TODO: Add your drawing code here
            spriteBatch.Draw(Background, Vector2.Zero, Color.White);
            spriteBatch.Draw(player1Texture, player1Position, Color.White);
            spriteBatch.Draw(energyBallTexture, energyBallRectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}