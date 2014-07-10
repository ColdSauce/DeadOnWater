using DeadOnWater.CollisionEngine;
using DeadOnWater.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadOnWater.PhysicalObjects.Characters {
    class MainPlayer : BaseCharacter {

        private static MainPlayer mp = null;
        private readonly float  SPEED = 10;
        private readonly Vector2 RIGHT;
        private readonly Vector2 LEFT;
        private readonly Vector2 UP;
        private readonly Vector2 DOWN;
        private readonly Collision collisions;

        public static MainPlayer getPlayer(GraphicsDevice g, Texture2D t, Point p,Tile[,] tiles){
            if(mp == null){
                mp = new MainPlayer(g,t,p,tiles);
            }
            return mp;

        }

        private MainPlayer(GraphicsDevice g, Texture2D t, Point p,Tile[,] tiles) : base(g,t,p,tiles) {
            RIGHT = new Vector2(SPEED, 0);
            LEFT = new Vector2(-SPEED, 0);
            UP = new Vector2(0, -SPEED);
            DOWN = new Vector2(0, SPEED);
            collisions = new Collision(tiles);

        }

        KeyboardState OldKeyState;
        bool jumped;

        public override void Update(GameTime gt) {
            base.Update(gt);
            if(Keyboard.GetState().IsKeyDown(Keys.Right)){
                move(RIGHT,gt);
            }
             if (Keyboard.GetState().IsKeyDown(Keys.Left)) {
                move(LEFT,gt);
            }
             if (Keyboard.GetState().IsKeyDown(Keys.Down)) {
                move(DOWN,gt);
            }

             if (isOnGround()) {
                 jumped = false;
                 KeyboardState NewKeyState = Keyboard.GetState();
      
                  if (NewKeyState.IsKeyDown(Keys.Up) && OldKeyState.IsKeyUp(Keys.Up))
                  {
                      jumped = true;
                  }

                  OldKeyState = NewKeyState;
             }
             if (jumped) {
                 move(UP,gt);
             }

             

             
           

        }
        public override void move(Vector2 v,GameTime gt) {
            if(collisions.canMove(v,this))
                base.setP(new Point((base.getP().X + (int)v.X),(base.getP().Y +(int) v.Y)));
        }


    }
}
