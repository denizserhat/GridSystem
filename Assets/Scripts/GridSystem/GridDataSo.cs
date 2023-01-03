using System;
using UnityEngine;

namespace GridSystem
{
    [CreateAssetMenu(menuName = "GridSystem/Create GridDataSo", fileName = "GridDataSo", order = 0)]
    public class GridDataSo : ScriptableObject
    {
        public int coloumnCount;
        public int rowCount;
        public float offset = .1f;
        public GameObject prefab;

        private void OnValidate()
        {
            if (coloumnCount < 0)
            {
                coloumnCount = 0;
            }
            if (rowCount < 0)
            {
                rowCount = 0;
            }
            if (offset < 0)
            {
                offset = 0;
            }
        }
    }
}