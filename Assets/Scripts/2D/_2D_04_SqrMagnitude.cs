using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_04_SqrMagnitude : MonoBehaviour
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
		
		[_CA_ReadOnlyLabel("Magnitude")]
		[SerializeField]
		private float _playerSqrMagnitude;
		
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
		
		[_CA_ReadOnlyLabel("Magnitude")]
		[SerializeField]
		private float _enemySqrMagnitude;
		
		[Header("Farther from zero")]
		[_CA_ReadOnlyLabel("")]
		[SerializeField]
		private string _text;
		
		private readonly Vector2 _zero = Vector2.zero;
	
		private void OnEnable()
		{
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
			_enemy = GameObject.FindWithTag(Constant.ENEMY_2D);
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
			 * Q: What's the alternative of CalculateSqrMagnitude()?
			 *
			 * Q: When do we use sqrMagnitude over magnitude?
			 */
			CalculateSqrMagnitude();
			
			_text = _playerSqrMagnitude == _enemySqrMagnitude ? "Equal" :
				_playerSqrMagnitude > _enemySqrMagnitude ? "Player" : "Enemey";
		}
		
		private void LateUpdate()
		{
			DebugLines();
		}
		
		private void CalculateSqrMagnitude()
		{
			_playerSqrMagnitude =  _playerPosition.x * _playerPosition.x + _playerPosition.y * _playerPosition.y;
			_enemySqrMagnitude = _enemyPosition.x * _enemyPosition.x + _enemyPosition.y * _enemyPosition.y;
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
			Debug.DrawLine(new Vector2(0, 1), new Vector2(_enemyPosition.magnitude, 1), Color.red);
			Debug.DrawLine(new Vector2(0, 2), new Vector2(_playerPosition.magnitude, 2), Color.green);
		}
	}
}
