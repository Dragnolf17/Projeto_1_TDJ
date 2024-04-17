using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    internal class Ball
    {
        int w = 30;
        int h = 30;
        Rectangle rect;
        float speed = 1000f;

        int right = 1;
        int down = 1;

        public Ball()
        {
            rect = new Rectangle((Globals.WIDTH - w) / 2, (Globals.HEIGHT - h) / 2, w, h);
        }
        public void Update(GameTime gt, Palet p1, Palet p2)
        {
            int dt = (int)(gt.ElapsedGameTime.TotalSeconds * speed);

            if (rect.Y <= 0 || rect.Y >= Globals.HEIGHT - h) down *= -1;

            if (p1.rect.Intersects(rect) || p2.rect.Intersects(rect)) right *= -1;

            if(rect.X <= 0)
            {
                Globals.p2_points++;
                resetGame();
            }
            if(rect.X >= Globals.WIDTH - w)
            {
                Globals.p1_points++;
                resetGame();
            }

            rect.X += dt * right;
            rect.Y += dt * down;
        }
        void resetGame()
        {
            rect.X = (Globals.WIDTH - w) / 2;
            rect.Y = (Globals.HEIGHT - h) / 2;
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(Globals.pixel, rect, Color.White);
        }
    }
}
