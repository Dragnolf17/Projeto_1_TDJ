using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    internal class Globals
    {
        public static int WIDTH = 1920;
        public static int HEIGHT = 1080;
        public static bool isFullScreen = true;
        public static Color BACKGROUND_COLOR = Color.Black;

        public static SpriteBatch spriteBatch;

        public static Texture2D pixel;

        public static int p1_points = 0;
        public static int p2_points = 0;
    }
}
