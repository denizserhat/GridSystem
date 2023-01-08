using System;
using UnityEngine;

namespace GridSystem
{
    public class GridManager : MonoBehaviour
    {
        public GridDataSo gridDataSo;

        private Grid[,] _grids; 
        
        private void Start()
        {
            if (gridDataSo != null) 
                Execute();

        }

        public void Execute()
        {
            _grids = new Grid[gridDataSo.coloumnCount, gridDataSo.rowCount];
            for (int i = 0; i < gridDataSo.coloumnCount; i++)
            {
                for (int j = 0; j < gridDataSo.rowCount; j++)
                {
                    var go = Instantiate(gridDataSo.prefab);
                    go.transform.position = new Vector3(i + i * gridDataSo.offset, 0, j + j * gridDataSo.offset);
                    _grids[i, j] = new Grid(i,j, go);
       
                }
            }
        }
    }
}