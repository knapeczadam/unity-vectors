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

	[Header("")] 
	public string CalculationX;
	public string CalculationY;

	private float _x;
	private float _y;
	
	[Header("")]
	public float Distance;
	
	[Header("")]
	public bool reversed;

	public string YouAreThe = "";
	
	
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

		YouAreThe = reversed ? "Enemy" : "Player";
	}

	private void Subtract()
	{
		if (reversed)
		{
			_x = PlayerX - EnemyX;
			_y = PlayerY - EnemyY;

			CalculationX = PlayerX + " - (" + EnemyX + ") = " + _x;
			CalculationY = PlayerY + " - (" + EnemyY + ") = " + _y;
		}
		else
		{
			_x = EnemyX - PlayerX;
			_y = EnemyY - PlayerY;
			
			
			CalculationX = EnemyX + " - (" + PlayerX + ") = " + _x;
			CalculationY = EnemyY + " - (" + PlayerY + ") = " + _y;
		}
	}

	private void Draw()
	{
		Debug.DrawLine(_zero, _player.transform.position, Color.green);
		Debug.DrawLine(_zero, _enemy.transform.position, Color.red);
		Debug.DrawLine(_zero, new Vector2(_x, _y), Color.cyan);

		if (reversed)
		{
			Debug.DrawLine(_enemy.transform.position, new Vector2(EnemyX, EnemyY) + new Vector2(_x, _y), Color.red);
		}
		else
		{
			Debug.DrawLine(_player.transform.position, new Vector2(PlayerX, PlayerY) + new Vector2(_x, _y), Color.green);
		}
	}
}
