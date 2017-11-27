using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class _2D_01_Position : MonoBehaviour
{

	[Header("Player")] 
	private GameObject _player;
	public float player_x;
	public float player_y;

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
		 * Q: Should I use Translate instead of position?
		 * _player.transform.Translate(new Vector3(player_x, 0, player_y));
		 *
		 * Q: What's the meaning of using Time.deltaTime?
		 * _player.transform.Translate(new Vector3(player_x, 0, player_y) * Time.deltaTime);
		 */
		_player.transform.position = new Vector3(player_x, 0, player_y);

	}
}
