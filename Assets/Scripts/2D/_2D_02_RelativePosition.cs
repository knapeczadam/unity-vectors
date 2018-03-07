using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_02_RelativePosition : MonoBehaviour 
	{
		private GameObject _player;
		private Vector2 _playerPosition;
		
		[Header("Player")]
		[_CA_Color(_Color.Red, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _playerX;
		
		[_CA_Color(_Color.Green, order = 0)]
		[_CA_Range("Y", -50, 50, order = 1)]
		[SerializeField]
		private float _playerY;
		
		// -----
		
		private GameObject _enemy;
		private Vector2 _enemyPosition;
		
		[Header("Enemy")]
		[_CA_Color(_Color.Red, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _enemyX;
		
		[_CA_Color(_Color.Green, order = 0)]
		[_CA_Range("Y", -50, 50, order = 1)]
		[SerializeField]
		private float _enemyY;

		[Space] 
		
		[Header("Player")]
		[_CA_ReadOnly]
		[SerializeField]
		private Vector2 _relativeToOrigin;
		
		[_CA_ReadOnly]
		[SerializeField] 
		private Vector2 _relativeToEnemy;
		
		private readonly Vector2 _zero = Vector2.zero;
		
		private void OnEnable()
		{
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
			_enemy = GameObject.FindWithTag(Constant.ENEMY_2D);
		}

		// Use this for initialization
		void Start () 
		{
			// https://www.geogebra.org/m/qFd8fZVR
		}
		
		// Update is called once per frame
		void Update () 
		{
			UpdatePlayerPosition();
			UpdateEnemyPosition();

			/*
			 * Q: Is position a vector?
			 *
			 * Q: What's the meaning of motion is relative?
			 */
			_relativeToOrigin = _playerPosition;
			_relativeToEnemy = _playerPosition - _enemyPosition;
		}
		
		private void LateUpdate()
		{
			DebugLines();
		}

		private void UpdatePlayerPosition()
		{
			_playerPosition = new Vector2(_playerX, _playerY);
			_player.transform.position = _playerPosition;
		}

		private void UpdateEnemyPosition()
		{
			_enemyPosition = new Vector2(_enemyX, _enemyY);
			_enemy.transform.position = _enemyPosition;
		}

		private void DebugLines()
		{
			Debug.DrawLine(_zero, new Vector2(_playerX, 0), Color.red);
			Debug.DrawLine(new Vector2(_playerX, 0), new Vector2(_playerX, _playerY), Color.green);
			
			Debug.DrawLine(_playerPosition, new Vector2(_playerPosition.x + (_enemyPosition - _playerPosition).x, _playerPosition.y), Color.red);
			Debug.DrawLine(new Vector2(_playerPosition.x + (_enemyPosition - _playerPosition).x, _playerPosition.y), _enemyPosition, Color.green);
		}
	}
}
