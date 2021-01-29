using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Diagnostics;

namespace miniDoomLike
{
    class GameLoop
    {
        private GameLogic game;

        /// <summary>
        /// Status of GameLoop
        /// </summary>
        public bool Running { get; private set; }

        /// <summary>
        /// Load Game into GameLoop
        /// </summary>
        public void Load(GameLogic gameObj)
        {
            game = gameObj;
        }

        /// <summary>
        /// Start GameLoop
        /// </summary>
        public async void Start()
        {

            // TODO with control and gamelogic
            /*if (game == null)
                throw new ArgumentException("Game not loaded!");

            // Load game content
            game.Load();

            // Set gameloop state
            Running = true;

            // Set previous game time
            Stopwatch chrono = Stopwatch.StartNew();

            while (Running)
            {
                // Calculate the time elapsed since the last game loop cycle
                long tmp = chrono.ElapsedMilliseconds;
                // Update the current previous game time
                chrono.Restart();
                // Update the game
                game.Update(tmp);
                // Update Game at 60fps
                await Task.Delay((int)Math.Max(8 - chrono.ElapsedMilliseconds, 0));
            }*/
        }

        /// <summary>
        /// Stop GameLoop
        /// </summary>
        public void Stop()
        {
            Running = false;
            game?.Unload();
        }

        /// <summary>
        /// Draw Game Graphics
        /// </summary>
        public void Draw(Graphics gfx)
        {
            game.Draw(gfx);
        }
    }
}