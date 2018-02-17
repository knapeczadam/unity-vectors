using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_09_Dot : MonoBehaviour 
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
		
		[_CA_ReadOnly]
		[SerializeField]
		private float _dot;
		
		private readonly Vector2 _zero = Vector2.zero;
		
		private void OnEnable()
		{
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
			_enemy = GameObject.FindWithTag(Constant.ENEMY_2D);
		}
	
		// Use this for initialization
		void Start () 
		{
			// https://www.geogebra.org/m/N9pvSPf4
			// https://www.geogebra.org/m/Yu6869By
		}
		
		// Update is called once per frame
		void Update ()
		{
			UpdatePosition();
			/*
			 * Q: What's the formula of dot product?
			 *
			 * Q: How can you determine if two players are facing each other (using dot product)?
			 *
			 * Q: In order to check that two players are both aligned together you have to use the following method calling: Vector2.Dot(_player.transform.position.sqrMagnitude, _enemy.transform.position.sqrMagnitude). True or false?
			 *
			 * Q: If two players are perpendicular to each other the dot product is always _ ?
			 *
			 * Q: Why is vector division not possible?
			 */
			_dot = Vector2.Dot(_player.transform.position, _enemy.transform.position);
			Draw();
		}
		
		private void UpdatePosition()
		{
			_playerPosition = new Vector2(_playerX, _playerY);
			_player.transform.position = _playerPosition;
			
			_enemyPosition = new Vector2(_enemyX, _enemyY);
			_enemy.transform.position = _enemyPosition;
		}
		
		private void Draw()
		{
			Debug.DrawLine(_zero, _player.transform.position, Color.green);
			Debug.DrawLine(_zero, _enemy.transform.position, Color.red);
		}
	}
}
