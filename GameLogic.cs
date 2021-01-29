using System;
using System.Drawing;
using System.Windows.Input;

namespace miniDoomLike
{


    class GameLogic
    {
        //private GameSprite playerSprite;
        private int cpt1, cpt2, cpt3;
        public Size Resolution { get; set; }

        public void Load()
        {
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
            gfx.FillRectangle(new SolidBrush(Color.FromArgb(cpt1,cpt2,cpt3)), new Rectangle(0, 0, 200, 200));
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
            }
        }
    }
}