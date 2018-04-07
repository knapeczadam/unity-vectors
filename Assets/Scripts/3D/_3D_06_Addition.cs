using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._3D
{
	[ExecuteInEditMode]
	public class _3D_06_Addition : _3D_Base 
	{
		private Vector3 _lightSide;
	
		[Header("Light side")]
		[_CA_Color(_Color.Red, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _lightX;
		
		[_CA_Color(_Color.Green, order = 0)]
		[_CA_Range("Y", 0, 50, order = 1)]
		[SerializeField]
		private float _lightY;
		
		[_CA_Color(0, 1, 255, order = 0)]
		[_CA_Range("Z", -50, 50, order = 1)]
		[SerializeField]
		private float _lightZ;
		
		// -----

		private Vector3 _darkSide;
	
		[Header("Dark side")]
		[_CA_Color(_Color.Red, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _darkX;
		
		[_CA_Color(_Color.Green, order = 0)]
		[_CA_Range("Y", 0, 50, order = 1)]
		[SerializeField]
		private float _darkY;
		
		[_CA_Color(0, 1, 255, order = 0)]
		[_CA_Range("Z", -50, 50, order = 1)]
		[SerializeField]
		private float _darkZ;
		
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
			_lightSide = new Vector3(_lightX, _lightY, _lightZ);
			_darkSide = new Vector3(_darkX, _darkY, _darkZ);
			
			Add();
			
			UpdatePlayerPosition();
		}
	
		private void Add()
		{
			_playerX = (_lightSide + _darkSide).x;
			_playerY = (_lightSide + _darkSide).y;
			_playerZ = (_lightSide + _darkSide).z;
		}
		
		protected override void DebugLines()
		{
			Debug.DrawLine(_zero, new Vector3(_lightX, _lightY, _lightZ), Color.green);
			Debug.DrawLine(new Vector3(_lightX, _lightY, _lightZ), _playerPosition, Color.red);
			Debug.DrawLine(_zero, new Vector3(_darkX, _darkY, _darkZ), Color.red);
			Debug.DrawLine(new Vector3(_darkX, _darkY, _darkZ), _playerPosition, Color.green);
			Debug.DrawLine(_zero, _playerPosition, Color.cyan);
		}
	}
}
