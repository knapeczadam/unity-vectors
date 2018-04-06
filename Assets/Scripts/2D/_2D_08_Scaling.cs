using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_08_Scaling : _2D_Base 
	{
		private GameObject _clone;
		
		[Space]
		
		[_CA_ReadOnly]
		[SerializeField]
		private Vector2 _clonePosition;
		
		/*
		 * Q: What is scalar in mathematics?
		 *
		 * I: The word scalar derives from the Latin word scalaris, an adjectival form of scala (Latin for "ladder").
		 *
		 * Q: Vectors have magnitude and direction, scalars only have _.
		 */
		[_CA_Color(_Color.Magenta, order = 0)]
		[_CA_Range("*", -10, 10, order = 1)]
		[SerializeField]
		private float _k;
		
		[Space]
		
		[_CA_Label("Vector2.Scale")]
		[SerializeField]
		private bool _useScaleFunction;
		
		[_CA_Color(_Color.Red, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _scaleX;

		[_CA_Color(_Color.Green, order = 0)]
		[_CA_Range("Y", -50, 50, order = 1)]
		[SerializeField]
		private float _scaleY;

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
			UpdatePlayerPosition();
			UpdateClonePosition();
		}

		private void UpdateClonePosition()
		{
			/*
			 * Q: What is scalar multiplication?
			 * 
			 * Q: When you multiply a vector by a scalar, the result is a scalar. True or false?
			 */
			if (_useScaleFunction)
			{
				_clonePosition = Vector2.Scale(new Vector2(_playerX, _playerY), new Vector2(_scaleX, _scaleY));
			}
			else
			{
				_clonePosition = new Vector2(_playerX, _playerY) * _k;
			}

			_clone.transform.position = _clonePosition;
		}
		
		protected override void DebugLines()
		{
			/*
			 * Q: What is a Vector Space?
			 */
			if (_useScaleFunction)
			{
				if (_scaleX == _scaleY && _scaleX < 1)
				{
					Debug.DrawLine(_zero, _playerPosition, Color.green);
					Debug.DrawLine(_zero, _clonePosition, Color.magenta);

				}
				else
				{
					Debug.DrawLine(_zero, _clonePosition, Color.magenta);
					Debug.DrawLine(_zero, _playerPosition, Color.green);
				}
			}
			else
			{
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
}
