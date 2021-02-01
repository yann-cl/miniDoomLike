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
            //murs de la map
            contour(Color.Red);
            murs(Color.Red);
            
            //point d'entrée de la map
            entryPoint = new Vector2D(100,50);
            cases[(int)entryPoint.x,(int)entryPoint.y] = Color.Orange;
        }
        //init le contour de la map de couleur différente
        private void contour(Color couleur){
            
            for(int i=0;i<this.cases.GetLength(0);i++){
                this.cases[i,0]= couleur;
                this.cases[i,(this.cases.GetLength(0)/1)-1]= couleur;
            }
            for(int j=0;j<this.cases.GetLength(1);j++){
                this.cases[0,j]= couleur;
                this.cases[(this.cases.GetLength(1)/1)-1,j]= couleur;
            }
        }
        private void murs(Color couleur){
            //milieu de la map
            for(int i=0; i<this.cases.GetLength(0)/3; i++){
                this.cases[i,this.cases.GetLength(0)/2]= couleur;
                for(int j=(this.cases.GetLength(0)/3)*2; j<this.cases.GetLength(0); j++){
                    this.cases[j,this.cases.GetLength(0)/2]= couleur;
                }
            }
            //haut de la map
            for(int i=this.cases.GetLength(0)/4;i<3*this.cases.GetLength(0)/8;i++){
                this.cases[i,this.cases.GetLength(0)/8]= couleur;
                for(int j=5*this.cases.GetLength(0)/8;j<3*this.cases.GetLength(0)/4;j++){
                    this.cases[j,this.cases.GetLength(0)/8]= couleur;
                }
            }
            for(int i=this.cases.GetLength(0)/4;i<3*this.cases.GetLength(0)/4;i++){
                this.cases[i,this.cases.GetLength(0)/3]= couleur;
            }
            for(int j=this.cases.GetLength(1)/8;j<(this.cases.GetLength(1)/3)+1;j++){
                this.cases[this.cases.GetLength(1)/4,j]= couleur;
                this.cases[3*this.cases.GetLength(1)/4,j]= couleur;
            }
            //bas de la map
            for(int i=this.cases.GetLength(0)/4;i<3*this.cases.GetLength(0)/4;i++){
                this.cases[i,2*this.cases.GetLength(0)/3]= couleur;
            }
            for(int i=this.cases.GetLength(0)/4;i<3*this.cases.GetLength(0)/8;i++){
                this.cases[i,7*this.cases.GetLength(0)/8]= couleur;
                for(int j=5*this.cases.GetLength(0)/8;j<3*this.cases.GetLength(0)/4;j++){
                    this.cases[j,7*this.cases.GetLength(0)/8]= couleur;
                }
            }
            for(int j=2*this.cases.GetLength(1)/3;j<(7*this.cases.GetLength(1)/8)+1;j++){
                this.cases[this.cases.GetLength(1)/4,j]= couleur;
                this.cases[3*this.cases.GetLength(1)/4,j]= couleur;
            }
        }
    }
}