using System.Drawing;
using System.Windows;

namespace miniDoomLike
{
    class Player
    {
        public Color skin{get; private set;}
        public System.Windows.Point coord{get; private set;}

        //création d'une entité joueur (à placer sur la map)
        public Player(){
            double x=2.5, y=2.5;
            this.skin = Color.Blue;
            this.coord = new Point(x, y);
        }

    }
}