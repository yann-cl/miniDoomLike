using System.Drawing;
namespace miniDoomLike
{
    class Case
    {
        public Color texture{get; private set;}
        public bool block{get; private set;}

        //création d'une entité joueur (à placer sur la map)
        public Case(Color c, bool b){
            this.texture = c;
            block = b;
        }

    }
}