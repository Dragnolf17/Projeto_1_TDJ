using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Drawing.Imaging;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        Palet p1;
        Palet p2;
        Ball ball;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            _graphics.PreferredBackBufferWidth = Globals.WIDTH;
            _graphics.PreferredBackBufferHeight = Globals.HEIGHT;
            _graphics.IsFullScreen = Globals.isFullScreen;
        }

        protected override void Initialize()
        {
            p1 = new Palet(false);
            p2 = new Palet(true);
            ball = new Ball();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.pixel = new Texture2D(GraphicsDevice, 1, 1);
            Globals.pixel.SetData<Color>(new Color[] { Color.White });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            p1.Update(gameTime);
            p2.Update(gameTime);
            ball.Update(gameTime, p1, p2);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Globals.BACKGROUND_COLOR);

            Globals.spriteBatch.Begin();

            p1.Draw();
            p2.Draw();
            ball.Draw();

            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
