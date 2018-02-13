using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_02_Relative_position : MonoBehaviour 
	{
		private GameObject _player;
		private Vector2 _playerPosition;
		
		[Header("Player")]
		[_CA_Color(1, 0, 0, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _playerX;
		
		[_CA_Color(0, 1, 0, order = 0)]
		[_CA_Range("Y", -50, 50, order = 1)]
		[SerializeField]
		private float _playerY;
		
		// -----
		
		private GameObject _enemy;
		private Vector2 _enemyPosition;
		
		[Header("Enemy")]
		[_CA_Color(1, 0, 0, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _enemyX;
		
		[_CA_Color(0, 1, 0, order = 0)]
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
			UpdatePosition();

			_relativeToOrigin = _playerPosition;
			_relativeToEnemy = _playerPosition - _enemyPosition;
		}
		
		private void UpdatePosition()
		{
			_playerPosition = new Vector2(_playerX, _playerY);
			_player.transform.position = _playerPosition;
			
			_enemyPosition = new Vector2(_enemyX, _enemyY);
			_enemy.transform.position = _enemyPosition;

			Draw();
		}

		private void Draw()
		{
			Debug.DrawLine(Vector2.zero, new Vector2(_playerX, 0), Color.red);
			Debug.DrawLine(new Vector2(_playerX, 0), new Vector2(_playerX, _playerY), Color.green);
			
			Debug.DrawLine(_playerPosition, new Vector2(_playerPosition.x + (_enemyPosition - _playerPosition).x, _playerPosition.y), Color.red);
			Debug.DrawLine(new Vector2(_playerPosition.x + (_enemyPosition - _playerPosition).x, _playerPosition.y), _enemyPosition, Color.green);
		}
	}
}
