#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using DeadOnWater.GameStates;
using DeadOnWater.PhysicalObjects.Characters;
#endregion

namespace DeadOnWater
{
    public class DeadOnWater : Game
    {
        

        private static GraphicsDeviceManager graphics;
        private GameStateManager gsm = GameStateManager.getInstance();
        public static readonly int SCREEN_WIDTH = 768;
        public static readonly int SCREEN_HEIGHT = 768;
        public static readonly int BLOCK_SIZE = 32;
        private SpriteBatch sb;

        // 0 is the lowest ID a state could have. (Menu in most cases).
        private readonly GameState BASE_STATE;


        

        public DeadOnWater()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            BASE_STATE = new TestState(0, graphics.GraphicsDevice);
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
            graphics.PreferredBackBufferWidth = SCREEN_WIDTH ;
            graphics.ApplyChanges();
            gsm.addToHier(BASE_STATE);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            sb = new SpriteBatch(graphics.GraphicsDevice);
            gsm.getCurrentGameState().LoadContent(this.Content);
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();  
            gsm.getCurrentGameState().Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            sb.Begin();
            gsm.getCurrentGameState().Draw(sb,gameTime);

            base.Draw(gameTime);
            sb.End();
        }
    }
}
