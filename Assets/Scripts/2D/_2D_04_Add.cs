using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class _2D_04_Add : MonoBehaviour {
	
	private GameObject _player;
	
	[Header("Player")]
	public float player_x;
	public float player_y;

	[Header("Light side")] 
	public float light_x;
	public float light_y;

	[Header("Dark side")] 
	public float dark_x;
	public float dark_y;
	
	private Vector3 _zero = Vector3.zero;
	
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
		_player.transform.position = new Vector3(player_x, 0, player_y);
		Draw();
	}

	private void Add()
	{
		/*
		 * Q: What is operator overloading in C#?
		 *
		 * Q: Is vector addition commutative?
		 */
		player_x = light_x + dark_x;
		player_y = light_y + dark_y;
	}
	
	private void Draw()
	{
		Debug.DrawLine(_zero, new Vector3(light_x, 0, light_y), Color.green);
		Debug.DrawLine(_zero, new Vector3(dark_x, 0, dark_y), Color.red);
		Debug.DrawLine(_zero, new Vector3(player_x, 0, player_y), Color.cyan);
	}
}
