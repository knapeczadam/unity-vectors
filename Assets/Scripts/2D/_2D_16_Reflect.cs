using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_16_Reflect : MonoBehaviour 
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
		
		[Space]
		
		[_CA_Color(_Color.Cyan, order = 0)]
		[_CA_Range(0, 359, order = 1)]
		[SerializeField]
		private int _degrees;
		
		[Header("Plane")]	
		[_CA_Color(_Color.White, order = 0)]
		[_CA_Range("*", 1, 50, order = 1)]
		[SerializeField]
		private float _k = 1;

		private Vector2 _inNormal;
		private Vector2 _inDirection;
		
		private GameObject _enemy;
		
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
			UpdatePosition();
			
			_inNormal = _player.transform.position;
			_inDirection = new Vector2(Mathf.Cos((_degrees * Mathf.PI) / 180), Mathf.Sin((_degrees * Mathf.PI) / 180));
			
			_enemy.transform.position = Vector2.Reflect(_inNormal, _inDirection);

			Draw();
		}

		private void UpdatePosition()
		{
			_player.transform.position = new Vector2(_playerX, _playerY);
			
		}

		private void Draw()
		{
			Debug.DrawLine(Vector2.zero, _inDirection, Color.cyan);
			Vector2 plane = new Vector2(_inDirection.y, -_inDirection.x);
			Debug.DrawLine(-plane * _k, plane * _k, Color.white);
		}
	}
}
