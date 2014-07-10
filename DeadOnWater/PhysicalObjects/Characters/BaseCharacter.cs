using DeadOnWater.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadOnWater.PhysicalObjects.Characters {
    public abstract class BaseCharacter : MovableObject{
        public BaseCharacter(GraphicsDevice g, Texture2D img, Point p,Tile[,] tiles)
            : base(g,img, p) {

        }
    }
}
