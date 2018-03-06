using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_03_Magnitude : MonoBehaviour 
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
		void Update () 
		{
			UpdatePlayerPosition();
			/*
			 * Q: What's the alternative of CalculateMagnitude()?
			 *
			 * Q: What does Vector2.Distance do?
			 */
			Magnitude = CalculateMagnitude();
		}
		
		private void LateUpdate()
		{
			DebugLines();
		}
		
		private float CalculateMagnitude()
		{
			// https://www.geogebra.org/m/wdQ5VRW9
			return Mathf.Sqrt(_playerX * _playerX + _playerY * _playerY);
		}
		
		private void UpdatePlayerPosition()
		{
			_playerPosition = new Vector2(_playerX, _playerY);
			_player.transform.position = _playerPosition;
		}
	
		private void DebugLines()
		{
			Debug.DrawLine(_zero, _playerPosition, Color.cyan);
			Debug.DrawLine(_zero, new Vector2(_playerX, 0), Color.red);
			Debug.DrawLine(new Vector2(_playerX, 0), _playerPosition, Color.green);
		}
	}
}
