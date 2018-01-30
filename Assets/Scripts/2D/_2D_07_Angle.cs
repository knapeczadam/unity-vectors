using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class _2D_07_Angle : MonoBehaviour {
	
	private GameObject _player;

	[Header("Player")] 
	public Vector2 PlayerPosition;
	
	private GameObject _enemy;
	
	[Header("Enemy")] 
	public Vector2 EnemyPosition;
	
	private readonly Vector2 _zero = Vector2.zero;
	
	[ReadOnly]
	public float Angle;

	private const float MaxDistanceFromZero = 10f;

	private void OnEnable()
	{
		_player = GameObject.FindWithTag(Constant.PLAYER_2D);
		_enemy = GameObject.FindWithTag(Constant.ENEMY_2D);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update()
	{
		if (PlayerPosition.sqrMagnitude <= Mathf.Pow(MaxDistanceFromZero, 2))
		{
			_player.transform.position = PlayerPosition;
		}
		if (EnemyPosition.sqrMagnitude <= Mathf.Pow(MaxDistanceFromZero, 2))
		{
			_enemy.transform.position = EnemyPosition;
		}
		/*
		 * Q: Angle (variable) can be greater than 180 degrees. True or false?
		 *
		 * Q: 57.29578f is a magic number, can't be calculated. True or false?
		 */
		Angle = Vector2.Angle(_player.transform.position, _enemy.transform.position);
		Draw();
	}

	private void Draw()
	{
		Debug.DrawLine(_zero, _player.transform.position, Color.green);
		Debug.DrawLine(_zero, _enemy.transform.position, Color.red);
		Debug.DrawLine(_player.transform.position.normalized, _enemy.transform.position.normalized, Color.cyan);
	}
}
