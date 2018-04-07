using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._3D
{
    [ExecuteInEditMode]
    public class _3D_03_Magnitude : _3D_Base 
    {
        [Space]
		
        [_CA_ReadOnly]
        public float Magnitude;
			
        private void OnEnable()
        {
            _player = GameObject.FindWithTag(Constant.PLAYER_3D);
        }
	
        // Use this for initialization
        void Start () 
        {
            
        }
		
        // Update is called once per frame
        void Update () 
        {
            UpdatePlayerPosition();
            
            Magnitude = CalculateMagnitude();
        }
		
        private float CalculateMagnitude()
        {
            return Mathf.Sqrt(_playerX * _playerX + _playerY * _playerY + _playerZ * _playerZ);
        }
		
        protected override void DebugLines()
        {
            Debug.DrawLine(_zero, _playerPosition, Color.cyan);
            Debug.DrawLine(_zero, new Vector3(_playerX, 0, _playerZ), Color.red);
            Debug.DrawLine(new Vector3(_playerX, 0, _playerZ), _playerPosition, Color.green);
        }
    }
}
