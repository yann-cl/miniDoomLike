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
            player = new Player(map.entryPoint, new Vector2D(0,1));
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
                    gfx.FillRectangle(brush, new Rectangle(i*2,j*2,2,2));
                }
            }
            brush.Color = player.skin;
            gfx.FillRectangle(brush, new Rectangle((int)Math.Round(player.coord.x)*2, (int)Math.Round(player.coord.y)*2,2,2));
        }
    }
}