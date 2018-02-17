using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_03_Magnitude : MonoBehaviour 
	{
		private GameObject _player;
		
		[Header("Player")]
		
		[_CA_Color(1, 0, 0, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _playerX;
		
		[_CA_Color(0, 1, 0, order = 0)]
		[_CA_Range("Y", -50, 50, order = 1)]
		[SerializeField]
		private float _playerY;
		
		[Space]
		
		[_CA_ReadOnly]
		public float Magnitude;
		
		private readonly Vector2 _zero = Vector2.zero;
	
		private void OnEnable()
		{
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
		}
	
		// Use this for initialization
		void Start () 
		{
			// https://www.geogebra.org/m/ChtswN6k
		}
		
		// Update is called once per frame
		void Update () {
			_player.transform.position = new Vector2(_playerX, _playerY);
			/*
			 * Q: What's the alternative of CalculateMagnitude()?
			 */
			Magnitude = CalculateMagnitude();
			
			Draw();
		}
		
		private float CalculateMagnitude()
		{
			/*
			 * Pythagorean theorem
			 * a * a + b * b = c * c
			 */
			return Mathf.Sqrt(_playerX * _playerX + _playerY * _playerY);
		}
	
		private void Draw()
		{
			Debug.DrawLine(_zero, new Vector2(_playerX, _playerY), Color.cyan);
			Debug.DrawLine(_zero, new Vector2(_playerX, 0), Color.red);
			Debug.DrawLine(new Vector2(_playerX, 0), new Vector2(_playerX, _playerY), Color.green);
		}
	}
}
