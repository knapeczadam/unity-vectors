using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._3D
{
	[ExecuteInEditMode]
	public class _3D_05_Normalization : _3D_Base 
	{
		[Header("Normalized")]
		[_CA_ReadOnlyLabel("X")]
		[SerializeField]
		private float _normalizedX;
		
		[_CA_ReadOnlyLabel("Y")]
		[SerializeField]
		private float _normalizedY;
		
		[_CA_ReadOnlyLabel("Z")]
		[SerializeField]
		private float _normalizedZ;
		
		[_CA_ReadOnlyLabel("Magnitude")]
		[SerializeField]
		private float _normalizedMagnitude;
	
		private void OnEnable()
		{
			_player = GameObject.FindWithTag(Constant.PLAYER_3D);
		}
	
		// Use this for initialization
		void Start () 
		{
			
		}
		
		// Update is called once per frame
		void Update ()
		{
			UpdatePlayerPosition();
			
			Normalize();
			
			_normalizedMagnitude = new Vector3(_normalizedX, _normalizedY, _normalizedZ).magnitude;
		}
	
		private void Normalize()
		{
			float length = _player.transform.position.magnitude;
			
			_normalizedX = _playerX / length;
			_normalizedY = _playerY / length;
			_normalizedZ = _playerZ / length;
		}
	
		protected override void DebugLines()
		{
			Debug.DrawLine(_zero, _playerPosition, Color.green);
			Debug.DrawLine(_zero, _playerPosition.normalized, Color.magenta);
		}
	}
}
