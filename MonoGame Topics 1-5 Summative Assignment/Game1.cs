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
        int malletXSpeed, malletYSpeed;
        int score = 0;
        Texture2D moleDown, molePeak, moleUp, moleStars, introTexture, backgroundTexture, endTexture, malletTexture;
        Rectangle moleRect1, moleRect2, moleRect3, window, malletRect;
        SoundEffect backgroundSound, tadaaSound, bonkSound;
        SoundEffectInstance backgroundSoundInstance;
        bool part1 = false;
        bool part2 = false;
        bool part3 = false;
        bool end = false;
        bool moleBonk = false;
        bool moleOut = false;

        Screen screen;
        SpriteFont textFont;
        Vector2 text, scoreText;
        MouseState mouseState;
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
            moleRect1 = new Rectangle(50, 250, 200, 250);
            moleRect2 = new Rectangle(300, 250, 200, 250);
            moleRect3 = new Rectangle(550, 250, 200, 250);
            malletRect = new Rectangle(600, 350, 200, 150);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();
            window = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            malletXSpeed = 0;
            malletYSpeed = 0;

            text = new Vector2(500, 10);
            scoreText = new Vector2(10, 10);
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
            introTexture = Content.Load<Texture2D>("carnivalBG");
            backgroundTexture = Content.Load<Texture2D>("circusBG");
            backgroundSound = Content.Load<SoundEffect>("circusSounds");
            backgroundSoundInstance = backgroundSound.CreateInstance();
            bonkSound = Content.Load<SoundEffect>("bonkSound");
            tadaaSound = Content.Load<SoundEffect>("tadaaSound");
            textFont = Content.Load<SpriteFont>("spriteFont");
            malletTexture = Content.Load<Texture2D>("mallet");
            endTexture = Content.Load<Texture2D>("moleEndBG");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            backgroundSoundInstance.Play();
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    screen = Screen.Main;
                    part1 = true;
                }
                    

            }
            if (screen == Screen.Main)
            {
                malletRect.X += malletXSpeed;
                malletRect.Y += malletYSpeed;
                if (part1)
                {
                    malletXSpeed = -4;
                    malletYSpeed = -2;
                    if (malletRect.X <= 100)
                    {
                        moleOut = true;
                        malletRect.X = 100;
                        malletXSpeed = 0;
                        malletYSpeed = 2;
                        if (malletRect.Y >= 150)
                        {
                            malletYSpeed = 0;
                            moleBonk = true;
                            moleOut = false;
                            score += 1;
                        }
                        if (moleBonk)
                        {
                            bonkSound.Play();
                            part1 = false;
                            part2 = true;
                            moleBonk = false;
                            
                        }
                    }
                }
                if (part2)
                {
                    if (!moleOut && !moleBonk)
                    {
                        malletYSpeed = -4;
                        if (malletRect.Y <= 0)
                        {
                            malletYSpeed = 0;
                            malletRect.Y = 0;
                            moleOut = true;
                        }

                    }
                    if (moleOut)
                    {
                        malletXSpeed = 3;
                        if (malletRect.X >= 350)
                        {
                            malletXSpeed = 0;
                            malletYSpeed = 4;
                            if ((malletRect.Bottom - 50) >= moleRect2.Y)
                            {
                                malletYSpeed = 0;
                                moleBonk = true;
                                moleOut = false;
                                score += 1;
                            }
                        }
                    }
                    if (moleBonk)
                    {
                        bonkSound.Play();
                        moleBonk = false;
                        part3 = true;
                        part2 = false;
                    }
                }
                if (part3)
                {
                    if (!moleOut && !moleBonk && !end)
                    {
                        malletYSpeed = -4;
                        malletXSpeed = 2;
                        if (malletRect.Y <= 0)
                        {
                            malletYSpeed = 0;
                            moleOut = true;
                        }
                    }
                    if (moleOut)
                    {
                        if (malletRect.X >= 600)
                        {
                            malletRect.X = 599;
                            malletXSpeed = 0;
                            malletYSpeed = 4;
                        }
                        if ((malletRect.Bottom - 50) >= moleRect3.Y)
                        {
                            malletYSpeed = 0;
                            moleBonk = true;
                            moleOut = false;
                            score += 1;
                        }
                        
                    }
                    if (moleBonk)
                    {
                        bonkSound.Play();
                        moleBonk = false;
                        end = true;

                    }
                    if (end)
                    {

                        if (mouseState.LeftButton == ButtonState.Pressed)
                        { 
                            screen = Screen.End;
                            tadaaSound.Play();
                        }
                    }
                }

                


            }
            if (screen == Screen.End)
            {
                backgroundSoundInstance.Stop();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, window, Color.White);
                _spriteBatch.DrawString(textFont, "Click Anywhere to Continue...", text, Color.Black);
            }
            if (screen == Screen.Main)
            {
                _spriteBatch.Draw(backgroundTexture, window, Color.White);
                _spriteBatch.DrawString(textFont, "Score:" + score, scoreText, Color.Black);
                if (part1)
                {
                    _spriteBatch.Draw(moleDown, moleRect2, Color.White);
                    _spriteBatch.Draw(moleDown, moleRect3, Color.White);
                    if (!moleOut && !moleBonk)
                    {
                        _spriteBatch.Draw(molePeak, moleRect1, Color.White);

                    }
                    if (moleOut)
                        _spriteBatch.Draw(moleUp, moleRect1, Color.White);
                    if (moleBonk)
                        _spriteBatch.Draw(moleStars, moleRect1, Color.White);
                }
                if (part2)
                {
                    _spriteBatch.Draw(moleStars, moleRect1, Color.White);
                    _spriteBatch.Draw(moleDown, moleRect3, Color.White);
                    if (!moleOut && !moleBonk)
                    {
                        _spriteBatch.Draw(molePeak, moleRect2, Color.White);
                    }
                    if (moleOut)
                        _spriteBatch.Draw(moleUp, moleRect2, Color.White);
                    if (moleBonk)
                        _spriteBatch.Draw(moleStars,moleRect2, Color.White);
                }
                if (part3)
                {
                    _spriteBatch.Draw(moleStars, moleRect1, Color.White);
                    _spriteBatch.Draw(moleStars, moleRect2, Color.White);
                    if (!moleOut && !moleBonk && !end)
                    {
                        _spriteBatch.Draw(molePeak, moleRect3, Color.White);
                    }
                    if (moleOut)
                        _spriteBatch.Draw(moleUp, moleRect3, Color.White);
                    if (moleBonk || end)
                        _spriteBatch.Draw(moleStars, moleRect3, Color.White);
                    if (end)
                    {
                        _spriteBatch.DrawString(textFont, "Click anywhere to quit...", text, Color.Black);
                    }
                }
                _spriteBatch.Draw(malletTexture, malletRect, Color.White);

            }
            if (screen == Screen.End)
            {
                _spriteBatch.Draw(endTexture, window, Color.White);
            }
            // TODO: Add your drawing code here
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
