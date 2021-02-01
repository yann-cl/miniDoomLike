using System.Drawing;
using System;
using System.Diagnostics;
namespace miniDoomLike
{
    class Player
    {
        public Color skin{get; private set;}
        public Vector2D coord{get; private set;}
        public double dirView{get; set;} // radians

        public double vision{get; private set;} // radians
        

        //création d'une entité joueur (à placer sur la map)
        public Player(Vector2D position, double dir, double v){
            this.skin = Color.Blue;
            this.coord = position;
            this.dirView = dir%(Math.PI*2);
            this.vision = v%(Math.PI*2);
        }

        public void drawPlayerFOV(Graphics gfx, GameMap gamemap, Size resolution)
        {
            SolidBrush brush = new SolidBrush(Color.Yellow);

            Vector2D v = new Vector2D(coord.x, coord.y);
            Vector2D step = new Vector2D(Math.Cos(this.dirView),Math.Sin(this.dirView));

            //dessin fov
            drawRay(gfx,gamemap,this.dirView,brush,resolution,0);

            double modRay = this.vision/resolution.Width;
            for(int i = 0; i < resolution.Width/4;i++){
                drawRay(gfx,gamemap,this.dirView + i*modRay,brush, resolution,i);
                drawRay(gfx,gamemap,this.dirView - i*modRay,brush, resolution,-i);
            }

            //position joueur
            brush.Color = this.skin;
            gfx.FillRectangle(brush, new Rectangle((int)Math.Round(coord.x)*2, (int)Math.Round(coord.y)*2,2,2));
        }

        public void drawRay(Graphics gfx, GameMap gamemap, double angle, SolidBrush brush, Size resolution,int pos){
            
            Vector2D v = new Vector2D(coord.x, coord.y);
            Vector2D step = new Vector2D(Math.Cos(angle),Math.Sin(angle));

            int d = 0;
            brush.Color = Color.Yellow;
            while(!gamemap.cases[(int)Math.Round(v.x),(int)Math.Round(v.y)].Equals(Color.Red)){
                gfx.FillRectangle(brush, new Rectangle((int)Math.Round(v.x)*2, (int)Math.Round(v.y)*2,2,2));
                v.sum(step);
                d += 1;
            }
            
            brush.Color = Color.Green;
            gfx.FillRectangle(brush, new Rectangle((int)Math.Round(v.x)*2, (int)Math.Round(v.y)*2,2,2));

            int colSize = resolution.Height/d;
            brush.Color = Color.Red;
            //Debug.WriteLine(resolution.Width);
            gfx.FillRectangle(brush, new Rectangle(3*resolution.Width/4 + pos, resolution.Height/2 - colSize/2,2,colSize));

        }

    }
}