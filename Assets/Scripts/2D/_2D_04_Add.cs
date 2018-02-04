using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_04_Add : MonoBehaviour {
		
		private GameObject _player;
		
		[Header("Player")]
		[_CA_ReadOnlyLabel("X")]
		[SerializeField]
		private float _playerX;
		
		[_CA_ReadOnlyLabel("Y")]
		[SerializeField]
		private float _playerY;
	
		[Header("Light side")]
		[_CA_Color(1, 0, 0, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _lightX;
		
		[_CA_Color(0, 1, 0, order = 0)]
		[_CA_Range("Y", -50, 50, order = 1)]
		[SerializeField]
		private float _lightY;
	
		[Header("Dark side")]
		[_CA_Color(1, 0, 0, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _darkX;
		
		[_CA_Color(0, 1, 0, order = 0)]
		[_CA_Range("Y", -50, 50, order = 1)]
		[SerializeField]
		private float _darkY;
		
		private readonly Vector2 _zero = Vector2.zero;
		
		private void OnEnable()
		{
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
		}
	
		// Use this for initialization
		void Start () 
		{
			// https://www.geogebra.org/m/ty53wFpP
		}
		
		// Update is called once per frame
		void Update () {
			Add();
			_player.transform.position = new Vector2(_playerX,_playerY);
			Draw();
		}
	
		private void Add()
		{
			/*
			 * Q: What is operator overloading in C#?
			 *
			 * Q: Is vector addition commutative?
			 */
			_playerX = _lightX + _darkX;
			_playerY = _lightY + _darkY;
		}
		
		private void Draw()
		{
			Debug.DrawLine(_zero, new Vector2(_lightX, _lightY), Color.green);
			Debug.DrawLine(new Vector2(_lightX, _lightY), new Vector2(_playerX, _playerY), Color.red);
			Debug.DrawLine(_zero, new Vector2(_darkX, _darkY), Color.red);
			Debug.DrawLine(new Vector2(_darkX, _darkY), new Vector2(_playerX, _playerY), Color.green);
			Debug.DrawLine(_zero, new Vector2(_playerX, _playerY), Color.cyan);
		}
	}
}
