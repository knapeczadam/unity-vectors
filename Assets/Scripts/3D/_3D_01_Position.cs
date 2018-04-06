using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._3D
{
    [ExecuteInEditMode]
    public class _3D_01_Position : _3D_Base
    {
        [_CA_ReadOnly]
		[SerializeField]
		private Vector3 _globalPosition;
		
		private GameObject _parent;
		
		[Header("Parent")]
		[_CA_Color(_Color.Red, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _parentX;
	
		[_CA_Color(_Color.Green, order = 0)]
		[_CA_Range("Y", 0, 50, order = 1)]
		[SerializeField]
		private float _parentY;
	    
	    [_CA_Color(0, 1, 255, order = 0)]
	    [_CA_Range("Z", -50, 50, order = 1)]
	    [SerializeField]
	    private float _parentZ;

		[Space] 
		
		[SerializeField]
		private bool _local;
	
		private void OnEnable()
		{
			_parent = GameObject.FindWithTag(Constant.PARENT);
			_player = GameObject.FindWithTag(Constant.PLAYER_3D);
		}
	
		// Use this for initialization
		void Start () 
		{
			
		}
		
		// Update is called once per frame
		void Update ()
		{
			if (_local)
			{
				_player.transform.localPosition = UpdatePlayerPositionV1();
			}
			else
			{
				_player.transform.position = UpdatePlayerPositionV2();
			}
			_globalPosition = _player.transform.position;
			
			UpdateParentPosition();
		}
	
		protected override void DebugLines()
		{
			if (_local)
			{
				Debug.DrawLine(new Vector3(_parentX, _parentY, _parentZ), new Vector3(_parentX + _playerX, _parentY, _parentZ), Color.red);
				Debug.DrawLine(new Vector3(_parentX, _parentY, _parentZ), new Vector3(_parentX, _parentY + _playerY, _parentZ), Color.green);
				Debug.DrawLine(new Vector3(_parentX, _parentY, _parentZ), new Vector3(_parentX, _parentY, _parentZ + _playerZ), Color.blue);
			}
			else
			{
				Debug.DrawLine(_zero, new Vector3(_playerX, 0, 0), Color.red);
				Debug.DrawLine(_zero, new Vector3(0, _playerY, 0), Color.green);
				Debug.DrawLine(_zero, new Vector3(0, 0, _playerZ), Color.blue);
			}
		}
	
		private Vector3 UpdatePlayerPositionV1()
		{
			Vector3 position = new Vector3(_playerX, _playerY, _playerZ);
	
			return position;
		}
	
		private Vector3 UpdatePlayerPositionV2()
		{
			Vector3 position = new Vector3();
			position.Set(_playerX, _playerY, _playerZ);
	
			return position;
		}
	
		private Vector3 UpdatePlayerPositionV3()
		{
			Vector3 position = new Vector3();
			position.x = _playerX;
			position.y = _playerY;
			position.z = _playerZ;
	
			return position;
		}

		private void UpdateParentPosition()
		{
			_parent.transform.position = new Vector3(_parentX, _parentY, _parentZ);
		}
    }
}
