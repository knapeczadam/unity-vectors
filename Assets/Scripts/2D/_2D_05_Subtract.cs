using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class _2D_05_Subtract : MonoBehaviour {
	
	private GameObject _player;
	
	[Header("Player")]
	public float PlayerX;
	public float PlayerY;
	
	private GameObject _enemy;
	
	[Header("Enemy")]
	public float EnemyX;
	public float EnemyY;

	private float _xFromPlayerToEnemy;
	private float _yFromPlayerToEnemy;
	
	[Header("")]
	public float Distance;
	
	
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
		_player.transform.position = new Vector2(PlayerX, PlayerY);
		_enemy.transform.position = new Vector2(EnemyX, EnemyY);
		Subtract();
		Draw();
		
		/*
		 * Vector2.Distance uses sqrMagnitude to calculate distance between two vectors. True or false?
		 */
		Distance = Vector2.Distance(_player.transform.position, _enemy.transform.position);
	}

	private void Subtract()
	{
		_xFromPlayerToEnemy = EnemyX - PlayerX;
		_yFromPlayerToEnemy = EnemyY - PlayerY;
	}

	private void Draw()
	{
		Debug.DrawLine(_zero, _player.transform.position, Color.green);
		Debug.DrawLine(_zero, _enemy.transform.position, Color.red);
		Debug.DrawLine(_player.transform.position, new Vector2(PlayerX, PlayerY) + new Vector2(_xFromPlayerToEnemy, _yFromPlayerToEnemy), Color.cyan);
	}
}
