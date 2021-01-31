namespace miniDoomLike
{
    class Vector2D
    {
        public double x{get; private set;}
        public double y{get; private set;}

        //création d'une entité joueur (à placer sur la map)
        public Vector2D(double paramX, double paramY){
            this.x = paramX;
            this.y = paramY;
        }

    }
}