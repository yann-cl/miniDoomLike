using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;

namespace miniDoomLike
{
    class GameLoop
    {
        private GameLogic game;

        /// <summary>
        /// Status of GameLoop
        /// </summary>
        public bool running { get; private set; }

        private Dictionary<int,bool> movements {get; set; }

        /// <summary>
        /// Load Game into GameLoop
        /// </summary>
        public void Load(GameLogic gameObj)
        {
            game = gameObj;
            running = false;

            movements = new Dictionary<int, bool>();
            //movements possible
            movements.Add(90,false); //touche Z
            movements.Add(81,false); //touche Q
            movements.Add(68,false); //touche D
        }

        /// <summary>
        /// Start GameLoop
        /// </summary>
        public async void Start()
        {

            if (game == null)
                throw new ArgumentException("Game not loaded!");

            running = true;

            //Stopwatch chrono = Stopwatch.StartNew();

            while (running)
            {
                // Calculate the time elapsed since the last game loop cycle
                //long tmp = chrono.ElapsedMilliseconds;
                // Update the current previous game time
                //chrono.Restart();
                // Update the game
                game.Update(movements);
                // Update Game at 60fps
                //await Task.Delay((int)Math.Max(8 - chrono.ElapsedMilliseconds, 0));
                await Task.Delay(8);
            }
        }

        /// <summary>
        /// Stop GameLoop
        /// </summary>
        public void Stop()
        {
            running = false;
            game?.Unload();
        }

        /// <summary>
        /// Draw Game Graphics
        /// </summary>
        public void Draw(Graphics gfx)
        {
            game.Draw(gfx);
        }

        public void addMovement(int move){
            if(movements.ContainsKey(move)){
                movements[move] = true;
            }
        }

        public void suppMovement(int move){
            if(movements.ContainsKey(move)){
                movements[move] = false;
            }
        }
    }
}