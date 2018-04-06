using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_10_Angle : _2D_Base 
	{
		[Space]
		
		[_CA_Color(_Color.Cyan, order = 0)]
		[_CA_Range("Degrees", 0, 359, order = 1)]
		[SerializeField]
		private int _playerDegrees;
		
		[_CA_Color(_Color.Magenta, order = 0)]
		[_CA_Range("*", 1, 10, order = 1)]
		[SerializeField]
		private int _playerK;
		
		// -----
		
		[Header("Enemy")] 
		[_CA_ReadOnlyLabel("Position")]
		[SerializeField]
		private new Vector2 _enemyPosition;
		
		[_CA_Color(_Color.Cyan, order = 0)]
		[_CA_Range("Degrees", 0, 359, order = 1)]
		[SerializeField]
		private int _enemyDegrees;
		
		[_CA_Color(_Color.Magenta, order = 0)]
		[_CA_Range("*", 1, 10, order = 1)]
		[SerializeField]
		private int _enemyK;
		
		[Space]
		
		[_CA_ReadOnly]
		[SerializeField]
		private float _angle;

		[Space] 
		
		[SerializeField]
		private bool _signed;
	
		private const float MaxDistanceFromZero = 10f;
	
		private void OnEnable()
		{
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
			_enemy = GameObject.FindWithTag(Constant.ENEMY_2D);

			_playerK = 1;
			_enemyK = 1;
		}
	
		// Use this for initialization
		void Start () 
		{
			// https://www.geogebra.org/m/gKZEUkXU
		}
		
		// Update is called once per frame
		void Update()
		{
			UpdatePlayerPosition();
			UpdateEnemyPosition();
			
			/*
			 * Q: _angle can be greater than 180 degrees. True or false?
			 *
			 * Q: 57.29578f is a magic number, can't be calculated. True or false?
			 *
			 * Q: Mathf.Sign returns the sign of f. True or false?
			 */
			if (_signed)
			{
				_angle = Vector2.SignedAngle(_playerPosition, _enemyPosition);
			}
			else
			{
				_angle = Vector2.Angle(_playerPosition, _enemyPosition);
			}
		}
		
		protected override void UpdatePlayerPosition()
		{
			_playerPosition = new Vector2(Mathf.Cos((_playerDegrees * Mathf.PI) / 180), Mathf.Sin((_playerDegrees * Mathf.PI) / 180)) * _playerK;
			_playerX = _playerPosition.x;
			_playerY = _playerPosition.y;
			_player.transform.position = _playerPosition;
		}

		private void UpdateEnemyPosition()
		{
			_enemyPosition = new Vector2(Mathf.Cos((_enemyDegrees * Mathf.PI) / 180), Mathf.Sin((_enemyDegrees * Mathf.PI) / 180)) * _enemyK;
			_enemy.transform.position = _enemyPosition;
		}
	
		protected override void DebugLines()
		{
			Debug.DrawLine(_zero, _playerPosition, Color.green);
			Debug.DrawLine(_zero, _enemyPosition, Color.red);
			Debug.DrawLine(_playerPosition.normalized, _enemyPosition.normalized, Color.cyan);
		}
	}
}
