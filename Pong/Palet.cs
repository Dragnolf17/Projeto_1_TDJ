using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    internal class Palet
    {
        bool isSecondPlayer;
        int w = 40;
        int h = 300;
        float speed = 700f;

        public Rectangle rect;

        public Palet(bool sp)
        {
            isSecondPlayer = sp;
            rect = new Rectangle(sp ? Globals.WIDTH - w : 0, (Globals.HEIGHT - h) / 2, w, h);
        }
        public void Update(GameTime gt)
        {
            int dt = (int)(gt.ElapsedGameTime.TotalSeconds * speed);
            KeyboardState kstate = Keyboard.GetState();

            if((isSecondPlayer ? kstate.IsKeyDown(Keys.Up) : kstate.IsKeyDown(Keys.W)) && rect.Y > 0)
            {
                rect.Y -= dt;
            }
            if((isSecondPlayer ? kstate.IsKeyDown(Keys.Down) : kstate.IsKeyDown(Keys.S)) && rect.Y < Globals.HEIGHT-h)
            {
                rect.Y += dt;
            }
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(Globals.pixel, rect, Color.White);
        }
    }
}
