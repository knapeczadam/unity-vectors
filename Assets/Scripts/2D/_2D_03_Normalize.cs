using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class _2D_03_Normalize : MonoBehaviour {
	
	private GameObject _player;
	
	[Header("Player")]
	public float PlayerX;
	public float PlayerY;

	[Header("Normalize")]
	[ReadOnly]
	public float NormalizedX;
	[ReadOnly]
	public float NormalizedY;
	[ReadOnly]
	public float NormalizedMagnitude;

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
		_player.transform.position = new Vector2(PlayerX, PlayerY);
		
		/*
		 * Q: Difference between transform.position.normalized and transform.position.Normalize()?
		 */
		Normalize();
		
		/*
		 * Q: What is unit vector?
		 * 
		 * Q: Magnitude of a normalized vector is always between 0 and 1. True or false?
		 */
		NormalizedMagnitude = new Vector2(NormalizedX, NormalizedY).magnitude;
		
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
		NormalizedX = PlayerX / length;
		NormalizedY = PlayerY / length;
	}

	private void Draw()
	{
		Debug.DrawLine(_zero, new Vector2(PlayerX, PlayerY), Color.cyan);
		Debug.DrawLine(_zero, _player.transform.position.normalized, Color.magenta);
	}
}
