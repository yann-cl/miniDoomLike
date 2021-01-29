using System.Drawing;

namespace miniDoomLike{
    class GameMap
    {
        public Color[,] cases{get; private set;}

        public GameMap(){
            cases= new Color[200,200];
            for(int i=0; i<this.cases.GetLength(0);i++){
                for(int j=0; j<this.cases.GetLength(1);j++){
                    this.cases[i,j]= Color.White;
                }
            }
            contour(Color.Red);
        }

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