using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGame_Topics_1_5_Summative_Assignment
{
    enum
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Random generator = new Random(3);
        Texture2D moleDown, molePeak, moleUp, moleStars, introTexture, backgroundTexture, endTexture;
        Rectangle moleRect1, moleRect2, moleRect3, window;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            moleRect1 = new Rectangle(50, 25, 200, 250);
            moleRect2 = new Rectangle(300, 25, 200, 250);
            moleRect3 = new Rectangle(550, 25, 200, 250);

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
            window = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            moleDown = Content.Load<Texture2D>("moleDown");
            molePeak = Content.Load<Texture2D>("molePeak");
            moleUp = Content.Load<Texture2D>("moleUp");
            moleStars = Content.Load<Texture2D>("moleStars");

            // TODO: use this.Content to load your game content here
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

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
