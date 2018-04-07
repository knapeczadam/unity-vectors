using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._3D
{
    [ExecuteInEditMode]
    public class _3D_02_RelativePosition : _3D_Base
    {
        [Header("Enemy")]
        [_CA_Color(_Color.Red, order = 0)]
        [_CA_Range("X", -50, 50, order = 1)]
        [SerializeField]
        private float _enemyX;
		
        [_CA_Color(_Color.Green, order = 0)]
        [_CA_Range("Y", -50, 50, order = 1)]
        [SerializeField]
        private float _enemyY;
        
        [_CA_Color(0, 1, 255, order = 0)]
        [_CA_Range("Z", -50, 50, order = 1)]
        [SerializeField]
        private float _enemyZ;

        [Space] 
		
        [Header("Player")]
        [_CA_ReadOnly]
        [SerializeField]
        private Vector3 _relativeToOrigin;
		
        [_CA_ReadOnly]
        [SerializeField] 
        private Vector3 _relativeToEnemy;
		
        private void OnEnable()
        {
            _player = GameObject.FindWithTag(Constant.PLAYER_3D);
            _enemy = GameObject.FindWithTag(Constant.ENEMY_3D);
        }

        // Use this for initialization
        void Start () 
        {
            
        }
		
        // Update is called once per frame
        void Update () 
        {
            UpdatePlayerPosition();
            UpdateEnemyPosition(_enemyX, _enemyY, _enemyZ);

            _relativeToOrigin = _playerPosition;
            _relativeToEnemy = _playerPosition - _enemyPosition;
        }

        protected override void DebugLines()
        {
            Debug.DrawLine(_zero, new Vector3(_playerX, 0, 0), Color.red);
            Debug.DrawLine(new Vector3(_playerX, 0, 0), new Vector3(_playerX, _playerY, 0), Color.green);
            Debug.DrawLine(new Vector3(_playerX, _playerY, 0), new Vector3(_playerX, _playerY, _playerZ), Color.blue);
			
            Debug.DrawLine(new Vector3(_playerX, _playerY, _playerZ), new Vector3(_playerX + (_enemyX - _playerX), _playerY, _playerZ), Color.red);
            Debug.DrawLine(new Vector3(_playerX + (_enemyX - _playerX), _playerY, _playerZ), new Vector3(_playerX + (_enemyX - _playerX), _playerY + (_enemyY - _playerY), _playerZ), Color.green);
            Debug.DrawLine(new Vector3(_playerX + (_enemyX - _playerX), _playerY + (_enemyY - _playerY), _playerZ), new Vector3(_playerX + (_enemyX - _playerX), _playerY + (_enemyY - _playerY), _playerZ + (_enemyZ - _playerZ)), Color.blue);
        }
    }
}

