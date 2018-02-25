using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_07_Subtraction : MonoBehaviour {
		
		private GameObject _player;
		
		[Header("Player")]
		[_CA_Color(_Color.Red, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _playerX;
		
		[_CA_Color(_Color.Green, order = 0)]
		[_CA_Range("Y", -50, 50, order = 1)]
		[SerializeField]
		private float _playerY;
		
		private GameObject _enemy;
		
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
		[_CA_ReadOnly]
		[SerializeField]
		private string _calculation;
		
		[_CA_ReadOnlyLabel("X")]
		[SerializeField]
		private string _calculationX;
		
		[_CA_ReadOnlyLabel("X")]
		[SerializeField]
		private string _calculationY;
	
		private float _x;
		private float _y;
		
		[Space]
		
		[_CA_ReadOnly]
		[SerializeField]
		private float _distance;
		
		[Space]
		
		[_CA_ReadOnly]
		[SerializeField]
		private string _youAreThe = "";
		
		public bool Reversed;
		
		
		private readonly Vector2 _zero = Vector2.zero;
		
		private void OnEnable()
		{
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
			_enemy = GameObject.FindWithTag(Constant.ENEMY_2D);
		}
	
		// Use this for initialization
		void Start () 
		{
			// https://www.geogebra.org/m/vUAFWvmk
		}
		
		// Update is called once per frame
		void Update () {
			_player.transform.position = new Vector2(_playerX, _playerY);
			_enemy.transform.position = new Vector2(_enemyX, _enemyY);
			Subtract();
			Draw();
			
			/*
			 * Vector2.Distance uses sqrMagnitude to calculate distance between two vectors. True or false?
			 */
			_distance = Vector2.Distance(_player.transform.position, _enemy.transform.position);
	
			_youAreThe = Reversed ? "Enemy" : "Player";
		}
	
		private void Subtract()
		{
			if (Reversed)
			{
				_x = _playerX - _enemyX;
				_y = _playerY - _enemyY;
	
				_calculation = "Player - Enemy";
				_calculationX = _playerX + " - (" + _enemyX + ") = " + _x;
				_calculationY = _playerY + " - (" + _enemyY + ") = " + _y;
			}
			else
			{
				_x = _enemyX - _playerX;
				_y = _enemyY - _playerY;
				
				_calculation = "Enemy - Player";	
				_calculationX = _enemyX + " - (" + _playerX + ") = " + _x;
				_calculationY = _enemyY + " - (" + _playerY + ") = " + _y;
			}
		}
	
		private void Draw()
		{
			Debug.DrawLine(_zero, _player.transform.position, Color.green);
			Debug.DrawLine(_zero, _enemy.transform.position, Color.red);
			Debug.DrawLine(_zero, new Vector2(_x, _y), Color.white);
	
			if (Reversed)
			{
				Debug.DrawLine(_enemy.transform.position, new Vector2(_enemyX, _enemyY) + new Vector2(_x, _y), Color.red);
				Debug.DrawLine(_enemy.transform.position, _enemy.transform.position + _player.transform.position, Color.green);
				Debug.DrawLine(_player.transform.position, _player.transform.position + _enemy.transform.position, Color.cyan);
			}
			else
			{
				Debug.DrawLine(_player.transform.position, new Vector2(_playerX, _playerY) + new Vector2(_x, _y), Color.green);
				Debug.DrawLine(_enemy.transform.position, _enemy.transform.position + _player.transform.position, Color.magenta);
				Debug.DrawLine(_player.transform.position, _player.transform.position + _enemy.transform.position, Color.red);
			}
		}
	}
}
