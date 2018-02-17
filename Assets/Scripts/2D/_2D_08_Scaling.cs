using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_08_Scaling : MonoBehaviour 
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
		 * Q: What is scalar in mathematics?
		 *
		 * I: The word scalar derives from the Latin word scalaris, an adjectival form of scala (Latin for "ladder").
		 *
		 * Q: Vectors have magnitude and direction, scalars only have _.
		 */
		[_CA_Range("*", -10, 10, order = 0)]
		[SerializeField]
		private float _k;
		
		
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
			/*
			 * Q: What is scalar multiplication?
			 * 
			 * Q: When you multiply a vector by a scalar, the result is a scalar. True or false?
			 */
			_clonePosition = new Vector2(_playerX * _k, _playerY * _k);

			return _clonePosition;
		}
		
		private void Draw()
		{
			/*
			 * Q: What is a Vector Space?
			 */
			if (_k < 1)
			{
				Debug.DrawLine(_zero, new Vector2(_playerPosition.x, _playerPosition.y), Color.green);
				Debug.DrawLine(_zero, new Vector2(_playerPosition.x * _k, _playerPosition.y * _k), Color.magenta);
			}
			else
			{
				Debug.DrawLine(_zero, new Vector2(_playerPosition.x * _k, _playerPosition.y * _k), Color.magenta);
				Debug.DrawLine(_zero, new Vector2(_playerPosition.x, _playerPosition.y), Color.green);
			}
		}
	}
}
