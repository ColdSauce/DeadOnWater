using DeadOnWater.PhysicalObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadOnWater.Physics {
    class MainEngine {


        private Vector2 force = new Vector2(0);
        private  float GRAVITATIONAL_POWER = 2f;
        private  Vector2 GRAVITY;
        private MovableObject parentObject;
        public MainEngine(MovableObject parentObject){
            this.parentObject = parentObject;
            GRAVITY = new Vector2(0, GRAVITATIONAL_POWER);

            




        }

        public  void Update(GameTime g){
            if (!parentObject.isOnGround()) {

                parentObject.move(GRAVITY = GRAVITY + (GRAVITY/20),g);

                //Console.WriteLine("moving the object with vector" + GRAVITY.X + "," + GRAVITY.Y);
            }
            else{
                GRAVITY = new Vector2(0,GRAVITATIONAL_POWER);
            }
            





        }
    }
}
