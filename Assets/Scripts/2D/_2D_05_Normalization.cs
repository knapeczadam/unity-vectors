using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_05_Normalization : _2D_Base 
	{
		[Header("Normalized")]
		[_CA_ReadOnlyLabel("X")]
		[SerializeField]
		private float _normalizedX;
		
		[_CA_ReadOnlyLabel("Y")]
		[SerializeField]
		private float _normalizedY;
		
		[_CA_ReadOnlyLabel("Magnitude")]
		[SerializeField]
		private float _normalizedMagnitude;
	
		private void OnEnable()
		{
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
		}
	
		// Use this for initialization
		void Start () 
		{
			// https://www.geogebra.org/m/SknjCDt9
		}
		
		// Update is called once per frame
		void Update ()
		{
			UpdatePlayerPosition();
			
			/*
			 * Q: Difference between transform.position.normalized and transform.position.Normalize()?
			 *
			 * Q: 9.99999974737875E-06 is greater than 0.000001. True or false?
			 *
			 * Q: 9.99999974737875E-06: Where does this number come from?
			 */
			Normalize();
			
			/*
			 * Q: Zero vector can be normalized. True or false?
			 * 
			 * Q: Magnitude of a normalized vector is always between 0 and 1. True or false?
			 */
			_normalizedMagnitude = new Vector2(_normalizedX, _normalizedY).magnitude;
		}
	
		private void Normalize()
		{
			/*
			 * Q: When do we use a normalized vector?
			 */
			float length = _player.transform.position.magnitude;
			
			/*
			 * Q: Is everything ok with this division?
			 */
			_normalizedX = _playerX / length;
			_normalizedY = _playerY / length;
		}
	
		protected override void DebugLines()
		{
			Debug.DrawLine(_zero, _playerPosition, Color.green);
			Debug.DrawLine(_zero, _playerPosition.normalized, Color.magenta);
		}
	}
}
