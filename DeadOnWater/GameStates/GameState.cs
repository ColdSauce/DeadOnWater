#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using DeadOnWater.Util;
#endregion

namespace DeadOnWater.GameStates {
    public interface GameState {

        void Update(GameTime gameTime);
        void Draw( SpriteBatch sb, GameTime gameTime);
        void LoadContent(ContentManager content);
        void UnLoadContent(ContentManager content);
        int GetId();
        Tile[,] GetTiles();

    }
}
