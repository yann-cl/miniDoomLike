using System;
using System.Drawing;
using System.Windows.Input;

namespace miniDoomLike
{


    class GameLogic
    {
        private GameMap map;
        private int cpt1, cpt2, cpt3;
        public Size Resolution { get; set; }

        public void Load()
        {
            map = new GameMap();
            this.cpt1 = 0;
            this.cpt2 = 0;
            this.cpt3 = 0;
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
            /*gfx.FillRectangle(new SolidBrush(Color.FromArgb(cpt1,cpt2,cpt3)), new Rectangle(0, 0, 200, 200));
            cpt1++;
            if(cpt1 > 255){
                cpt1 = 0;
                cpt2++;
            } 
            if(cpt2 > 255){
                cpt2 = 0;
                cpt3++;
            }
            if(cpt3 > 255){
                cpt3 = 0;
            }*/
            for(int i=0;i<map.cases.GetLength(0);i++){
                for(int j=0;j<map.cases.GetLength(1);j++){
                    gfx.FillRectangle(new SolidBrush(map.cases[i,j]), new Rectangle(i,j,1,1));
                }
            }
        }
    }
}