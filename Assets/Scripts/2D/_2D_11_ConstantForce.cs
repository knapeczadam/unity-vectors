using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	public class _2D_11_ConstantForce : MonoBehaviour 
	{
		private GameObject _player;
		
		[Header("Player")] 
		[_CA_ReadOnlyLabel("Position")]
		[SerializeField]
		private Vector2 _playerPosition;

		private ConstantForce2D _constantForce;
		
		[_CA_ReadOnly]
		[SerializeField]
		private Vector2 _force;
		
		private int _counter = 1;
		private float _timer;
		
		// Use this for initialization
		void Start () 
		{
			/*
			 * Q: Every object in your game is a GameObject, from characters and collectible items to lights, cameras and special effects. True or false?
			 */
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
			/*
			 * Q: What are components in Unity?
			 *
			 * Q: Constant Force 2D is a quick utility for adding constant forces to a Rigidbody. True or false?
			 *
			 * Q: Can you remove Rigidbody 2D component if Constant Force 2D is in use?
			 */
			_constantForce = _player.GetComponent<ConstantForce2D>();
		}
		
		// Update is called once per frame
		void FixedUpdate ()
		{
			_timer += Time.deltaTime;
			
			_playerPosition = _player.transform.position;
			_force = _constantForce.force;

			Draw();
		}

		private void Draw()
		{
			Debug.DrawLine(Vector2.zero, _force, Color.cyan);
		}
		
		void OnGUI()
		{
			string minutes = Mathf.Floor(_timer / 60).ToString("00");
			string seconds = Mathf.Floor(_timer % 60).ToString("00");
    
			GUI.Label(new Rect(10, 10, 250, 100), minutes + ":" + seconds);
		}
	}
}

