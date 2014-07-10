using DeadOnWater.PhysicalObjects.Characters;
using DeadOnWater.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace DeadOnWater.GameStates {
    class TestState: GameState{

        private int ID;

        //This tile array is a representation of the blocks on the screen NOT PIXELS
        private Tile[,] tiles;
        private Texture2D grass;
        private Texture2D wall;
        private Texture2D mainPlayer;
        private GraphicsDevice g;
        List<BaseCharacter> characters = new List<BaseCharacter>();
        public TestState(int ID,GraphicsDevice g) {
            this.g = g;
            this.ID = ID;
        }
         public void Update(GameTime gameTime) {
             UpdateCharacters(characters, gameTime);
        }

        //TODO: Make this more object oriented
         public void UpdateCharacters(List<BaseCharacter> bc, GameTime gt) {
             foreach (BaseCharacter b in bc) {
                 b.Update(gt);
             }
         }
        //TODO: Make this more object oriented
         public void drawCharacters(List<BaseCharacter> bc,SpriteBatch sb) {
             foreach (BaseCharacter b in bc) {
                 b.Draw(sb);
             }
         }

        public  void Draw(SpriteBatch sb,GameTime gameTime) {
            for (int x = 0; x < DeadOnWater.SCREEN_WIDTH; x += DeadOnWater.BLOCK_SIZE) {
                for (int y = 0; y < DeadOnWater.SCREEN_HEIGHT; y += DeadOnWater.BLOCK_SIZE) {
                    Tile currentBox = new Tile(new Point(x,y));
                    if (y > (int)(DeadOnWater.SCREEN_HEIGHT / 1.5)) {

                        sb.Draw(grass, new Rectangle(x, y, DeadOnWater.BLOCK_SIZE, DeadOnWater.BLOCK_SIZE), Color.White);
                        currentBox.setSolid(true);
                    }
                    tiles[x,y] = currentBox;
                }
            }
            drawCharacters(characters, sb);

        }
        public  void LoadContent(ContentManager content) {
            mainPlayer = content.Load<Texture2D>("mainPlayer.png");
            grass = content.Load<Texture2D>("grass.png");
            wall = content.Load<Texture2D>("wall.png");
            tiles = new Tile[DeadOnWater.SCREEN_WIDTH / 32,DeadOnWater.SCREEN_HEIGHT/32];

            characters.Add(MainPlayer.getPlayer(g,mainPlayer,new Point(100,200),tiles));
        }
        public  void UnLoadContent(ContentManager content) {
            content.Unload();
        }

        public int GetId() {
            return ID;
        }

        public void SetID(int ID) {
            this.ID = ID;
        }

        public Tile[,] GetTiles() {
            return tiles;
        }



    }
}
