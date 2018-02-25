using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors._2D
{
	public class _2D_13_Velocity : MonoBehaviour {
		
		private GameObject _player;
		private Rigidbody2D _rigidbody;
	
		[Header("Player")] 
		[_CA_ReadOnlyLabel("Position")]
		[SerializeField]
		private Vector2 _playerPosition;
		
		[Header("Velocity")]
		[_CA_Color(_Color.Red, order = 0)]
		[_CA_Range("X", -50, 50, order = 1)]
		[SerializeField]
		private float _velocityX;
		
		[_CA_Color(_Color.Green, order = 0)]
		[_CA_Range("Y", -50, 50, order = 1)]
		[SerializeField]
		private float _velocityY;
	
		private Vector3 _velocity;

		[Space] 
		
		[SerializeField]
		private bool _limit;
		
		/*
		 * Q: What will happen?
		 *  1. Set min value (_CA_Range) to -50.
		 *  2. Enable limit.
		 *  3. Set velocity x to 3 and velocity y to 4.
		 *  4. Change max speed to -4.9.
		 *  5. Use UpdateVelocityV3.
		 */
		[_CA_Range(0, 50, order = 1)]
		[SerializeField]
		private float _maxSpeed;
		
		private float _timer;
	
		// Use this for initialization
		void Start () 
		{
			// https://www.geogebra.org/m/ttYkgBjA
			
			_player = GameObject.FindWithTag(Constant.PLAYER_2D);
			_rigidbody = _player.GetComponent<Rigidbody2D>();
			_maxSpeed = 1;
		}
		
		// Update is called once per frame
		void FixedUpdate ()
		{
			/*
			 * Q: Default value of Fixed Timestep is 0.025. True or false?
			 *
			 * Q: Value of Time.deltaTime and value of Time.fixedDeltaTime are different in FixedUpdate(). True or false?
			 *
			 * Q:  The Time Manager (menu: Edit > Preferences... > Time Manager) lets you set a number of properties that control timing within your game. True or false?
			 */
			_timer += Time.deltaTime;
			Debug.Log(_timer);
	
			_velocity = new Vector2(_velocityX, _velocityY);
			
			/*
			 * Q: What's wrong with this function? Fix it without using Time.fixedDeltaTime!
			 */
			UpdateVelocityV1();
			
			_playerPosition = _player.transform.position;
	
			Draw();
		}
		
		private void UpdateVelocityV1()
		{
			_player.transform.position += _velocity;
		}

		private void UpdateVelocityV2()
		{
			_player.transform.position += _velocity * Time.fixedTime;
		}
		
		private void UpdateVelocityV3()
		{
			// https://docs.unity3d.com/ScriptReference/Rigidbody2D-velocity.html
			// https://docs.unity3d.com/ScriptReference/Rigidbody-velocity.html
			if (_limit)
			{
				_rigidbody.velocity = Vector2.ClampMagnitude(_velocity, _maxSpeed);
			}
			else
			{
				_rigidbody.velocity = _velocity;
			}
		}
	
		private void Draw()
		{
			Debug.DrawLine(Vector3.zero, _velocity, Color.cyan);
		}
		
		// https://answers.unity.com/questions/45676/making-a-timer-0000-minutes-and-seconds.html
		void OnGUI()
		{
			string minutes = Mathf.Floor(_timer / 60).ToString("00");
			string seconds = Mathf.Floor(_timer % 60).ToString("00");
	
			GUI.Label(new Rect(10, 10, 250, 100), minutes + ":" + seconds);
		}
	}
}
