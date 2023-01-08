using System;
using GridSystem;
using UnityEngine;

namespace SelectionSystem
{
    public class SelectionManager : MonoBehaviour
    {
        [SerializeField] private Box box;
        [SerializeField] private LayerMask layerMask;
        
        private Camera _camera;
        private Vector3 _startPosition;
        private Vector3 _endPosition;
        private RaycastHit _hit;
        private GridManager _manager;

        private void Start()
        {
            _camera = Camera.main;
            _manager = FindObjectOfType<GridManager>();
        }

        private void Update()
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out _hit,Mathf.Infinity,layerMask))
            {           
                if (Input.GetMouseButtonDown(0))
                {
                    _startPosition = _hit.point;
                    box.boxStart = _startPosition;
                }

                if (Input.GetMouseButton(0))
                {

                    _endPosition = _hit.point;
                    box.boxEnd = _endPosition;
                }

                if (Input.GetMouseButtonUp(0))
                {
                    _manager.gridDataSo.rowCount = (int)box.Size.x;
                    _manager.gridDataSo.coloumnCount = (int)box.Size.z;
                    _manager.Execute();
                }
            }

        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(box.Center,box.Size);
            
        }
    }
    
    [Serializable]
    public class Box
    {
        public Vector3 boxStart;
        public Vector3 boxEnd;

        public Vector3 Center
        {
            get
            {
                Vector3 center = boxStart + (boxEnd-boxStart) * .5f;
                center.y = (boxEnd - boxStart).magnitude * .5f;
                return center;
            }
        }

        public Vector3 Size =>
            new Vector3(Mathf.Abs(boxEnd.x - boxStart.x), (boxEnd - boxStart).magnitude,
                Mathf.Abs(boxEnd.z - boxStart.z));
    }
}
