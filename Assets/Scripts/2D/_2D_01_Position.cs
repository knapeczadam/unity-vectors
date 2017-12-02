using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class _2D_01_Position : MonoBehaviour
{

	private GameObject _player;
	
	[Header("Player")]
	public Vector2 PlayerPosition;
	public float PlayerX;
	public float PlayerY;

	private void OnEnable()
	{
		_player = GameObject.FindWithTag(Constant.PLAYER_2D);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		/*
		 * Q: Should I use Translate() instead of transform.position = PlayerPosition?
		 * _player.transform.Translate(PlayerPosition);
		 *
		 * Q: What is Time.deltaTime?
//		 * _player.transform.Translate(PlayerPosition * Time.deltaTime);
		 */	
		_player.transform.position = PlayerPosition;
//		_player.transform.position = CreatePosition1();
//		_player.transform.position = CreatePosition2();
//		_player.transform.position = CreatePosition3();

	}

	private Vector2 CreatePosition1()
	{
		Vector2 position = new Vector2(PlayerX, PlayerY);

		return position;
	}

	private Vector2 CreatePosition2()
	{
		Vector2 position = new Vector2();
		position.Set(PlayerX, PlayerY);

		return position;
	}

	private Vector2 CreatePosition3()
	{
		Vector2 position = new Vector2();
		position.x = PlayerX;
		position.y = PlayerY;

		return position;
	}
}
