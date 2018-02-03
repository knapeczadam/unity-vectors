using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class _2D_01_Position : MonoBehaviour
{

	private GameObject _player;
	
	[Header("Player")]
	public Vector2 PlayerPosition;
	// Make these public to control them and uncomment the selected method to change player's position
	private float PlayerX;
	private float PlayerY;

	private readonly Vector2 _zero = Vector2.zero;

	private void OnEnable()
	{
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
		 * Q: 
		 */	
		_player.transform.position = PlayerPosition;
//		_player.transform.position = UpdatePositionV1();
//		_player.transform.position = UpdatePositionV2();
//		_player.transform.position = UpdatePositionV3();
		
		Draw();

	}

	private void Draw()
	{
		Debug.DrawLine(_zero, new Vector2(PlayerPosition.x, 0), Color.red);
		Debug.DrawLine(_zero, new Vector2(0, PlayerPosition.y), Color.green);
	}

	private Vector2 UpdatePositionV1()
	{
		Vector2 position = new Vector2(PlayerX, PlayerY);

		return position;
	}

	private Vector2 UpdatePositionV2()
	{
		Vector2 position = new Vector2();
		position.Set(PlayerX, PlayerY);

		return position;
	}

	private Vector2 UpdatePositionV3()
	{
		Vector2 position = new Vector2();
		position.x = PlayerX;
		position.y = PlayerY;

		return position;
	}
}
