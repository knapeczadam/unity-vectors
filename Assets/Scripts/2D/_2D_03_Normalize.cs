using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class _2D_03_Normalize : MonoBehaviour {
	
	private GameObject _player;
	
	[Header("Player")]
	public float player_x;
	public float player_y;

	[Header("Normalize")] 
	public float normalized_x;
	public float normalized_y;
	public float normalized_magnitude;

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
		 * Q: Difference between transform.position.normalized and transform.position.Normalize()?
		 */
		Normalize();
		
		/*
		 * Q: Magnitude of a normalzied vector is always between 0 and 1. True or false?
		 */
		normalized_magnitude = new Vector3(normalized_x, 0, normalized_y).magnitude;
		
		Draw();
	}

	private void Normalize()
	{
		/*
		 * Q: When do we use a normalized vector?
		 */
		float length = _player.transform.position.magnitude;
		normalized_x = player_x / length;
		normalized_y = player_y / length;
	}

	private void Draw()
	{
		Debug.DrawLine(_zero, new Vector3(player_x, 0, player_y), Color.cyan);
		Debug.DrawLine(_zero, _player.transform.position.normalized, Color.magenta);
	}
}
