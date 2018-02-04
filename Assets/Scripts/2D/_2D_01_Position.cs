using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_01_Position : MonoBehaviour
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
	
		private readonly Vector2 _zero = Vector2.zero;
	
		private void OnEnable()
		{
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
		}
	
		// Use this for initialization
		void Start () 
		{
			// https://www.geogebra.org/m/sbT86GQW
		}
		
		// Update is called once per frame
		void Update ()
		{
			/*
			 * Q: 
			 */	
			
			_player.transform.position = UpdatePositionV1();
	//		_player.transform.position = UpdatePositionV2();
	//		_player.transform.position = UpdatePositionV3();
			
			Draw();
		}
	
		private void Draw()
		{
			Debug.DrawLine(_zero, new Vector2(_playerPosition.x, 0), Color.red);
			Debug.DrawLine(_zero, new Vector2(0, _playerPosition.y), Color.green);
		}
	
		private Vector2 UpdatePositionV1()
		{
			_playerPosition = new Vector2(_playerX, _playerY);
	
			return _playerPosition;
		}
	
		private Vector2 UpdatePositionV2()
		{
			Vector2 position = new Vector2();
			position.Set(_playerX, _playerY);
	
			return position;
		}
	
		private Vector2 UpdatePositionV3()
		{
			Vector2 position = new Vector2();
			position.x = _playerX;
			position.y = _playerY;
	
			return position;
		}
	}
}
