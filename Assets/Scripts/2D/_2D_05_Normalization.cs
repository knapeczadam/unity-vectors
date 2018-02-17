using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	[ExecuteInEditMode]
	public class _2D_05_Normalization : MonoBehaviour {
		
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
	
		[Header("Normalize")]
		[_CA_ReadOnlyLabel("X")]
		[SerializeField]
		private float _normalizedX;
		
		[_CA_ReadOnlyLabel("Y")]
		[SerializeField]
		private float _normalizedY;
		
		[_CA_ReadOnlyLabel("Magnitude")]
		[SerializeField]
		private float _normalizedMagnitude;
	
		private readonly Vector2 _zero = Vector2.zero;
	
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
		void Update () {
			_player.transform.position = new Vector2(_playerX, _playerY);
			
			/*
			 * Q: Difference between transform.position.normalized and transform.position.Normalize()?
			 */
			Normalize();
			
			/*
			 * Q: Zero vector can be normalized. True or false?
			 * 
			 * Q: Magnitude of a normalized vector is always between 0 and 1. True or false?
			 */
			_normalizedMagnitude = new Vector2(_normalizedX, _normalizedY).magnitude;
			
			Draw();
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
	
		private void Draw()
		{
			Debug.DrawLine(_zero, new Vector2(_playerX, _playerY), Color.cyan);
			Debug.DrawLine(_zero, _player.transform.position.normalized, Color.magenta);
		}
	}
}
