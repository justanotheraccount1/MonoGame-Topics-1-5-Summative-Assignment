using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGame_Topics_1_5_Summative_Assignment
{
    enum Screen
    {
        Intro,
        Main,
        End
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Random generator = new Random(3);
        Texture2D moleDown, molePeak, moleUp, moleStars, introTexture, backgroundTexture, endTexture;
        Rectangle moleRect1, moleRect2, moleRect3, window;
        SoundEffect backgroundSound, tadaaSound, bonkSound;
        SoundEffectInstance backgroundSoundInstance;
        bool playing = false;
        Screen screen;
        SpriteFont textFont;
        Vector2 text;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen = Screen.Intro;
            moleRect1 = new Rectangle(50, 25, 200, 250);
            moleRect2 = new Rectangle(300, 25, 200, 250);
            moleRect3 = new Rectangle(550, 25, 200, 250);

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
            window = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);


            text = new Vector2(500, 10);
            base.Initialize();
            backgroundSoundInstance.IsLooped = true;
            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            moleDown = Content.Load<Texture2D>("moleDown");
            molePeak = Content.Load<Texture2D>("molePeak");
            moleUp = Content.Load<Texture2D>("moleUp");
            moleStars = Content.Load<Texture2D>("moleStars");
            backgroundTexture = Content.Load<Texture2D>("carnivalBG");
            backgroundSound = Content.Load<SoundEffect>("circusSounds");
            backgroundSoundInstance = backgroundSound.CreateInstance();
            bonkSound = Content.Load<SoundEffect>("bonkSound");
            tadaaSound = Content.Load<SoundEffect>("tadaaSound");
            textFont = Content.Load<SpriteFont>("spriteFont");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            backgroundSoundInstance.Play();


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (screen == Screen.Intro)
            {

            }
            if (screen == Screen.Main)
            {

            }
            if (screen == Screen.End)
            {

            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(backgroundTexture, window, Color.White);
                _spriteBatch.DrawString(textFont, "Click Anywhere to Continue...", text, Color.Black);
            }
            if (screen == Screen.Main)
            {

            }
            if (screen == Screen.End)
            {

            }
            // TODO: Add your drawing code here
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
