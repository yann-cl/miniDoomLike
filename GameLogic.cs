using System;
using System.Drawing;
using System.Windows.Input;
using System.Collections.Generic;

namespace miniDoomLike
{


    class GameLogic
    {
        private GameMap map;
        private Player player;
        
        public Size resolution { get; set; }

        public static int ratio {get; private set;}

        public void Load()
        {
            map = new GameMap();
            int vision = 100;
            player = new Player(map.entryPoint, 0, Math.PI * vision / 180.0);
            ratio = 1;
        }

        public void Unload()
        {
            //empty for now
        }

        public void Update(Dictionary<int,bool> movements)
        {

            //move part
            if(movements[90]) // Z --> dir == player view
                player.move(player.dirView);
            if(movements[65]) // A --> dir == player view - pi/2
                player.move(player.dirView - Math.PI/2);
            if(movements[69]) // E --> dir == player view + pi/2
                player.move(player.dirView + Math.PI/2);
            if(movements[83]) // S --> dir == player view + pi
                player.move(player.dirView + Math.PI);


            //rotate part
            double r = 0;
            if(movements[81]) // Q --> rotate angle
                r += -0.1;
            if(movements[68]) // D --> rotate angle
                r += 0.1;
            player.rotate(r);
        }

        public void Draw(Graphics gfx)
        {
            SolidBrush brush = new SolidBrush(Color.Gray);
            int gameR = GameLogic.ratio;
            // Draw Background Color
            for(int i=0;i<map.cases.GetLength(0);i++){
                for(int j=0;j<map.cases.GetLength(1);j++){
                    brush.Color = map.cases[i,j].texture;
                    gfx.FillRectangle(brush, new Rectangle(i*gameR,j*gameR,gameR,gameR));
                }
            }
            brush.Color = player.skin;
            player.drawPlayerFOV(gfx, map, resolution);
            //player.dirView += 0.05; // rotation view to test
        }
    }
}