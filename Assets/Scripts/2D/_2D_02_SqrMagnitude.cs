using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class _2D_02_SqrMagnitude : MonoBehaviour
{
	private GameObject _player;

	[Header("Player")] 
	public Vector2 PlayerPosition;
	[ReadOnly]
	public float PlayerSqrMagnitude;

	private GameObject _enemy;
	
	[Header("Enemy")] 
	public Vector2 EnemyPosition;
	[ReadOnly]
	public float EnemySqrMagnitude;
	
	[ReadOnly]
	[Header("Farther from zero")]
	public string text;
	
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
	void Update ()
	{
		_player.transform.position = PlayerPosition;
		_enemy.transform.position = EnemyPosition;
		/*
		 * Q: What's the alternative of CalculateSqrMagnitude()?
		 */
		CalculateSqrMagnitude();
		/*
		 * Q: When do we use sqrMagnitude over magnitude?
		 */
		
		text = PlayerSqrMagnitude == EnemySqrMagnitude ? "Equal" :
			PlayerSqrMagnitude > EnemySqrMagnitude ? "Player" : "Enemey";
		
		Draw();
	}
	
	private void CalculateSqrMagnitude()
	{
		PlayerSqrMagnitude =  PlayerPosition.x * PlayerPosition.x + PlayerPosition.y * PlayerPosition.y;
		EnemySqrMagnitude = EnemyPosition.x * EnemyPosition.x + EnemyPosition.y * EnemyPosition.y;
	}

	private void Draw()
	{
		Debug.DrawLine(new Vector2(0, 1), new Vector2(_enemy.transform.position.magnitude, 1), Color.red);
		Debug.DrawLine(new Vector2(0, 2), new Vector2(_player.transform.position.magnitude, 2), Color.green);
	}
}
