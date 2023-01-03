using UnityEngine;

namespace GridSystem
{
    public class Grid
    {

        public Grid(int coloumn, int row, GameObject gridObjectInScene)
        {
            this.coloumn = coloumn;
            this.row = row;
            this.gridObjectInScene = gridObjectInScene;

            
        }

        private int row;
        private int coloumn;
        public GameObject gridObjectInScene;

        public int Coloumn => coloumn;
        public int Row => row;
    }
    
    
}
