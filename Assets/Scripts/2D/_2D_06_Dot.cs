using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class _2D_06_Dot : MonoBehaviour {
	
	private GameObject _player;

	[Header("Player")] 
	public Vector2 PlayerPosition;
	
	private GameObject _enemy;
	
	[Header("Enemy")] 
	public Vector2 EnemyPosition;

	[Header("")]
	[ReadOnly]
	public float Dot;
	
	private readonly Vector2 _zero = Vector2.zero;
	
	private void OnEnable()
	{
		_player = GameObject.FindWithTag(Constant.PLAYER_2D);
		_enemy = GameObject.FindWithTag(Constant.ENEMY_2D);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_player.transform.position = PlayerPosition;
		_enemy.transform.position = EnemyPosition;
		/*
		 * Q: What's the formula of dot product?
		 *
		 * Q: How can you determine if two players are facing each other (using dot product)?
		 *
		 * Q: In order to check that two players are both aligned together you have to use the following method calling: Vector2.Dot(_player.transform.position.sqrMagnitude, _enemy.transform.position.sqrMagnitude). True or false?
		 *
		 * Q: If two players are perpendicular to each other the dot product is always _ ?
		 */
		Dot = Vector2.Dot(_player.transform.position, _enemy.transform.position);
		Draw();
	}
	
	private void Draw()
	{
		Debug.DrawLine(_zero, _player.transform.position, Color.green);
		Debug.DrawLine(_zero, _enemy.transform.position, Color.red);
	}
}
