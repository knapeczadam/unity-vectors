using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_10_Angle : MonoBehaviour {
		
		private GameObject _player;
		private Vector2 _playerPosition;
		
		[Header("Player")] 
		[_CA_Color(_Color.Red, order = 0)]
		[_CA_Range("X", -10, 10, order = 1)]
		[SerializeField]
		private float _playerX;
		
		[_CA_Color(_Color.Green, order = 0)]
		[_CA_Range("Y", -10, 10, order = 1)]
		[SerializeField]
		private float _playerY;
		
		// -----
		
		private GameObject _enemy;
		private Vector2 _enemyPosition;
		
		[Header("Enemy")]
		[_CA_Color(_Color.Red, order = 0)]
		[_CA_Range("X", -10, 10, order = 1)]
		[SerializeField]
		private float _enemyX;
		
		[_CA_Color(_Color.Green, order = 0)]
		[_CA_Range("Y", -10, 10, order = 1)]
		[SerializeField]
		private float _enemyY;
		
		private readonly Vector2 _zero = Vector2.zero;
		
		[Space]
		
		[_CA_ReadOnly]
		[SerializeField]
		private float _angle;
	
		private const float MaxDistanceFromZero = 10f;
	
		private void OnEnable()
		{
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
			_enemy = GameObject.FindWithTag(Constant.ENEMY_2D);
		}
	
		// Use this for initialization
		void Start () 
		{
			// https://www.geogebra.org/m/gKZEUkXU
		}
		
		// Update is called once per frame
		void Update()
		{
			UpdatePosition();
			
			if (_playerPosition.sqrMagnitude <= Mathf.Pow(MaxDistanceFromZero, 2))
			{
				_player.transform.position = _playerPosition;
			}
			if (_enemyPosition.sqrMagnitude <= Mathf.Pow(MaxDistanceFromZero, 2))
			{
				_enemy.transform.position = _enemyPosition;
			}
			/*
			 * Q: _angle can be greater than 180 degrees. True or false?
			 *
			 * Q: 57.29578f is a magic number, can't be calculated. True or false?
			 */
			_angle = Vector2.Angle(_player.transform.position, _enemy.transform.position);
			Draw();
		}
		
		private void UpdatePosition()
		{
			_playerPosition = new Vector2(_playerX, _playerY);
			_enemyPosition = new Vector2(_enemyX, _enemyY);
		}
	
		private void Draw()
		{
			Debug.DrawLine(_zero, _player.transform.position, Color.green);
			Debug.DrawLine(_zero, _enemy.transform.position, Color.red);
			Debug.DrawLine(_player.transform.position.normalized, _enemy.transform.position.normalized, Color.cyan);
		}
	}
}
