using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class _2D_04_Add : MonoBehaviour {
	
	private GameObject _player;
	
	[Header("Player")]
	public float PlayerX;
	public float PlayerY;

	[Header("Light side")] 
	public float LightX;
	public float LightY;

	[Header("Dark side")] 
	public float DarkX;
	public float DarkY;
	
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
		Add();
		_player.transform.position = new Vector2(PlayerX,PlayerY);
		Draw();
	}

	private void Add()
	{
		/*
		 * Q: What is operator overloading in C#?
		 *
		 * Q: Is vector addition commutative?
		 */
		PlayerX = LightX + DarkX;
		PlayerY = LightY + DarkY;
	}
	
	private void Draw()
	{
		Debug.DrawLine(_zero, new Vector2(LightX, LightY), Color.green);
		Debug.DrawLine(new Vector2(LightX, LightY), new Vector2(PlayerX, PlayerY), Color.white);
		Debug.DrawLine(_zero, new Vector2(DarkX, DarkY), Color.red);
		Debug.DrawLine(new Vector2(DarkX, DarkY), new Vector2(PlayerX, PlayerY), Color.white);
		Debug.DrawLine(_zero, new Vector2(PlayerX, PlayerY), Color.cyan);
	}
}
