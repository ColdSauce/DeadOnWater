using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeadOnWater.GameStates {
    class GameStateManager {
        private Stack<GameState> gameStateHierarchy = new Stack<GameState>();

        // Private constructor so that this class cannot be instansiated without the singleton.
        private GameStateManager() {

        }
        //Singleton
        private static GameStateManager instance;
        public static GameStateManager getInstance() {
            if (instance == null) {
                return (instance = new GameStateManager());
            }
            return instance;
        }
        //----

        public void addToHier(GameState state) {
            foreach (GameState gs in gameStateHierarchy) {
                //No two same states should be in the same hierarchy.
                if (gs.GetId() == state.GetId()) {
                    return;
                }
            }
            gameStateHierarchy.Push(state);
        }

        public void goBack() {
            if (gameStateHierarchy.Peek().GetId() == 0) {
                // 0 = Menu, nothing before that!
                return;
            }
            gameStateHierarchy.Pop();
        }

        public GameState getCurrentGameState() {
            return gameStateHierarchy.Peek();
        }





    }
}
