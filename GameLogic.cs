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
            SolidBrush brush = new SolidBrush(Color.Gray);
            // Draw Background Color
            for(int i=0;i<map.cases.GetLength(0);i++){
                for(int j=0;j<map.cases.GetLength(1);j++){
                    brush.Color = map.cases[i,j];
                    gfx.FillRectangle(brush, new Rectangle(i,j,1,1));
                }
            }
            brush.Color = player.skin;
            gfx.FillRectangle(brush, new Rectangle((int)Math.Round(player.coord.x), (int)Math.Round(player.coord.y),1,1));
        }
    }
}