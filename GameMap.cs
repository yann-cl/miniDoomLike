using System.Drawing;

namespace miniDoomLike{
    class GameMap
    {
        
        public Color[,] cases{get; private set;}
        public Vector2D entryPoint{get; private set;}
        //créer et remplit un tableau map
        public GameMap(){
            cases= new Color[200,200];
            for(int i=0; i<this.cases.GetLength(0);i++){
                for(int j=0; j<this.cases.GetLength(1);j++){
                    this.cases[i,j]= Color.White;
                }
            }
            //mur de la map
            contour(Color.Red);
            //point d'entrée de la map
            entryPoint = new Vector2D(2,20);
            cases[(int)entryPoint.x,(int)entryPoint.y] = Color.Orange;
        }
        //init le contour de la map de couleur différente
        private void contour(Color couleur){
            
            for(int i=0;i<this.cases.GetLength(0);i++){
                this.cases[i,0]= couleur;
                this.cases[i,199]= couleur;
            }
            for(int j=0;j<this.cases.GetLength(1);j++){
                this.cases[0,j]= couleur;
                this.cases[199,j]= couleur;
            }
        }
    }
}