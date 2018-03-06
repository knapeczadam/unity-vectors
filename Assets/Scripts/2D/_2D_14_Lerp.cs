using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_14_Lerp : MonoBehaviour 
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
		
		/*
		 * Q: Does it make sense to increase the range of _clampedTransition?
		 */
		[Header("Vector2.Lerp")]
		[_CA_Color(_Color.White, order = 0)]
		[_CA_Range("Transition", 0, 1, order = 1)]
		[SerializeField]
		private float _clampedTransition;
		
		[Space]
		
		[_CA_Label("Vector2.LerpUnclamped")]
		[SerializeField]
		private bool _useUnclampedFunction;
		
		[_CA_Color(_Color.White, order = 0)]
		[_CA_Range("Transition", 0, 10, order = 1)]
		[SerializeField]
		private float _unclampedTransition;
		
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
			// https://www.geogebra.org/m/sCyREjum
			// http://www.blueraja.com/blog/404/how-to-use-unity-3ds-linear-interpolation-vector3-lerp-correctly
			// http://theantranch.com/blog/using-lerp-properly/
		}
		
		// Update is called once per frame
		void Update ()
		{
			UpdatePlayerPosition();
			UpdateEnemyPosition();

			/*
			 * Q: Lerp means Linear Internationalization. True or false?
			 * 
			 * Q: What does Mathf.Clamp01 do? 
			 */
			if (_useUnclampedFunction)
			{
				_bullet.transform.position = Vector2.LerpUnclamped(_player.transform.position, _enemy.transform.position, _unclampedTransition);
			}
			else
			{
				_bullet.transform.position = Vector2.Lerp(_player.transform.position, _enemy.transform.position, _clampedTransition);
			}
			
			DrawingHelper.DrawPoint(_bullet.transform.position, Color.white);
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

