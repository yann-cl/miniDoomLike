using System.Drawing;

namespace miniDoomLike
{
    class Player
    {
        public Color skin{get; private set;}
        public Vector2D coord{get; private set;}

        //création d'une entité joueur (à placer sur la map)
        public Player(){
            double x=2.5, y=2.5;
            this.skin = Color.Blue;
            this.coord = new Vector2D(x, y);
        }

    }
}