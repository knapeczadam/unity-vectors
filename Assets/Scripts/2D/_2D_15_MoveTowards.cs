using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_15_MoveTowards : MonoBehaviour 
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
		
		// -----
		
		[Space]
		
		[_CA_Color(_Color.White, order = 0)]
		[_CA_Range(-50, 50, order = 1)]
		[SerializeField]
		private float _maxDistance;
		
		private GameObject _bullet;
		
		private void OnEnable()
		{
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
			_enemy = GameObject.FindWithTag(Constant.ENEMY_2D);
			_bullet = GameObject.FindWithTag(Constant.BULLET_2D);
		}

		// Use this for initialization
		void Start () 
		{
			
		}
		
		// Update is called once per frame
		void Update ()
		{
			UpdatePlayerPosition();
			UpdateEnemyPosition();
			
			/*
			 * Q: Difference between Vector2.Lerp and Vector2.MoveTowards?
			 */
			_bullet.transform.position = MoveTowards(_player.transform.position, _enemy.transform.position, _maxDistance);
		}
		
		/*
		 * Q: This function doesn't work correctly. Can you fix it?
		 */
		private Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
		{
			Vector2 vector2 = current - target;
			float magnitude = vector2.magnitude;
			if ((double) magnitude >= (double) maxDistanceDelta || (double) magnitude == 0.0)
				return target;
			return current + vector2 * magnitude / maxDistanceDelta;
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
	}
}

