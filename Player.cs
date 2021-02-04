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
        
        public double speed{get; set;}

        //création d'une entité joueur (à placer sur la map)
        public Player(Vector2D position, double dir, double v){
            this.skin = Color.Blue;
            this.coord = position;
            this.dirView = dir%(Math.PI*2);
            this.vision = v%(Math.PI*2);
            this.speed = 0.1; // speed test
        }

        public void move(double dir){
            this.coord.sum(new Vector2D(Math.Cos(dir)*this.speed,Math.Sin(dir)*this.speed));
        }

        public void drawPlayerFOV(Graphics gfx, GameMap gamemap, Size resolution)
        {
            SolidBrush brush = new SolidBrush(Color.Yellow);

            Vector2D v = new Vector2D(coord.x, coord.y);
            Vector2D step = new Vector2D(Math.Cos(this.dirView),Math.Sin(this.dirView));

            int gameR = GameLogic.ratio;

            //dessin fov
            drawRay(gfx,gamemap,this.dirView,brush,resolution,0);

            double modRay = this.vision/(resolution.Width/2);
            for(int i = 0; i < resolution.Width/4;i++){
                drawRay(gfx,gamemap,this.dirView + i*modRay,brush, resolution,i);
                drawRay(gfx,gamemap,this.dirView - i*modRay,brush, resolution,-i);
            }

            //position joueur
            brush.Color = this.skin;
            gfx.FillRectangle(brush, new Rectangle((int)Math.Round(coord.x)*gameR, (int)Math.Round(coord.y)*gameR,gameR,gameR));
        }

        public void drawRay(Graphics gfx, GameMap gamemap, double angle, SolidBrush brush, Size resolution,int pos){
            
            Vector2D v = new Vector2D(coord.x, coord.y);
            Vector2D step = new Vector2D(Math.Cos(angle),Math.Sin(angle));

            int d = 0;
            int gameR = GameLogic.ratio;
            brush.Color = Color.Yellow;
            Rectangle r = new Rectangle((int)Math.Round(v.x)*gameR, (int)Math.Round(v.y)*gameR,gameR,gameR);
            while(!gamemap.cases[(int)Math.Round(v.x),(int)Math.Round(v.y)].block){
                gfx.FillRectangle(brush, r);
                r.X = (int)Math.Round(v.x)*gameR;
                r.Y = (int)Math.Round(v.y)*gameR;
                v.sum(step);
                d += 1;
            }
            
            brush.Color = Color.Green;
            r.X = (int)Math.Round(v.x)*gameR;
            r.Y = (int)Math.Round(v.y)*gameR;
            gfx.FillRectangle(brush, r);

            int colSize = resolution.Height/d;
            brush.Color = Color.Red;
            r.X = 3*resolution.Width/4 + pos;
            r.Y = resolution.Height/2 - colSize/2;
            r.Width = gameR;
            r.Height = colSize;
            gfx.FillRectangle(brush, r);

        }

    }
}