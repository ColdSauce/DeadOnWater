using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadOnWater.Util {
     public class Tile {
         private Point p;
        private LANDTYPE landType;
        private bool solid;
        public Tile(Point p) {
            this.p = p;
            //default land type will be clear
            landType = LANDTYPE.CLEAR;

            //default solidity is not solid
            this.solid = false;
        }

        public Point getP() {
            return p;
        }
         public Tile setLandType(LANDTYPE landType) {
            if (landType != LANDTYPE.CLEAR) {
                solid = false;
            }

            this.landType = landType;

            return this;
        }
         public LANDTYPE getLandType() {
            return landType;
        }
         public Tile setSolid(Boolean solid) {
             this.solid = solid;

             return this;
         }
         public bool isSolid() {
            return solid;
        }


    }
}
