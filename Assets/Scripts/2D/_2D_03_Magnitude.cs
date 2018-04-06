using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_03_Magnitude : _2D_Base 
	{
		[Space]
		
		[_CA_ReadOnly]
		public float Magnitude;
			
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
		
		private float CalculateMagnitude()
		{
			// https://www.geogebra.org/m/wdQ5VRW9
			return Mathf.Sqrt(_playerX * _playerX + _playerY * _playerY);
		}
		
		protected override void DebugLines()
		{
			Debug.DrawLine(_zero, _playerPosition, Color.cyan);
			Debug.DrawLine(_zero, new Vector2(_playerX, 0), Color.red);
			Debug.DrawLine(new Vector2(_playerX, 0), _playerPosition, Color.green);
		}
	}
}
