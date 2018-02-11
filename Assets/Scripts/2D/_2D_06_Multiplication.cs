using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_06_Multiplication : MonoBehaviour 
	{
		private GameObject _player;
		
		[_CA_ReadOnly]
		[SerializeField]
		private Vector2 _playerPosition;
		
		private GameObject _clone;

		[_CA_ReadOnly]
		[SerializeField]
		private Vector2 _clonePosition;
		
		[Space]
		
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
		
		/*
		 * Q: What is scalar?
		 */
		[_CA_Range("*", -10, 10, order = 0)]
		[SerializeField]
		private float _multiple;
		
		
		private readonly Vector2 _zero = Vector2.zero;

		private void OnEnable()
		{
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);

			DestroyClones();
			
			/*
			 * Q: Difference between shallow copy and deep copy?
			 */
			_clone = Instantiate(_player);
			_clone.tag = Constant.CLONE;
		}

		private void DestroyClones()
		{
			var clones = GameObject.FindGameObjectsWithTag (Constant.CLONE);
			foreach (var clone in clones)
			{		
				/*
				 * Q: Difference between Destroy and DestroyImmediate?
				 */
				DestroyImmediate(clone);
			}
		}


		// Use this for initialization 
		void Start () 
		{
			// https://www.geogebra.org/m/kkGXzvSK
		}
		
		// Update is called once per frame
		void Update () 
		{
			_player.transform.position = UpdatePlayerPosition();
			_clone.transform.position = UpdateClonePosition();

			Draw();
		}
		
		private Vector2 UpdatePlayerPosition()
		{
			_playerPosition = new Vector2(_playerX, _playerY);
	
			return _playerPosition;
		}

		private Vector2 UpdateClonePosition()
		{
			_clonePosition = new Vector2(_playerX * _multiple, _playerY * _multiple);

			return _clonePosition;
		}
		
		private void Draw()
		{
			Debug.DrawLine(_zero, new Vector2(_playerPosition.x * _multiple, _playerPosition.y * _multiple), Color.magenta);
			Debug.DrawLine(_zero, new Vector2(_playerPosition.x, _playerPosition.y), Color.green);
		}
	}
}
