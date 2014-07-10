
using DeadOnWater.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadOnWater.PhysicalObjects {
    public abstract class GameObject: GameObjectInterface {
        private Texture2D img;
        private GraphicsDevice g;
        private Point p;
        public GameObject(GraphicsDevice g, Texture2D img, Point p) {
            this.img = img;
            this.p = p;
            this.g = g;
        }

        public void Draw(SpriteBatch sb) {
            sb.Draw(img, new Rectangle(p.X, p.Y, DeadOnWater.BLOCK_SIZE, DeadOnWater.BLOCK_SIZE), Color.White);
        }
        public void setP(Point p) {
            this.p = p;
        }

        public Point getP() {
            return p;

        }
        public virtual void Update(GameTime gt)  {
            
        }
        public GraphicsDevice getGraphicsDevice() {
            return g;
        }
        public Texture2D getImg() {
            return img;
        }

    }
}