using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
    public abstract class _2D_Base : MonoBehaviour
    {
        [SerializeField]
        protected bool _debugLines = true;
        
        protected GameObject _player;
        protected Vector2 _playerPosition;
		
        [Header("Player")]
        [_CA_Color(_Color.Red, order = 0)]
        [_CA_Range("X", -50, 50, order = 1)]
        [SerializeField]
        protected float _playerX;
		
        [_CA_Color(_Color.Green, order = 0)]
        [_CA_Range("Y", -50, 50, order = 1)]
        [SerializeField]
        protected float _playerY;
        
        // -----
        
        protected GameObject _enemy;
        protected Vector2 _enemyPosition;
        
        protected readonly Vector2 _zero = Vector2.zero;
        
        protected virtual void LateUpdate()
        {
            if (_debugLines)
            {
                DebugLines();
            }
        }
        
        protected virtual void UpdatePlayerPosition()
        {
            _playerPosition = new Vector2(_playerX, _playerY);
            _player.transform.position = _playerPosition;
        }
        
        protected virtual void UpdateEnemyPosition(float enemyX, float enemyY)
        {
            _enemyPosition = new Vector2(enemyX, enemyY);
            _enemy.transform.position = _enemyPosition;
        }
        
        protected virtual void DebugLines()
        {
            Debug.DrawLine(_zero, _playerPosition, Color.green);
        }
    }
}