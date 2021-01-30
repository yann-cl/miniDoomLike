using System;
using System.Drawing;
using System.Windows.Input;

namespace miniDoomLike
{


    class GameLogic
    {
        private GameMap map;
        private Player player;
        
        public Size Resolution { get; set; }

        public void Load()
        {
            map = new GameMap();
            player = new Player();
        }

        public void Unload()
        {
            //empty for now
        }

        public void Update(long gameTime)
        {
            // empty for now
        }

        public void Draw(Graphics gfx)
        {
            // Draw Background Color
            for(int i=0;i<map.cases.GetLength(0);i++){
                for(int j=0;j<map.cases.GetLength(1);j++){
                    gfx.FillRectangle(new SolidBrush(map.cases[i,j]), new Rectangle(i,j,1,1));
                }
            }
            gfx.FillRectangle(new SolidBrush(player.skin), new Rectangle(Math.Round(player.coord.X), Math.Round(player.coord.Y),1,1));
        }
    }
}