using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class _2D_02_Magnitude : MonoBehaviour {
	
	private GameObject _player;
	
	[Header("Player")]
	public float player_x;
	public float player_y;
	public float magnitude;
	public float sqrMagnitude;
	
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
		_player.transform.position = new Vector3(player_x, 0, player_y);
		/*
		 * Q: What's the alternative of Magnitude()?
		 */
		magnitude = Magnitude();
		/*
		 * Q: What's the alternative of SqrMagnitude()?
		 */
		sqrMagnitude = SqrMagnitude();
		/*
		 * Q: When do we use sqrMagnitude over magnitude?
		 */
		
		Draw();
	}
	
	private float Magnitude()
	{
		return Mathf.Sqrt(player_x * player_x + player_y * player_y);
	}

	private float SqrMagnitude()
	{
			return player_x * player_x + player_y * player_y;
	}

	private void Draw()
	{
		Debug.DrawLine(_zero, new Vector3(player_x, 0, player_y), Color.cyan);
		Debug.DrawLine(_zero, new Vector3(player_x, 0, 0), Color.red);
		Debug.DrawLine(new Vector3(player_x, 0, 0), new Vector3(player_x, 0, player_y), Color.green);
	}
}
