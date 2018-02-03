using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _2D_09_Velocity : MonoBehaviour {
	
	private GameObject _player;
	private Rigidbody _rigidbody;

	[Header("Player")] 
	[ReadOnly] 
	public Vector2 PlayerPosition;

	public Vector2 Velocity = Vector2.one;
	private Vector3 _velocity;
	
	private float _timer;
	
	private void OnEnable()
	{
		_player = GameObject.FindWithTag(Constant.PLAYER_2D);
		_rigidbody = _player.GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () 
	{
		// https://www.geogebra.org/m/Vp6p6Wyd
		// https://www.geogebra.org/m/ttYkgBjA
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

		_velocity = Velocity;
		
		/*
		 * Q: What's wrong with this function? Fix it without using Time.fixedDeltaTime!
		 */
		UpdateVelocityV3();
		
		PlayerPosition = _player.transform.position;

		Draw();
	}
	
	private void UpdateVelocityV1()
	{
		_player.transform.position += _velocity;
	}
	
	private void UpdateVelocityV2()
	{
		_player.transform.position += _velocity * Time.fixedDeltaTime;
	}

	private void UpdateVelocityV3()
	{
		_rigidbody.velocity = _velocity;
	}

	private void Draw()
	{
		Debug.DrawLine(Vector3.zero, Velocity, Color.cyan);
	}
	
	// https://answers.unity.com/questions/45676/making-a-timer-0000-minutes-and-seconds.html
	void OnGUI()
	{
		string minutes = Mathf.Floor(_timer / 60).ToString("00");
		string seconds = Mathf.Floor(_timer % 60).ToString("00");

		GUI.Label(new Rect(10, 10, 250, 100), minutes + ":" + seconds);
	}
}
