using DeadOnWater.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadOnWater.PhysicalObjects
{
    public abstract class MovableObject : GameObject {

        private Boolean onGround;
        private MainEngine physics;
		public MovableObject(GraphicsDevice g, Texture2D img, Point p) : base(g,img,p) {

            physics = new MainEngine(this);
		}

        public Boolean isOnGround() {
            return onGround;
        }

		public  abstract void move(Vector2 dir,GameTime gt);

		public override void Update(GameTime gt){
            base.Update(gt);


            if (base.getP().Y > 477) {
                base.setP(new Point(base.getP().X, 477));
            }

            onGround = (base.getP().Y >= 477);
         

			physics.Update(gt);
		}

    }
}
