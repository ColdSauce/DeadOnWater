using DeadOnWater.PhysicalObjects.Characters;
using DeadOnWater.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadOnWater.CollisionEngine {
    class Collision {

        private Tile[,] tiles;

        //Every state will have a collision class

        public Collision(Tile[,] tiles) {
            this.tiles = tiles;
        }

        private bool isPointInSolidTile(Point p) {
            Console.WriteLine("p is " + p);
            Console.WriteLine(DeadOnWater.BLOCK_SIZE);
            Console.WriteLine(tiles.Length);
            for (int i = 0; i < tiles.GetLength(0); i++) {
                for (int j = 0; j < tiles.GetLength(1); j++) {
                    Console.WriteLine("Tile " + i + " " + j + " "+ tiles[i,j]);
                }
            }
            Console.WriteLine(tiles[p.X / DeadOnWater.BLOCK_SIZE, p.Y / DeadOnWater.BLOCK_SIZE]);
            return tiles[p.X / DeadOnWater.BLOCK_SIZE, p.Y / DeadOnWater.BLOCK_SIZE].isSolid();
        }
        public bool canMove(Vector2 v,BaseCharacter parent) {
            
            return !isPointInSolidTile(new Point((int)v.X + parent.getP().X, (int)v.Y + parent.getP().Y));
        }
    }
}
