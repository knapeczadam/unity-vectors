using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_01_Position : MonoBehaviour
	{
		private GameObject _parent;
		
		[Header("Parent")]
		
		[_CA_Color(1, 0, 0, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _parentX;
	
		[_CA_Color(0, 1, 0, order = 0)]
		[_CA_Range("Y", -50, 50, order = 1)]
		[SerializeField]
		private float _parentY;

		[Space]
		
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
		
		[SerializeField]
		private bool _local;
		
		// -----
		
		/*
		 * 
		 * Poor enemy can't move. Can you help him to control his movement?  
		 * 
		 */
	
		private readonly Vector2 _zero = Vector2.zero;
	
		private void OnEnable()
		{
			_parent = GameObject.FindWithTag(Constant.PARENT);
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
		}
	
		// Use this for initialization
		void Start () 
		{
			// https://www.geogebra.org/m/sbT86GQW
		}
		
		// Update is called once per frame
		void Update ()
		{
			/*
			 * Q: Every object in a scene has a Transform. True or false?
			 *
			 * Q: Every Transform can have multiple parents, which allows you to apply position and rotation. True or false?
			 */

			if (_local)
			{
				/*
				 * Q: If the transform has no parent, it is the same as Transform.position. True or false?
				 */
				_player.transform.localPosition = UpdatePlayerPositionV1();
			}
			else
			{
				_player.transform.position = UpdatePlayerPositionV2();
			}

			UpdateParentPosition();
			
			Draw();
		}
	
		private void Draw()
		{
			if (_local)
			{
				Debug.DrawLine(new Vector2(_parentX, _parentY), new Vector2(_parentX + _playerX, _parentY), Color.red);
				Debug.DrawLine(new Vector2(_parentX, _parentY), new Vector2(_parentX, _parentY + _playerY), Color.green);
			}
			else
			{
				Debug.DrawLine(_zero, new Vector2(_playerX, 0), Color.red);
				Debug.DrawLine(_zero, new Vector2(0, _playerY), Color.green);
			}
		}
	
		private Vector2 UpdatePlayerPositionV1()
		{
			/*
			 * Q: If the coordinates represent spatial positions (displacements), it is common to represent the vector from the origin to the point of interest as _.
			 *
			 * Q: In two dimensions, the vector from the origin to the point with Cartesian coordinates (x, y) can be written as _ = _ + _ where
			 * _ = (), and _ = () are _ vectors in the direction of the x-axis and y-axis respectively.
			 */
			Vector2 position = new Vector2(_playerX, _playerY);
	
			return position;
		}
	
		private Vector2 UpdatePlayerPositionV2()
		{
			/*
			 * I: The coordinate axes x and y are themselves vectors! They have a magnitude and a direction.
			 */
			Vector2 position = new Vector2();
			position.Set(_playerX, _playerY);
	
			return position;
		}
	
		private Vector2 UpdatePlayerPositionV3()
		{
			/*
			 * Q: A vector component is a scalar quantity. True or false?
			 * 
			 * Q: In a two-dimensional coordinate system, any vector can be broken into _-component and _-component.
			 */
			Vector2 position = new Vector2();
			position.x = _playerX;
			position.y = _playerY;
	
			return position;
		}

		private void UpdateParentPosition()
		{
			_parent.transform.position = new Vector2(_parentX, _parentY);
		}
	}
}
