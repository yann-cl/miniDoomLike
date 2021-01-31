using System.Drawing;

namespace miniDoomLike
{
    class Player
    {
        public Color skin{get; private set;}
        public Vector2D coord{get; private set;}
        public Vector2D dirView{get; private set;}

        //création d'une entité joueur (à placer sur la map)
        public Player(Vector2D view, Vector2D dir){
            this.skin = Color.Blue;
            this.coord = view;
            this.dirView = dir;
        }

    }
}