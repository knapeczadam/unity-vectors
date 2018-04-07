using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._3D
{
	[ExecuteInEditMode]
	public class _3D_04_SqrMagnitude : _3D_Base
	{
		[_CA_ReadOnlyLabel("Magnitude")]
		[SerializeField]
		private float _playerSqrMagnitude;
		
		// -----
		
		[Header("Enemy")]
		[_CA_Color(_Color.Red, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _enemyX;
		
		[_CA_Color(_Color.Green, order = 0)]
		[_CA_Range("Y", 0, 50, order = 1)]
		[SerializeField]
		private float _enemyY;
		
		[_CA_Color(0, 1, 255, order = 0)]
		[_CA_Range("Z", -50, 50, order = 1)]
		[SerializeField]
		private float _enemyZ;
		
		// -----
		
		[_CA_ReadOnlyLabel("Magnitude")]
		[SerializeField]
		private float _enemySqrMagnitude;
		
		[Header("Farther from zero")]
		[_CA_ReadOnlyLabel("")]
		[SerializeField]
		private string _text;
	
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
			
			CalculateSqrMagnitude();
			
			_text = _playerSqrMagnitude == _enemySqrMagnitude ? "Equal" :
				_playerSqrMagnitude > _enemySqrMagnitude ? "Player" : "Enemey";
		}
		
		private void CalculateSqrMagnitude()
		{
			_playerSqrMagnitude =  _playerX * _playerX + _playerY * +_playerY + _playerZ * _playerZ;
			_enemySqrMagnitude = _enemyX * _enemyX + _enemyY * _enemyY + _enemyZ * _enemyZ;
		}
	
		protected override void DebugLines()
		{
			Debug.DrawLine(new Vector3(0, 0, 1), new Vector3(_enemyPosition.magnitude, 0, 1), Color.red);
			Debug.DrawLine(new Vector3(0, 0, 2), new Vector3(_playerPosition.magnitude, 0, 2), Color.green);
		}
	}
}
