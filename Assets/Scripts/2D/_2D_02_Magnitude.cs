using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class _2D_02_Magnitude : MonoBehaviour {
	
	private GameObject _player;
	
	[Header("Player")]
	public float PlayerX;
	public float PlayerY;
	public float Magnitude;
	
	private readonly Vector2 _zero = Vector2.zero;

	private void OnEnable()
	{
		_player = GameObject.FindWithTag(Constant.PLAYER_2D);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_player.transform.position = new Vector2(PlayerX, PlayerY);
		/*
		 * Q: What's the alternative of CalculateMagnitude()?
		 */
		Magnitude = CalculateMagnitude();
		
		Draw();
	}
	
	private float CalculateMagnitude()
	{
		/*
		 * Pythagorean theorem
		 * a * a + b * b = c * c
		 */
		return Mathf.Sqrt(PlayerX * PlayerX + PlayerY * PlayerY);
	}

	private void Draw()
	{
		Debug.DrawLine(_zero, new Vector2(PlayerX, PlayerY), Color.cyan);
		Debug.DrawLine(_zero, new Vector2(PlayerX, 0), Color.red);
		Debug.DrawLine(new Vector2(PlayerX, 0), new Vector2(PlayerX, PlayerY), Color.green);
	}
}
