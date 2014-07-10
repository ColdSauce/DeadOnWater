using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadOnWater.PhysicalObjects {
    public interface GameObjectInterface {

         void Draw(SpriteBatch g);
         void Update(GameTime gt);
    }
}
