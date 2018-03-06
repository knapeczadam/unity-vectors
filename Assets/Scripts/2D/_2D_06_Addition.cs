using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_06_Addition : MonoBehaviour 
	{
		private GameObject _player;
		private Vector2 _playerPosition;
		
		[Header("Player")]
		[_CA_ReadOnlyLabel("X")]
		[SerializeField]
		private float _playerX;
		
		[_CA_ReadOnlyLabel("Y")]
		[SerializeField]
		private float _playerY;
		
		// -----

		private Vector2 _lightSide;
	
		[Header("Light side")]
		[_CA_Color(_Color.Red, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _lightX;
		
		[_CA_Color(_Color.Green, order = 0)]
		[_CA_Range("Y", -50, 50, order = 1)]
		[SerializeField]
		private float _lightY;
		
		// -----

		private Vector2 _darkSide;
	
		[Header("Dark side")]
		[_CA_Color(_Color.Red, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _darkX;
		
		[_CA_Color(_Color.Green, order = 0)]
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
		void Update () 
		{
			_lightSide = new Vector2(_lightX, _lightY);
			_darkSide = new Vector2(_darkX, _darkY);
			
			/*
			 * Q: What is Vector algebra?
			 */
			Add();
			
			UpdatePlayerPosition();
		}
		
		private void LateUpdate()
		{
			DebugLines();
		}
	
		private void Add()
		{
			/*
			 * Q: What is operator overloading in C#?
			 *
			 * Q: Is vector addition commutative?
			 *
			 * Q: What is the Head to Tail || Tip to Tail || Tail to Tip method?
			 *
			 * Q: What is the Parallelogram Method?
			 */
			_playerX = (_lightSide + _darkSide).x;
			_playerY = (_lightSide + _darkSide).y;
		}
		
		private void UpdatePlayerPosition()
		{
			_playerPosition = new Vector2(_playerX, _playerY);
			_player.transform.position = _playerPosition;
		}
		
		private void DebugLines()
		{
			/*
			 * Q: Difference between Debug.DrawLine and Debug.DrawRay?
			 */
			Debug.DrawLine(_zero, new Vector2(_lightX, _lightY), Color.green);
			Debug.DrawLine(new Vector2(_lightX, _lightY), _playerPosition, Color.red);
			Debug.DrawLine(_zero, new Vector2(_darkX, _darkY), Color.red);
			Debug.DrawLine(new Vector2(_darkX, _darkY), _playerPosition, Color.green);
			Debug.DrawLine(_zero, _playerPosition, Color.cyan);
		}
	}
}
