using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_14_Lerp : MonoBehaviour 
	{
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
		
		/*
		 * Q: Does it make sense to increase the range of _clampedTransition?
		 */
		[Header("Lerp")]
		[_CA_Color(_Color.White, order = 0)]
		[_CA_Range("Transition", 0, 1, order = 1)]
		[SerializeField]
		private float _clampedTransition;
		
		[Header("LerpUnclamped")]
		[_CA_Color(_Color.White, order = 0)]
		[_CA_Range("Transition", 0, 10, order = 1)]
		[SerializeField]
		private float _unclampedTransition;
		
		private GameObject _bullet;
		
		[Space]

		[SerializeField]
		private bool _unclamped;
		
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
		}
		
		// Update is called once per frame
		void Update ()
		{
			UpdatePositions();

			/*
			 * Q: Lerp means Linear Internationalization. True or false?
			 * 
			 * Q: What does Mathf.Clamp01 do? 
			 */
			if (_unclamped)
			{
				_bullet.transform.position = Vector2.LerpUnclamped(_player.transform.position, _enemy.transform.position, _unclampedTransition);
			}
			else
			{
				_bullet.transform.position = Vector2.Lerp(_player.transform.position, _enemy.transform.position, _clampedTransition);
			}
		}

		private void UpdatePositions()
		{
			_player.transform.position = new Vector2(_playerX, _playerY);
			_enemy.transform.position = new Vector2(_enemyX, _enemyY);
		}
	}
}

